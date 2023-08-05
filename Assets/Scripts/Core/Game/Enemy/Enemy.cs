using System.Diagnostics;
using Core.Events.Model;
using Core.Game.Player.UI;
using Core.Game.Systems;
using Core.Infractructure.StateMachine;
using Core.Infractructure.StateMachine.States;
using Core.Logic;
using Core.Services.ScoreService;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Core.Game.Player
{
    public class Enemy : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        #region Inspector

        [SerializeField] private float _interactCount = 3f;
        [SerializeField] private MovementSystem _movementSystem;
        [SerializeField] private EnemyUI _enemyUI;
        [SerializeField] private TriggerObserver _triggerObserver;

        #endregion

        private StateMachine _stateMachine;
        private IScoreService _scoreService;
        private SignalBus _signalBus;

        private Stopwatch _interactTimer = new Stopwatch();
        private bool _isInteract = false;

        [Inject]
        private void Construct(SignalBus signalBus, StateMachine stateMachine, IScoreService scoreService)
        {
            _signalBus = signalBus;
            _stateMachine = stateMachine;
            _scoreService = scoreService;
        }

        private void OnEnable()
        {
            _triggerObserver.TriggerEnter += RaiseEndScenario;
        }

        private void OnDisable()
        {
            _triggerObserver.TriggerEnter -= RaiseEndScenario;
        }

        private void Update()
        {
            //_movementSystem.Move();
            //_movementSystem.Rotate();

            if (_isInteract)
                return;

            if (!_interactTimer.IsRunning)
                return;

            _enemyUI.ShowPanel();
            _enemyUI.InteractProccess(_interactTimer.Elapsed.Seconds, _interactCount);

            if (_interactTimer.Elapsed.Seconds >= _interactCount)
            {
                _scoreService.AddScore(1);
                _signalBus.Fire<RaiseEnemySignal>();

                _isInteract = true;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_isInteract)
                return;

            if (_interactTimer.IsRunning)
            {
                _interactTimer.Reset();
                _interactTimer.Restart();
            }
            else
            {
                _interactTimer.Start();
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _enemyUI.HidePanel();
            _interactTimer.Stop();
            _interactTimer.Reset();
        }

        private void RaiseEndScenario()
        {
            if (_isInteract)
                return;

            _scoreService.AddScore(-1);
            _stateMachine.Enter<EndState>();
        }
    }
}