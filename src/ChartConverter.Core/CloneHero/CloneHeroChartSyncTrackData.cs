using System;
using System.Text;

namespace ChartConverter.Core
{
    internal class CloneHeroChartSyncTrackData
    {
        // [SyncTrack]
        public double BeatsPerMinute { get; set; }

        public CloneHeroChartSyncTrackData(BeatSaberInfoFile infoFile)
        {
            BeatsPerMinute = infoFile.BeatsPerMinute;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("[SyncTrack]");
            sb.AppendLine("{");
            sb.AppendLine("  0 = TS 4");
            sb.AppendLine($"  0 = B {Math.Round(BeatsPerMinute * 1000)}");
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}