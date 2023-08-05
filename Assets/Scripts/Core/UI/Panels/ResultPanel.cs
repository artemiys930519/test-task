using Core.Services.ScoreService;
using TMPro;
using UnityEngine;
using Zenject;

namespace Core.UI.Panels
{
    public class ResultPanel : ViewPanel
    {
        #region Inspector

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
            _scoreValue.text = $"{_scoreService.CurrentScore}/{_scoreService.MaxScore}";
        }
    }
}