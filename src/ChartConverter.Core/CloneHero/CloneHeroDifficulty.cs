using ChartConverter.Core.BeatSaber;

namespace ChartConverter.Core
{
    public enum CloneHeroDifficulty
    {
        Unknown, Easy, Medium, Hard, Expert
    }

    public static class CloneHeroDifficultyHelper
    {
        public static CloneHeroDifficulty GetCloneHeroDifficultyFromBeatSaberDifficulty(BeatSaberDifficulty beatSaberDifficulty)
        {
            CloneHeroDifficulty cloneHeroDifficulty;
            switch (beatSaberDifficulty)
            {
                case BeatSaberDifficulty.Normal:
                    cloneHeroDifficulty = CloneHeroDifficulty.Easy;
                    break;
                case BeatSaberDifficulty.Hard:
                    cloneHeroDifficulty = CloneHeroDifficulty.Medium;
                    break;
                case BeatSaberDifficulty.Expert:
                    cloneHeroDifficulty = CloneHeroDifficulty.Hard;
                    break;
                case BeatSaberDifficulty.ExpertPlus:
                    cloneHeroDifficulty = CloneHeroDifficulty.Expert;
                    break;
                default:
                    cloneHeroDifficulty = CloneHeroDifficulty.Unknown;
                    break;
            }
            return cloneHeroDifficulty;
        }
    }
}