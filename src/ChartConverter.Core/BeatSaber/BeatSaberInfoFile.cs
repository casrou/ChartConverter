using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ChartConverter.Core
{
    //public class CustomData
    //{
    //    [JsonPropertyName("_contributors")]
    //    public List<object> Contributors { get; set; }

    //    [JsonPropertyName("_customEnvironment")]
    //    public string CustomEnvironment { get; set; }

    //    [JsonPropertyName("_customEnvironmentHash")]
    //    public string CustomEnvironmentHash { get; set; }
    //}

    //public class CustomData2
    //{
    //    [JsonPropertyName("_difficultyLabel")]
    //    public string DifficultyLabel { get; set; }

    //    [JsonPropertyName("_editorOffset")]
    //    public int EditorOffset { get; set; }

    //    [JsonPropertyName("_editorOldOffset")]
    //    public int EditorOldOffset { get; set; }

    //    [JsonPropertyName("_warnings")]
    //    public List<object> Warnings { get; set; }

    //    [JsonPropertyName("_information")]
    //    public List<object> Information { get; set; }

    //    [JsonPropertyName("_suggestions")]
    //    public List<object> Suggestions { get; set; }

    //    [JsonPropertyName("_requirements")]
    //    public List<object> Requirements { get; set; }
    //}

    //public class DifficultyBeatmap
    //{
    //    [JsonPropertyName("_difficulty")]
    //    public string Difficulty { get; set; }

    //    [JsonPropertyName("_difficultyRank")]
    //    public int DifficultyRank { get; set; }

    //    [JsonPropertyName("_beatmapFilename")]
    //    public string BeatmapFilename { get; set; }

    //    [JsonPropertyName("_noteJumpMovementSpeed")]
    //    public int NoteJumpMovementSpeed { get; set; }

    //    [JsonPropertyName("_noteJumpStartBeatOffset")]
    //    public double NoteJumpStartBeatOffset { get; set; }

    //    [JsonPropertyName("_customData")]
    //    public CustomData2 CustomData { get; set; }
    //}

    //public class DifficultyBeatmapSet
    //{
    //    [JsonPropertyName("_beatmapCharacteristicName")]
    //    public string BeatmapCharacteristicName { get; set; }

    //    [JsonPropertyName("_difficultyBeatmaps")]
    //    public List<DifficultyBeatmap> DifficultyBeatmaps { get; set; }
    //}

    public class BeatSaberInfoFile
    {
        //[JsonPropertyName("_version")]
        //public string Version { get; set; }

        [JsonPropertyName("_songName")]
        public string SongName { get; set; }

        //[JsonPropertyName("_songSubName")]
        //public string SongSubName { get; set; }

        [JsonPropertyName("_songAuthorName")]
        public string SongAuthorName { get; set; }

        [JsonPropertyName("_levelAuthorName")]
        public string LevelAuthorName { get; set; }

        [JsonPropertyName("_beatsPerMinute")]
        public double BeatsPerMinute { get; set; }

        [JsonPropertyName("_songTimeOffset")]
        public int SongTimeOffset { get; set; }

        //[JsonPropertyName("_shuffle")]
        //public int Shuffle { get; set; }

        //[JsonPropertyName("_shufflePeriod")]
        //public double ShufflePeriod { get; set; }

        //[JsonPropertyName("_previewStartTime")]
        //public double PreviewStartTime { get; set; }

        //[JsonPropertyName("_previewDuration")]
        //public double PreviewDuration { get; set; }

        //[JsonPropertyName("_songFilename")]
        //public string SongFilename { get; set; }

        //[JsonPropertyName("_coverImageFilename")]
        //public string CoverImageFilename { get; set; }

        //[JsonPropertyName("_environmentName")]
        //public string EnvironmentName { get; set; }

        //[JsonPropertyName("_customData")]
        //public CustomData CustomData { get; set; }

        //[JsonPropertyName("_difficultyBeatmapSets")]
        //public List<DifficultyBeatmapSet> DifficultyBeatmapSets { get; set; }
    }


}
