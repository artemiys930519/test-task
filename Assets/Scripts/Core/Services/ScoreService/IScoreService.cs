namespace Core.Services.ScoreService
{
    public interface IScoreService
    {
        public int MaxScore { get; }
        public int CurrentScore { get; }
        public void AddScore(int value);
    }
}