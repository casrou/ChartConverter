using ChartConverter.Core.BeatSaber;
using System;
using System.Text;
using ChartConverter.Blazor.Models;
using System.Collections.Generic;

namespace ChartConverter.Core
{
    public class CloneHeroDifficultyNoteLines
    {
        private readonly BeatSaberChart _chart;
        private readonly int _resolution;
        private readonly ConverterConfig _config;

        public CloneHeroDifficultyNoteLines(BeatSaberChart chart, int resolution, ConverterConfig config)
        {
            _chart = chart;
            _resolution = resolution;
            _config = config;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var cloneHeroDifficulty = CloneHeroDifficultyHelper.GetCloneHeroDifficultyFromBeatSaberDifficulty(_chart.Difficulty);

            sb.AppendLine($"[{cloneHeroDifficulty}Single]");
            sb.AppendLine("{");

            //foreach (var note in _chart.Notes)
            //{
                sb.Append(GenerateNoteLinesFromNotes(_chart.Notes, cloneHeroDifficulty));
                //var pos = Math.Round(note.Time * _resolution);// 192;
                //var type = "N";
                //var fret = DetermineFretFromConfig(note.LineIndex, note.LineLayer, note.ColorType, cloneHeroDifficulty);

                //var length = 0;
                //sb.Append("  ");
                //sb.Append($"{pos} = {type} {fret} {length}\n");
            //}

            sb.AppendLine("}");
            return sb.ToString();
        }

        private string GenerateNoteLinesFromNotes(List<Note> notes, CloneHeroDifficulty cloneHeroDifficulty)
        {
            var sb = new StringBuilder();

            foreach (var note in notes)
            {
                foreach (var item in _config.CloneHeroColorBeatSaberConfigsDic)
                {
                    var fret = (int)item.Key;
                    var configurations = item.Value;

                    foreach (var config in configurations)
                    {
                        // Layer needs to be flipped upside down
                        var layerIndex = Math.Abs(note.LineLayer - 2);

                        if (layerIndex - 1 > config.DirectionAndColors.GetLength(0)) continue;
                        if (note.LineIndex - 1 > config.DirectionAndColors.GetLength(1)) continue;

                        var direction = config.DirectionAndColors[layerIndex, note.LineIndex]?.Direction ?? BeatSaberCutDirection.NONE;
                        var color = config.DirectionAndColors[layerIndex, note.LineIndex]?.Color ?? BeatSaberColor.NONE;

                        if (direction == BeatSaberCutDirection.NONE || color == BeatSaberColor.NONE) continue;
                        var correctNodeDirectionOrAll = direction == note.CutDirection || direction == BeatSaberCutDirection.ALL;
                        if (!correctNodeDirectionOrAll || color != note.Color) continue;

                        var pos = Math.Round(note.Time * _resolution);
                        var type = "N";

                        var length = 0;
                        sb.Append("  ");
                        sb.AppendLine($"{pos} = {type} {fret} {length}");
                    }
                }
            }

            return sb.ToString();
        }

        //private int DetermineFretFromConfig(int lineIndex, int lineLayer, int colorType, CloneHeroDifficulty difficulty)
        //{
        //    // TODO: Make configurable by user
        //    _config.CloneHeroColorBeatSaberConfigDic

        //    return (int)CloneHeroColor.Green;
        //    //int[,] matrix;
        //    //if (difficulty == CloneHeroDifficulty.Expert)
        //    //{
        //    //    int[,] redExpertMatrix = new int[3, 4]
        //    //    {
        //    //        { 4, 4, 2, 3 },
        //    //        { 4, 4, 2, 3 },
        //    //        { 4, 4, 2, 3 }
        //    //    };
        //    //    int[,] blueExpertMatrix = new int[3, 4]
        //    //    {
        //    //        { 0, 1, 4, 4 },
        //    //        { 0, 1, 4, 4 },
        //    //        { 0, 1, 4, 4 }
        //    //    };

        //    //    matrix = colorType == 1 ? redExpertMatrix : blueExpertMatrix;
        //    //}
        //    //else
        //    //{
        //    //    int[,] redMatrix = new int[3, 4]
        //    //    {
        //    //        { 4, 1, 2, 3 },
        //    //        { 4, 1, 2, 3 },
        //    //        { 4, 1, 2, 3 }
        //    //    };

        //    //    int[,] blueMatrix = new int[3, 4]
        //    //    {
        //    //    { 0, 1, 2, 4 },
        //    //    { 0, 1, 2, 4 },
        //    //    { 0, 1, 2, 4 }
        //    //    };

        //    //    matrix = colorType == 1 ? redMatrix : blueMatrix;
        //    //}

        //    //return matrix[lineLayer, lineIndex];
        //}
    }
}