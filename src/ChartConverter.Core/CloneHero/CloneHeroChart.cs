using ChartConverter.Core.CloneHero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChartConverter.Core
{
    public class CloneHeroChart
    {
        private readonly int _resolution = 192;
        private ConverterConfig _config;

        public string Content { get; set; }

        public CloneHeroChart(BeatSaberInfoFile infoFile, IEnumerable<BeatSaberChart> charts, ConverterConfig config)
        {
            _config = config;
            Content = GenerateContentFromBeatSaberInfoFileAndCharts(infoFile, charts);
        }

        private string GenerateContentFromBeatSaberInfoFileAndCharts(BeatSaberInfoFile infoFile, IEnumerable<BeatSaberChart> charts)
        {
            var sb = new StringBuilder();

            // [Song]
            var songData = new CloneHeroChartSongData(infoFile, _resolution);
            sb.Append(songData.ToString());

            // [SyncTrack]
            var syncTrackData = new CloneHeroChartSyncTrackData(infoFile);
            sb.Append(syncTrackData.ToString());

            // [Events]
            var eventsData = new CloneHeroChartEventsData();
            sb.Append(eventsData.ToString());

            charts = SelectRelevantDifficultiesForCharts(charts);

            // [*Difficulty*Single]
            foreach (var chart in charts)
            {
                var difficultyNoteLines = new CloneHeroDifficultyNoteLines(chart, _resolution, _config);
                sb.Append(difficultyNoteLines.ToString());
            }

            return sb.ToString();
        }

        private IEnumerable<BeatSaberChart> SelectRelevantDifficultiesForCharts(IEnumerable<BeatSaberChart> charts)
        {
            bool expertPlusExists = charts.FirstOrDefault(c => c.Difficulty == BeatSaber.BeatSaberDifficulty.ExpertPlus) != null;
            if (expertPlusExists) return charts.Where(c => c.Difficulty != BeatSaber.BeatSaberDifficulty.Easy);

            return charts.Select(c =>
            {
                switch (c.Difficulty)
                {
                    case BeatSaber.BeatSaberDifficulty.Easy:
                        c.Difficulty = BeatSaber.BeatSaberDifficulty.Normal;
                        break;
                    case BeatSaber.BeatSaberDifficulty.Normal:
                        c.Difficulty = BeatSaber.BeatSaberDifficulty.Hard;
                        break;
                    case BeatSaber.BeatSaberDifficulty.Hard:
                        c.Difficulty = BeatSaber.BeatSaberDifficulty.Expert;
                        break;
                    case BeatSaber.BeatSaberDifficulty.Expert:
                        c.Difficulty = BeatSaber.BeatSaberDifficulty.ExpertPlus;
                        break;
                    default:
                        break;
                }
                return c;
            });
        }
    }
}
