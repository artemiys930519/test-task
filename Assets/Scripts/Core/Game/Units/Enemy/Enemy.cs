using System.Diagnostics;
using Core.Enums;
using Core.Events.Model;
using Core.Game.Units.Enemy.UI;
using Core.Infractructure.StateMachine;
using Core.Infractructure.StateMachine.States;
using Core.Logic;
using Core.Services.InteractService;
using Core.Services.PointRegisterService;
using Core.Services.RandomService;
using Core.Services.SceneRepository;
using Core.Services.ScoreService;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Core.Game.Units.Enemy
{
    public class Enemy : MonoBehaviour, IInteractService
    {
        #region Inspector

        [SerializeField] private float _interactCount = 3f;
        [SerializeField] private EnemyUI _enemyUI;
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private NavMeshAgent _navMeshAgent;

        #endregion

        private StateMachine _stateMachine;
        private IScoreService _scoreService;
        private ISceneRepository _sceneRepository;
        private IRandomService _randomService;
        private SignalBus _signalBus;

        private Stopwatch _interactTimer = new Stopwatch();
        private bool _isInteract = false;

        private Transform _currentMovingTransform;

        [Inject]
        private void Construct(SignalBus signalBus, StateMachine stateMachine, IScoreService scoreService,
            ISceneRepository sceneRepository, IRandomService randomService)
        {
            _signalBus = signalBus;
            _stateMachine = stateMachine;
            _scoreService = scoreService;
            _sceneRepository = sceneRepository;
            _randomService = randomService;
        }

        private void OnEnable()
        {
            _enemyUI.SetPlayer(_sceneRepository.PlayerGameObject.transform);
            _triggerObserver.TriggerEnter += RaiseFailScenario;

            Moving(_randomService.GetRandomDestinationPoint());
        }

        private void OnDisable()
        {
            _triggerObserver.TriggerEnter -= RaiseFailScenario;
        }

        private void Update()
        {
            MoveRandomPosition();

            if (_isInteract)
                return;

            if (!_interactTimer.IsRunning)
                return;

            _enemyUI.ShowUIPanel(Enumenators.EnemyUIPanel.ProcessPanel);
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

        private void MoveRandomPosition()
        {
            if (Vector3.Distance(transform.position, _currentMovingTransform.position) > 0.4f)
                Moving(_currentMovingTransform);
            else
                Moving(_randomService.GetRandomDestinationPoint());
        }

        private void Moving(Transform destinationPosition)
        {
            _currentMovingTransform = destinationPosition;

            _navMeshAgent.SetDestination(_currentMovingTransform.position);
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

        private void RaiseFailScenario()
        {
            if (_isInteract)
                return;

            _stateMachine.Enter<EndState, bool>(false);
        }
    }
}