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
            ProcessPanel = 1,
            ResultPanel = 2
        }

        public enum ScenarioEndType
        {
            Catched = 0,
            Success = 1,
            Fail = 2
        }
    }
}