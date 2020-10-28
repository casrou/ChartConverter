using System.Text;

namespace ChartConverter.Core
{
    internal class CloneHeroChartEventsData
    {
        public CloneHeroChartEventsData()
        {
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("[Events]");
            sb.AppendLine("{");
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}