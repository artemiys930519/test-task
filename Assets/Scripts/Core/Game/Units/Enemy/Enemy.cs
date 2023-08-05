using System.Diagnostics;
using Core.Enums;
using Core.Events.Model;
using Core.Game.Systems;
using Core.Game.Units.Enemy.UI;
using Core.Infractructure.StateMachine;
using Core.Infractructure.StateMachine.States;
using Core.Logic;
using Core.Services.InteractService;
using Core.Services.SceneRepository;
using Core.Services.ScoreService;
using UnityEngine;
using Zenject;

namespace Core.Game.Units.Enemy
{
    public class Enemy : MonoBehaviour, IInteractService
    {
        #region Inspector

        [SerializeField] private float _interactCount = 3f;
        [SerializeField] private MovementSystem _movementSystem;
        [SerializeField] private EnemyUI _enemyUI;
        [SerializeField] private TriggerObserver _triggerObserver;

        #endregion

        private StateMachine _stateMachine;
        private IScoreService _scoreService;
        private ISceneRepository _sceneRepository;
        private SignalBus _signalBus;

        private Stopwatch _interactTimer = new Stopwatch();
        private bool _isInteract = false;

        [Inject]
        private void Construct(SignalBus signalBus, StateMachine stateMachine, IScoreService scoreService,
            ISceneRepository sceneRepository)
        {
            _signalBus = signalBus;
            _stateMachine = stateMachine;
            _scoreService = scoreService;
            _sceneRepository = sceneRepository;
        }

        private void OnEnable()
        {
            _enemyUI.SetPlayer(_sceneRepository.PlayerGameObject.transform);

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

            _enemyUI.ShowUIPanel(Enumenators.EnemyUIPanel.ProccessPanel);
            _enemyUI.InteractProccess(_interactTimer.Elapsed.Seconds, _interactCount);

            if (_interactTimer.Elapsed.Seconds >= _interactCount)
            {
                _enemyUI.SetDescriptionText("Обижено ходит");
                _enemyUI.ShowUIPanel(Enumenators.EnemyUIPanel.ResultPanel);

                _scoreService.AddScore(1);
                _signalBus.Fire<RaiseEnemySignal>();

                _isInteract = true;
            }
        }

        public void StartInteract()
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

        public void EndInteract()
        {
            Enumenators.EnemyUIPanel tempPanelType = _isInteract
                ? Enumenators.EnemyUIPanel.ResultPanel
                : Enumenators.EnemyUIPanel.Unknown;

            _enemyUI.ShowUIPanel(tempPanelType);
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