using ChartConverter.Blazor.Models;
using ChartConverter.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Xunit;

namespace ChartConverter.Tests.CloneHero
{
    public class CloneHeroDifficultyNoteLinesTests
    {
        [Fact]
        public void ToString_WithUpperRowOrangeConfigButMiddleRowNotes_MapNothing()
        {
            // Arrange
            /*
             *  |   |   |   |   |
             *  | o | o | o | o |
             *  |   |   |   |   |
             */
            var chart = new BeatSaberChart()
            {
                Difficulty = Core.BeatSaber.BeatSaberDifficulty.ExpertPlus,
                Notes = new List<Note>()
                {
                    new Note()
                    {
                        Time = 1,
                        ColorType = 0, // red
                        CutDirectionId = 1, // all
                        LineLayer = 1,
                        LineIndex = 0
                    },
                    new Note()
                    {
                        Time = 2,
                        ColorType = 0, // red
                        CutDirectionId = 1, // all
                        LineLayer = 1,
                        LineIndex = 1
                    },
                    new Note()
                    {
                        Time = 3,
                        ColorType = 0, // red
                        CutDirectionId = 1, // all
                        LineLayer = 1,
                        LineIndex = 2
                    },
                    new Note()
                    {
                        Time = 4,
                        ColorType = 0, // red
                        CutDirectionId = 1, // all
                        LineLayer = 1,
                        LineIndex = 3
                    }
                }
            };

            var config = new ConverterConfig()
            {
                CloneHeroColorBeatSaberConfigsDic = new Dictionary<CloneHeroColor, List<Blazor.Models.BeatSaberConfiguration>>()
            };
            var configs = new List<BeatSaberConfiguration>();
            /*
             *  | o | o | o | o |
             *  |   |   |   |   |
             *  |   |   |   |   |
             */
            var dirAndColors = new DirectionAndColor[3, 4];
            dirAndColors[0, 0] = new DirectionAndColor() { Color = BeatSaberColor.RED, Direction = BeatSaberCutDirection.ALL };
            dirAndColors[0, 1] = new DirectionAndColor() { Color = BeatSaberColor.RED, Direction = BeatSaberCutDirection.ALL };
            dirAndColors[0, 2] = new DirectionAndColor() { Color = BeatSaberColor.RED, Direction = BeatSaberCutDirection.ALL };
            dirAndColors[0, 3] = new DirectionAndColor() { Color = BeatSaberColor.RED, Direction = BeatSaberCutDirection.ALL };

            dirAndColors[1, 0] = new DirectionAndColor() { Color = BeatSaberColor.NONE, Direction = BeatSaberCutDirection.NONE };
            dirAndColors[1, 1] = new DirectionAndColor() { Color = BeatSaberColor.NONE, Direction = BeatSaberCutDirection.NONE };
            dirAndColors[1, 2] = new DirectionAndColor() { Color = BeatSaberColor.NONE, Direction = BeatSaberCutDirection.NONE };
            dirAndColors[1, 3] = new DirectionAndColor() { Color = BeatSaberColor.NONE, Direction = BeatSaberCutDirection.NONE };

            dirAndColors[2, 0] = new DirectionAndColor() { Color = BeatSaberColor.NONE, Direction = BeatSaberCutDirection.NONE };
            dirAndColors[2, 1] = new DirectionAndColor() { Color = BeatSaberColor.NONE, Direction = BeatSaberCutDirection.NONE };
            dirAndColors[2, 2] = new DirectionAndColor() { Color = BeatSaberColor.NONE, Direction = BeatSaberCutDirection.NONE };
            dirAndColors[2, 3] = new DirectionAndColor() { Color = BeatSaberColor.NONE, Direction = BeatSaberCutDirection.NONE };

            configs.Add(new BeatSaberConfiguration()
            {
                DirectionAndColors = dirAndColors
            });
            config.CloneHeroColorBeatSaberConfigsDic.Add(CloneHeroColor.Red, configs);

            int resolution = 192;

            var noteLines = new CloneHeroDifficultyNoteLines(chart, resolution, config);

            // Act
            var result = noteLines.ToString();

            // Assert
            var sb = new StringBuilder();
            sb.AppendLine("[ExpertSingle]");
            sb.AppendLine("{");
            sb.AppendLine("}");

            Assert.Equal(sb.ToString(), result);
        }

