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

        public enum EnemyUIPanel
        {
            Unknown = 0,
            ProccessPanel = 1,
            ResultPanel = 2
        }
    }
}