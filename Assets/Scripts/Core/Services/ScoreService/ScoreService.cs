using Core.Services.SceneRepository;

namespace Core.Services.ScoreService
{
    public class ScoreService : IScoreService
    {
        public int MaxScore => _sceneRepository.ScenarioData.MaxScore;

        public int CurrentScore { get; private set; }
        private ISceneRepository _sceneRepository;

        public ScoreService(ISceneRepository sceneRepository)
        {
            _sceneRepository = sceneRepository;
        }

        public void AddScore(int value)
        {
            CurrentScore += value;
            if (CurrentScore < 0)
                CurrentScore = 0;
        }
    }
}