        [Fact]
        public void ToString_WithUpperRowOrangeConfigAndUpperRowNotes_MapUpperRowToOrange()
        {
            // Arrange
            /*
             *  | o | o | o | o |
             *  |   |   |   |   |
             *  |   |   |   |   |
             */
            var chart = new BeatSaberChart()
            {
                Difficulty = Core.BeatSaber.BeatSaberDifficulty.ExpertPlus,
                Notes = new List<Note>()
                {
                    new Note()
                    {
                        Time = 1,
                        ColorType = 0, // red
                        CutDirectionId = 1, // all
                        LineLayer = 2,
                        LineIndex = 0
                    },
                    new Note()
                    {
                        Time = 2,
                        ColorType = 0, // red
                        CutDirectionId = 1, // all
                        LineLayer = 2,
                        LineIndex = 1
                    },
                    new Note()
                    {
                        Time = 3,
                        ColorType = 0, // red
                        CutDirectionId = 1, // all
                        LineLayer = 2,
                        LineIndex = 2
                    },
                    new Note()
                    {
                        Time = 4,
                        ColorType = 0, // red
                        CutDirectionId = 1, // all
                        LineLayer = 2,
                        LineIndex = 3
                    }
                }
            };

            var config = new ConverterConfig()
            {
                CloneHeroColorBeatSaberConfigsDic = new Dictionary<CloneHeroColor, List<Blazor.Models.BeatSaberConfiguration>>()
            };
            var configs = new List<BeatSaberConfiguration>();
            /*
             *  | o | o | o | o |
             *  |   |   |   |   |
             *  |   |   |   |   |
             */
            var dirAndColors = new DirectionAndColor[3, 4];
            dirAndColors[0, 0] = new DirectionAndColor() { Color = BeatSaberColor.RED, Direction = BeatSaberCutDirection.ALL };
            dirAndColors[0, 1] = new DirectionAndColor() { Color = BeatSaberColor.RED, Direction = BeatSaberCutDirection.ALL };
            dirAndColors[0, 2] = new DirectionAndColor() { Color = BeatSaberColor.RED, Direction = BeatSaberCutDirection.ALL };
            dirAndColors[0, 3] = new DirectionAndColor() { Color = BeatSaberColor.RED, Direction = BeatSaberCutDirection.ALL };

            dirAndColors[1, 0] = new DirectionAndColor() { Color = BeatSaberColor.NONE, Direction = BeatSaberCutDirection.NONE };
            dirAndColors[1, 1] = new DirectionAndColor() { Color = BeatSaberColor.NONE, Direction = BeatSaberCutDirection.NONE };
            dirAndColors[1, 2] = new DirectionAndColor() { Color = BeatSaberColor.NONE, Direction = BeatSaberCutDirection.NONE };
            dirAndColors[1, 3] = new DirectionAndColor() { Color = BeatSaberColor.NONE, Direction = BeatSaberCutDirection.NONE };

            dirAndColors[2, 0] = new DirectionAndColor() { Color = BeatSaberColor.NONE, Direction = BeatSaberCutDirection.NONE };
            dirAndColors[2, 1] = new DirectionAndColor() { Color = BeatSaberColor.NONE, Direction = BeatSaberCutDirection.NONE };
            dirAndColors[2, 2] = new DirectionAndColor() { Color = BeatSaberColor.NONE, Direction = BeatSaberCutDirection.NONE };
            dirAndColors[2, 3] = new DirectionAndColor() { Color = BeatSaberColor.NONE, Direction = BeatSaberCutDirection.NONE };

            configs.Add(new BeatSaberConfiguration()
            {
                DirectionAndColors = dirAndColors
            });
            config.CloneHeroColorBeatSaberConfigsDic.Add(CloneHeroColor.Red, configs);

            int resolution = 192;

            var noteLines = new CloneHeroDifficultyNoteLines(chart, resolution, config);

            // Act
            var result = noteLines.ToString();

            // Assert
            var sb = new StringBuilder();
            sb.AppendLine("[ExpertSingle]");
            sb.AppendLine("{");
            sb.AppendLine("  192 = N 1 0");
            sb.AppendLine("  384 = N 1 0");
            sb.AppendLine("  576 = N 1 0");
            sb.AppendLine("  768 = N 1 0");
            sb.AppendLine("}");

            Assert.Equal(sb.ToString(), result);
        }

