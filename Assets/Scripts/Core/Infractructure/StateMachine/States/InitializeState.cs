using Core.Infractructure.Factory;
using Core.Services.InteractionService;
using Core.Services.SceneRepository;
using Core.UI.Panels;
using TMPro;
using UnityEngine;

namespace Core.Infractructure.StateMachine.States
{
    public class InitializeState : IState
    {
        private IFactory _factory;
        private StateMachine _stateMachine;
        private ISceneRepository _sceneRepository;
        private IInteractionService _interactionService;

        public InitializeState(StateMachine stateMachine, IFactory factory, ISceneRepository sceneRepository,
            IInteractionService interactionService)
        {
            _interactionService = interactionService;
            _sceneRepository = sceneRepository;
            _stateMachine = stateMachine;
            _factory = factory;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            Cursor.visible = false;

            GameObject tempPlayer = _factory.CreatePlayer();
            _sceneRepository.RegisterPlayer(tempPlayer);

            GameObject[] tempEnemies = _factory.CreateEnemies();
            _sceneRepository.RegisterEnemies(tempEnemies);

            GameObject tempUI = _factory.CreateUI();
            if (tempUI.TryGetComponent(out MainPanel mainPanel))
            {
                _sceneRepository.RegisterMainUiPanel(mainPanel);
            }

            _interactionService.Init();

            _stateMachine.Enter<ScenarioState>();
        }
    }
}