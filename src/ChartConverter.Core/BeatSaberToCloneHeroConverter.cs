using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ChartConverter;
using ChartConverter.Blazor.Models;
using ChartConverter.Core.BeatSaber;

namespace ChartConverter.Core
{
    public class BeatSaberToCloneHeroConverter
    {
        private readonly ConverterConfig _configuration;

        //public Dictionary<CloneHeroColor, BeatSaberConfiguration> Configuration { get; set; }

        public BeatSaberToCloneHeroConverter(ConverterConfig configuration)
        {
            _configuration = configuration;
        }

        public async Task<CloneHeroDto> GenerateCloneHeroZipBytesFromBeatSaberZipFile(string beatSaberZipFilePath)
        {
            using var cloneHeroStream = new MemoryStream();
            using var beatSaberZipStream = new FileStream(beatSaberZipFilePath, FileMode.Open);

            return await GenerateCloneHeroZipStreamFromBeatSaberZipStream(beatSaberZipStream);
        }

        public async Task<Stream> GetBeatSaverStreamFromRequestCode(string requestCode)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "ChartConverter");

            var beatSaberZipStream = await client.GetStreamAsync($"https://beatsaver.com/api/download/key/{requestCode}");
            return beatSaberZipStream;
        }

        public async Task<CloneHeroDto> GenerateCloneHeroZipStreamFromBeatSaberZipStream(Stream beatSaberZipStream)
        {
            using var cloneHeroStream = new MemoryStream();

            BeatSaberInfoFile infoDat = new BeatSaberInfoFile();

            infoDat = await CreateCloneHeroZipFile(beatSaberZipStream, cloneHeroStream);

            // Return Clone Hero zip file as bytes
            cloneHeroStream.Seek(0, SeekOrigin.Begin);
            return new CloneHeroDto()
            {
                Data = cloneHeroStream.ToArray(),
                FileName = $"{infoDat.SongName} - {infoDat.SongAuthorName}.zip"
            };
        }

        private async Task<BeatSaberInfoFile> CreateCloneHeroZipFile(Stream beatSaberZipStream, MemoryStream cloneHeroStream)
        {
            BeatSaberInfoFile infoDat = null;
            List<BeatSaberChart> beatSaberCharts = new List<BeatSaberChart>();

            using var cloneHeroZipArchive = new ZipArchive(cloneHeroStream, ZipArchiveMode.Create, true);
            using var beatSaberZipArchive = new ZipArchive(beatSaberZipStream);

            foreach (ZipArchiveEntry entry in beatSaberZipArchive.Entries)
            {
                var fileName = entry.Name.ToLower();
                if (fileName.EndsWith(".egg") || fileName.EndsWith(".ogg"))
                {
                    ProcessSongFile(cloneHeroZipArchive, entry);
                }
                else if (fileName == "cover.png" || fileName == "cover.jpg")
                {
                    ProcessCoverImage(cloneHeroZipArchive, entry);
                }
                else if (fileName == "info.dat")
                {
                    infoDat = await ProcessInfoFile(cloneHeroZipArchive, entry);
                }
                else if (fileName.EndsWith(".dat"))// == "normal.dat")
                {
                    var chart = await ProcessChartDifficulty(entry);
                    if (chart == null) continue;
                    beatSaberCharts.Add(chart);
                }
            }

            if (infoDat == null) throw new NullReferenceException("The information file was null. Ensure the BeatSaber zip contains an info.dat file.");
            if (beatSaberCharts.Count == 0) throw new NullReferenceException("No charts was generated. Ensure the BeatSaber zip contains difficulty .dat files.");

            CreateNotesChartFile(infoDat, beatSaberCharts, cloneHeroZipArchive);

            return infoDat;
        }

        private void CreateNotesChartFile(BeatSaberInfoFile infoDat, List<BeatSaberChart> beatSaberCharts, ZipArchive cloneHeroArchive)
        {
            using var entryStream = cloneHeroArchive.CreateEntry("notes.chart").Open();
            using var streamWriter = new StreamWriter(entryStream);
            var cloneHeroChart = new CloneHeroChart(infoDat, beatSaberCharts, _configuration);
            streamWriter.Write(cloneHeroChart.Content);
        }

        private async Task<BeatSaberChart> ProcessChartDifficulty(ZipArchiveEntry entry)
        {
            var difficulty = GetDifficultyFromFileName(entry.Name);
            if (difficulty == BeatSaberDifficulty.Unknown) return null;

            using var stream = entry.Open();
            var chart = await JsonSerializer.DeserializeAsync<BeatSaberChart>(stream);

            chart.Difficulty = difficulty;

            return chart;
        }

        private BeatSaberDifficulty GetDifficultyFromFileName(string fileName)
        {
            var difficultyString = Path.GetFileNameWithoutExtension(fileName).ToLower().Replace("standard", "");
            BeatSaberDifficulty difficulty;
            switch (difficultyString)
            {
                case "easy":
                    difficulty = BeatSaberDifficulty.Easy;
                    break;
                case "normal":
                    difficulty = BeatSaberDifficulty.Normal;
                    break;
                case "hard":
                    difficulty = BeatSaberDifficulty.Hard;
                    break;
                case "expert":
                    difficulty = BeatSaberDifficulty.Expert;
                    break;
                case "expertplus":
                    difficulty = BeatSaberDifficulty.ExpertPlus;
                    break;
                default:
                    difficulty = BeatSaberDifficulty.Unknown;
                    break;
            }
            return difficulty;
        }

        private async Task<BeatSaberInfoFile> ProcessInfoFile(ZipArchive cloneHeroArchive, ZipArchiveEntry entry)
        {
            using var stream = entry.Open();
            var infoDat = await JsonSerializer.DeserializeAsync<BeatSaberInfoFile>(stream);
            stream.Close();

            using (var entryStream = cloneHeroArchive.CreateEntry("song.ini").Open())
            using (var streamWriter = new StreamWriter(entryStream))
            {
                streamWriter.Write(GenerateSongIniText(infoDat));
            }
            return infoDat;
        }

        private void ProcessCoverImage(ZipArchive cloneHeroArchive, ZipArchiveEntry entry)
        {
            using var stream = entry.Open();
            using var entryStream = cloneHeroArchive.CreateEntry("album.png").Open();
            stream.CopyTo(entryStream);
        }

        private void ProcessSongFile(ZipArchive cloneHeroArchive, ZipArchiveEntry entry)
        {
            using var stream = entry.Open();
            using var entryStream = cloneHeroArchive.CreateEntry("song.ogg").Open();
            stream.CopyTo(entryStream);
        }

        private string GenerateSongIniText(BeatSaberInfoFile infoFile)
        {
            var sb = new StringBuilder();
            sb.AppendLine("[song]");
            sb.AppendLine($"name={infoFile.SongName}");
            sb.AppendLine($"artist={infoFile.SongAuthorName}");
            sb.AppendLine("album=");
            sb.AppendLine("genre=");
            sb.AppendLine("year=");
            sb.AppendLine("song_length=");
            sb.AppendLine("diff_band=-1");
            sb.AppendLine("diff_guitar=1");
            sb.AppendLine("diff_bass=-1");
            sb.AppendLine("diff_drums=-1");
            sb.AppendLine("diff_keys=-1");
            sb.AppendLine("diff_guitarghl=-1");
            sb.AppendLine("diff_bassghl=-1");
            sb.AppendLine("preview_start_time=0");
            sb.AppendLine("frets=0");
            sb.AppendLine($"charter={infoFile.LevelAuthorName}");
            sb.AppendLine("icon=0");
            sb.AppendLine("loading_phrase=This chart was originally made for BeatSaber. Check out ChartConverter: https://casrou.github.io/ChartConverter/");
            return sb.ToString();
        }
    }
}
