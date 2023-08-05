using Core.Services.ScoreService;
using TMPro;
using UnityEngine;
using Zenject;

namespace Core.UI.Panels
{
    public class ResultPanel : ViewPanel
    {
        private const string FailResult = "К сожалению вы проиграли";
        private const string SuccesResult = "Вы успешно справились с заданием";

        #region Inspector

        [SerializeField] private TMP_Text _resultText;
        [SerializeField] private TMP_Text _scoreValue;

        #endregion

        private IScoreService _scoreService;

        [Inject]
        private void Contruct(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        public override void ShowPanel()
        {
            FillResultScore();
            base.ShowPanel();
        }

        private void FillResultScore()
        {
            _resultText.text = _scoreService.CurrentScore < _scoreService.MaxScore ? FailResult : SuccesResult;
            _scoreValue.text = $"{_scoreService.CurrentScore}/{_scoreService.MaxScore}";
        }
    }
}