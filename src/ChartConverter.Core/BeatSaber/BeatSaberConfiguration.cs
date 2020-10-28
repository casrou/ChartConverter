using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChartConverter.Blazor.Models
{
    public class BeatSaberConfiguration
    {
        public DirectionAndColor[,] DirectionAndColors { get; set; }

        public BeatSaberConfiguration()
        {
            DirectionAndColors = new DirectionAndColor[3, 4];
            for (int i = 0; i < DirectionAndColors.GetLength(0); i++)
            {
                for (int j = 0; j < DirectionAndColors.GetLength(1); j++)
                {
                    DirectionAndColors[i, j] = new DirectionAndColor();
                }
            }
        }
    }

    public class DirectionAndColor
    {
        public BeatSaberCutDirection Direction { get; set; }
        public BeatSaberColor Color { get; set; }

        public override bool Equals(object obj)
        {
            var other = (DirectionAndColor)obj;
            return Direction.Equals(other.Direction) && Color.Equals(other.Color);
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Direction, Color).GetHashCode();
        }
    }

    public enum BeatSaberCutDirection
    {
        NONE, ALL, UP, DOWN, LEFT, RIGHT, UPLEFT, UPRIGHT, DOWNLEFT, DOWNRIGHT
    }

    public enum BeatSaberColor
    {
        NONE, RED, BLUE
    }

    public static class BeatSaberEnumHelper
    {
        public static int GetIntFromCutDirection(BeatSaberCutDirection cutDirection)
        {
            //if (!Enum.IsDefined(typeof(BeatSaberCutDirection), cutDirection)) return -1;
            return (int)cutDirection;
        }

        public static BeatSaberCutDirection GetCutDirectionFromInt(int cutDirectionInt)
        {
            if (!Enum.IsDefined(typeof(BeatSaberCutDirection), cutDirectionInt)) return BeatSaberCutDirection.NONE;
            return (BeatSaberCutDirection)cutDirectionInt;
        }

        public static string GetColorClassNameFromColor(this BeatSaberColor color)
        {
            switch (color)
            {
                case BeatSaberColor.NONE:
                    return "";
                case BeatSaberColor.RED:
                    return "red";
                case BeatSaberColor.BLUE:
                    return "blue";
                default:
                    return null;
            }
        }

        public static string GetArrowStringFromCutDirection(this BeatSaberCutDirection cutDirection)
        {
            switch (cutDirection)
            {
                case BeatSaberCutDirection.NONE:
                    return " ";
                case BeatSaberCutDirection.ALL:
                    return "●";// "⬤";
                case BeatSaberCutDirection.UP:
                    return "▲";
                case BeatSaberCutDirection.DOWN:
                    return "▼";
                case BeatSaberCutDirection.LEFT:
                    return "◀";
                case BeatSaberCutDirection.RIGHT:
                    return "▶";
                case BeatSaberCutDirection.UPLEFT:
                    return "◤";
                case BeatSaberCutDirection.UPRIGHT:
                    return "◥";
                case BeatSaberCutDirection.DOWNLEFT:
                    return "◣";
                case BeatSaberCutDirection.DOWNRIGHT:
                    return "◢";
                default:
                    return null;
            }
        }
    }

}
