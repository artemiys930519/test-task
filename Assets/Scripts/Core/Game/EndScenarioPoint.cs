using Core.Infractructure.StateMachine;
using Core.Infractructure.StateMachine.States;
using Core.Logic;
using Core.Services.ScoreService;
using UnityEngine;
using Zenject;

namespace Core.Game
{
    public class EndScenarioPoint : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private TriggerObserver _triggerObserver;

        #endregion

        private IScoreService _scoreService;
        private StateMachine _stateMachine;

        [Inject]
        private void Construct(StateMachine stateMachine, IScoreService scoreService)
        {
            _scoreService = scoreService;
            _stateMachine = stateMachine;
        }

        private void OnEnable()
        {
            _triggerObserver.TriggerEnter += OnEndPointEnter;
        }

        private void OnDisable()
        {
            _triggerObserver.TriggerEnter -= OnEndPointEnter;
        }

        private void OnEndPointEnter()
        {
            _stateMachine.Enter<EndState, bool>(_scoreService.CurrentScore == _scoreService.MaxScore);
        }
    }
}