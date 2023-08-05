using System;

namespace Core.Enums
{
    public static class Enumenators
    {
        public enum PointType
        {
            EnemyPoint = 0,
            PlayerPoint = 1
        }

        [Serializable]
        public enum PanelType
        {
            ScorePanel = 0,
            ResultPanel = 1
        }
    }
}