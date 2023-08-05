using Core.Infractructure.Factory;
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

        public InitializeState(StateMachine stateMachine, IFactory factory, ISceneRepository sceneRepository)
        {
            _sceneRepository = sceneRepository;
            _stateMachine = stateMachine;
            _factory = factory;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            _factory.CreateEnemies();
            _factory.CreatePlayer();
            GameObject tempUI = _factory.CreateUI();

            if (tempUI.TryGetComponent(out MainPanel mainPanel))
            {
                _sceneRepository.RegisterMainUiPanel(mainPanel);
            }

            _stateMachine.Enter<ScenarioState>();
        }
    }
}