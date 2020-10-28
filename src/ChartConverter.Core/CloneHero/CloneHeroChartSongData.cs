using System;
using System.Collections.Generic;
using System.Text;

namespace ChartConverter.Core.CloneHero
{
    public class CloneHeroChartSongData
    {
        // [Song]
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Charter { get; set; }
        public double Offset { get; set; }
        public int Resolution { get; set; }
        public string Player2 { get; set; }
        public int Difficulty { get; set; }
        public int PreviewStart { get; set; }
        public int PreviewEnd { get; set; }
        public string MusicStream { get; set; }

        public CloneHeroChartSongData(BeatSaberInfoFile infoFile, int resolution)
        {
            Name = infoFile.SongName;
            Artist = infoFile.SongAuthorName;
            Charter = infoFile.LevelAuthorName;
            Offset = infoFile.SongTimeOffset;
            Resolution = resolution;
            Player2 = "bass";
            Difficulty = 0;
            PreviewStart = 0;
            PreviewEnd = 0;
            MusicStream = "song.ogg";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("[Song]");
            sb.AppendLine("{");
            sb.AppendLine($"  Name = \"{Name}\"");
            sb.AppendLine($"  Artist = \"{Artist}\"");
            sb.AppendLine($"  Charter = \"{Charter}\"");
            sb.AppendLine($"  Offset = {Offset}");
            sb.AppendLine($"  Resolution = {Resolution}");
            sb.AppendLine($"  Player2 = {Player2}");
            sb.AppendLine($"  Difficulty = {Difficulty}");
            sb.AppendLine($"  PreviewStart = {PreviewStart}");
            sb.AppendLine($"  PreviewEnd = {PreviewEnd}");
            sb.AppendLine($"  MusicStream = \"{MusicStream}\"");
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