        [Fact]
        public void ToString_WithUpperRowConfigButLowerAndMiddleNotes_MapNothing()
        {
            var json = @"[{
                ""_time"": 38,
                ""_lineIndex"": 3,
                ""_lineLayer"": 0,
                ""_type"": 0,
                ""_cutDirection"": 5
            },
            {
                ""_time"": 38,
                ""_lineIndex"": 3,
                ""_lineLayer"": 1,
                ""_type"": 1,
                ""_cutDirection"": 5
            },
            {
                ""_time"": 39,
                ""_lineIndex"": 3,
                ""_lineLayer"": 0,
                ""_type"": 1,
                ""_cutDirection"": 1
            },
            {
                ""_time"": 40,
                ""_lineIndex"": 0,
                ""_lineLayer"": 1,
                ""_type"": 0,
                ""_cutDirection"": 4
            },
            {
                ""_time"": 40,
                ""_lineIndex"": 0,
                ""_lineLayer"": 0,
                ""_type"": 1,
                ""_cutDirection"": 4
            }]";
            var notes = JsonSerializer.Deserialize<List<Note>>(json);
            var chart = new BeatSaberChart()
            {
                Difficulty = Core.BeatSaber.BeatSaberDifficulty.ExpertPlus,
                Notes = notes
            };

            var config = ConverterConfig.GetDefault();

            var noteLines = new CloneHeroDifficultyNoteLines(chart, 192, config);
            var result = noteLines.ToString();

            // Assert
            var sb = new StringBuilder();
            sb.AppendLine("[ExpertSingle]");
            sb.AppendLine("{");
            sb.AppendLine("  7296 = N 3 0");
            sb.AppendLine("  7296 = N 0 0");
            sb.AppendLine("  7488 = N 0 0");
            sb.AppendLine("  7680 = N 0 0");
            sb.AppendLine("  7680 = N 3 0");
            sb.AppendLine("}");

            Assert.Equal(sb.ToString(), result);
        }

        [Fact]
        public void ToString_WithWeirdMaps_NotCrash()
        {
            // Arrange
            var json = @"[{
            ""_time"": 58,
            ""_lineIndex"": 5000,
            ""_lineLayer"": 2750,
            ""_type"": 1,
            ""_cutDirection"": 0
        },
        {
            ""_time"": 58,
            ""_lineIndex"": 5000,
            ""_lineLayer"": 3000,
            ""_type"": 1,
            ""_cutDirection"": 0
        },
        {
            ""_time"": 58.25,
            ""_lineIndex"": -2000,
            ""_lineLayer"": 1000,
            ""_type"": 0,
            ""_cutDirection"": 1
        },
        {
            ""_time"": 58.25,
            ""_lineIndex"": -2000,
            ""_lineLayer"": 1250,
            ""_type"": 0,
            ""_cutDirection"": 1
        }]";
            var notes = JsonSerializer.Deserialize<List<Note>>(json);
            var chart = new BeatSaberChart()
            {
                Difficulty = Core.BeatSaber.BeatSaberDifficulty.ExpertPlus,
                Notes = notes
            };

            var config = ConverterConfig.GetDefault();

            var noteLines = new CloneHeroDifficultyNoteLines(chart, 192, config);

            // Act
            var exception = Record.Exception(() => noteLines.ToString());

            // Assert
            Assert.Null(exception);
        }
    }
}
