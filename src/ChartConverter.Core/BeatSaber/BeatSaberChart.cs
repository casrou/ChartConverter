using ChartConverter.Blazor.Models;
using ChartConverter.Core.BeatSaber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace ChartConverter.Core
{
    //public class Event
    //{
    //    [JsonPropertyName("_time")]
    //    public double Time { get; set; }

    //    [JsonPropertyName("_type")]
    //    public int Type { get; set; }

    //    [JsonPropertyName("_value")]
    //    public int Value { get; set; }
    //}

    public class Note
    {
        [JsonPropertyName("_time")]
        public double Time { get; set; }

        [JsonPropertyName("_lineIndex")]
        public int LineIndex { get; set; }

        [JsonPropertyName("_lineLayer")]
        public int LineLayer { get; set; }

        [JsonPropertyName("_type")]
        public int ColorType { get; set; }

        [JsonPropertyName("_cutDirection")]
        public int CutDirectionId { get; set; }

        public BeatSaberColor Color => ColorFromType(ColorType);

        public BeatSaberCutDirection CutDirection => CutDirectionFromCutDirectionId(CutDirectionId);

        private BeatSaberColor ColorFromType(int colorType)
        {
            BeatSaberColor result = BeatSaberColor.NONE;
            switch (colorType)
            {
                case 0:
                    result = BeatSaberColor.RED;
                    break;
                case 1:
                    result = BeatSaberColor.BLUE;
                    break;
                default:
                    break;
            }
            return result;
        }

        private BeatSaberCutDirection CutDirectionFromCutDirectionId(int cutDirectionId)
        {
            return (BeatSaberCutDirection)cutDirectionId;
            //BeatSaberCutDirection result = null;
            //switch (cutDirectionId)
            //{
            //    case 0:
            //        result = "↑";
            //        break;
            //    case 1:
            //        result = "↓";
            //        break;
            //    case 2:
            //        result = "←";
            //        break;
            //    case 3:
            //        result = "→";
            //        break;
            //    case 4:
            //        result = "↖";
            //        break;
            //    case 5:
            //        result = "↗";
            //        break;
            //    case 6:
            //        result = "↙";
            //        break;
            //    case 7:
            //        result = "↘";
            //        break;
            //    default:
            //        break;
            //}
            //return result;
        }

        public override string ToString()
        {
            return $"Time: {Time}, Color: {Color}, CutDirection: {CutDirection} ({CutDirectionId}), LineIndex: {LineIndex}, LineLayer: {LineLayer}";
        }
    }

    //public class Obstacle
    //{
    //    [JsonPropertyName("_time")]
    //    public double Time { get; set; }

    //    [JsonPropertyName("_lineIndex")]
    //    public int LineIndex { get; set; }

    //    [JsonPropertyName("_type")]
    //    public int Type { get; set; }

    //    [JsonPropertyName("_duration")]
    //    public double Duration { get; set; }

    //    [JsonPropertyName("_width")]
    //    public int Width { get; set; }
    //}

    public class BeatSaberChart
    {
        //[JsonPropertyName("_version")]
        //public string Version { get; set; }

        //[JsonPropertyName("_BPMChanges")]
        //public List<object> BPMChanges { get; set; }

        //[JsonPropertyName("_events")]
        //public List<Event> Events { get; set; }

        [JsonPropertyName("_notes")]
        public List<Note> Notes { get; set; }

        //[JsonPropertyName("_obstacles")]
        //public List<Obstacle> Obstacles { get; set; }

        //[JsonPropertyName("_bookmarks")]
        //public List<object> Bookmarks { get; set; }

        public BeatSaberDifficulty Difficulty { get; set; }
    }
}
