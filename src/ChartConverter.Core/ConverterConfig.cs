using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChartConverter.Blazor.Models;

namespace ChartConverter.Core
{
    public class ConverterConfig
    {
        public Dictionary<CloneHeroColor, List<BeatSaberConfiguration>> CloneHeroColorBeatSaberConfigsDic { get; set; }

        public ConverterConfig()
        {
            CloneHeroColorBeatSaberConfigsDic = new Dictionary<CloneHeroColor, List<BeatSaberConfiguration>>();
        }

        public static ConverterConfig GetDefault()
        {
            var defaultValues = new Dictionary<CloneHeroColor, List<BeatSaberConfiguration>>();

            #region First fret (green)
            var greenConfig = new List<BeatSaberConfiguration>();
            var greenMatrix = new DirectionAndColor[3, 4];
            greenMatrix[0, 0] = new DirectionAndColor()
            {
                Color = BeatSaberColor.RED,
                Direction = BeatSaberCutDirection.ALL
            };
            greenMatrix[1, 0] = new DirectionAndColor()
            {
                Color = BeatSaberColor.RED,
                Direction = BeatSaberCutDirection.ALL
            };
            greenMatrix[2, 0] = new DirectionAndColor()
            {
                Color = BeatSaberColor.RED,
                Direction = BeatSaberCutDirection.ALL
            };
            greenMatrix[0, 3] = new DirectionAndColor()
            {
                Color = BeatSaberColor.BLUE,
                Direction = BeatSaberCutDirection.ALL
            };
            greenMatrix[1, 3] = new DirectionAndColor()
            {
                Color = BeatSaberColor.BLUE,
                Direction = BeatSaberCutDirection.ALL
            };
            greenMatrix[2, 3] = new DirectionAndColor()
            {
                Color = BeatSaberColor.BLUE,
                Direction = BeatSaberCutDirection.ALL
            };
            greenConfig.Add(new BeatSaberConfiguration()
            {
                DirectionAndColors = greenMatrix
            });
            defaultValues.Add(CloneHeroColor.Green, greenConfig);
            #endregion

            #region Second fret (red)
            var redConfig = new List<BeatSaberConfiguration>();
            var redMatrix = new DirectionAndColor[3, 4];
            redMatrix[0, 1] = new DirectionAndColor()
            {
                Color = BeatSaberColor.RED,
                Direction = BeatSaberCutDirection.ALL
            };
            redMatrix[1, 1] = new DirectionAndColor()
            {
                Color = BeatSaberColor.RED,
                Direction = BeatSaberCutDirection.ALL
            };
            redMatrix[2, 1] = new DirectionAndColor()
            {
                Color = BeatSaberColor.RED,
                Direction = BeatSaberCutDirection.ALL
            };
            redMatrix[0, 2] = new DirectionAndColor()
            {
                Color = BeatSaberColor.BLUE,
                Direction = BeatSaberCutDirection.ALL
            };
            redMatrix[1, 2] = new DirectionAndColor()
            {
                Color = BeatSaberColor.BLUE,
                Direction = BeatSaberCutDirection.ALL
            };
            redMatrix[2, 2] = new DirectionAndColor()
            {
                Color = BeatSaberColor.BLUE,
                Direction = BeatSaberCutDirection.ALL
            };
            redConfig.Add(new BeatSaberConfiguration()
            {
                DirectionAndColors = redMatrix
            });
            defaultValues.Add(CloneHeroColor.Red, redConfig);
            #endregion

            #region Third fret (yellow)
            var yellowConfig = new List<BeatSaberConfiguration>();
            var yellowMatrix = new DirectionAndColor[3, 4];
            yellowMatrix[1, 2] = new DirectionAndColor()
            {
                Color = BeatSaberColor.RED,
                Direction = BeatSaberCutDirection.ALL
            };
            yellowMatrix[2, 2] = new DirectionAndColor()
            {
                Color = BeatSaberColor.RED,
                Direction = BeatSaberCutDirection.ALL
            };
            yellowMatrix[1, 1] = new DirectionAndColor()
            {
                Color = BeatSaberColor.BLUE,
                Direction = BeatSaberCutDirection.ALL
            };
            yellowMatrix[2, 1] = new DirectionAndColor()
            {
                Color = BeatSaberColor.BLUE,
                Direction = BeatSaberCutDirection.ALL
            };
            yellowConfig.Add(new BeatSaberConfiguration()
            {
                DirectionAndColors = yellowMatrix
            });
            defaultValues.Add(CloneHeroColor.Yellow, yellowConfig);
            #endregion

            #region Fourth fret (blue)
            var blueConfig = new List<BeatSaberConfiguration>();
            var blueMatrix = new DirectionAndColor[3, 4];
            blueMatrix[1, 3] = new DirectionAndColor()
            {
                Color = BeatSaberColor.RED,
                Direction = BeatSaberCutDirection.ALL
            };
            blueMatrix[2, 3] = new DirectionAndColor()
            {
                Color = BeatSaberColor.RED,
                Direction = BeatSaberCutDirection.ALL
            };
            blueMatrix[1, 0] = new DirectionAndColor()
            {
                Color = BeatSaberColor.BLUE,
                Direction = BeatSaberCutDirection.ALL
            };
            blueMatrix[2, 0] = new DirectionAndColor()
            {
                Color = BeatSaberColor.BLUE,
                Direction = BeatSaberCutDirection.ALL
            };
            blueConfig.Add(new BeatSaberConfiguration()
            {
                DirectionAndColors = blueMatrix
            });
            defaultValues.Add(CloneHeroColor.Blue, blueConfig);
            #endregion

            #region Fifth fret (orange)
            var orangeConfig = new List<BeatSaberConfiguration>();
            var orangeMatrix = new DirectionAndColor[3, 4];
            orangeMatrix[0, 2] = new DirectionAndColor()
            {
                Color = BeatSaberColor.RED,
                Direction = BeatSaberCutDirection.ALL
            };
            orangeMatrix[0, 3] = new DirectionAndColor()
            {
                Color = BeatSaberColor.RED,
                Direction = BeatSaberCutDirection.ALL
            };
            orangeMatrix[0, 0] = new DirectionAndColor()
            {
                Color = BeatSaberColor.BLUE,
                Direction = BeatSaberCutDirection.ALL
            };
            orangeMatrix[0, 1] = new DirectionAndColor()
            {
                Color = BeatSaberColor.BLUE,
                Direction = BeatSaberCutDirection.ALL
            };
            orangeConfig.Add(new BeatSaberConfiguration()
            {
                DirectionAndColors = orangeMatrix
            });
            defaultValues.Add(CloneHeroColor.Orange, orangeConfig);
            #endregion

            var filledDefaultValues = FillNull(defaultValues);

            return new ConverterConfig()
            {
                CloneHeroColorBeatSaberConfigsDic = filledDefaultValues
            };
        }

        private static Dictionary<CloneHeroColor, List<BeatSaberConfiguration>> FillNull(Dictionary<CloneHeroColor, List<BeatSaberConfiguration>> defaultValues)
        {
            var filled = defaultValues;
            foreach (var config in filled.Values.SelectMany(c => c).Select(c => c.DirectionAndColors))
            {
                for (int i = 0; i < config.GetLength(0); i++)
                {
                    for (int j = 0; j < config.GetLength(1); j++)
                    {
                        if (config[i, j] == null) config[i, j] = new DirectionAndColor();
                    }
                }
            }
            return filled;
        }
    }
}
