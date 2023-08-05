using ScriptableObjects;

namespace Core.Services.ScoreService
{
    public class ScoreService : IScoreService
    {
        private readonly int _maxScore;

        public int MaxScore => _maxScore;

        public int CurrentScore { get; private set; }

        public ScoreService(ScenarioData scenarioData)
        {
            _maxScore = scenarioData.MaxScore;
        }

        public void AddScore(int value)
        {
            CurrentScore += value;
            if (CurrentScore < 0)
                CurrentScore = 0;
        }
    }
}