using Core.Events.Model;
using Core.Services.ScoreService;
using TMPro;
using UnityEngine;
using Zenject;

namespace Core.UI.Panels
{
    public class ScoredPanel : ViewPanel
    {
        #region Inspector

        [SerializeField] private TMP_Text _scoreText;

        #endregion

        private IScoreService _scoreService;
        private SignalBus _signalBus;

        [Inject]
        private void Construct(SignalBus signalBus, IScoreService scoreService)
        {
            _signalBus = signalBus;
            _scoreService = scoreService;
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<RaiseEnemySignal>(RaiseEnemy);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<RaiseEnemySignal>(RaiseEnemy);
        }

        private void RaiseEnemy()
        {
            _scoreText.text = $"{_scoreService.CurrentScore} / {_scoreService.MaxScore}";
        }
    }
}