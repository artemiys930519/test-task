using Core.Enums;
using Core.Services.PauseService;
using Core.Services.SceneRepository;
using Core.UI.Panels;
using UnityEngine;

namespace Core.Infractructure.StateMachine.States
{
    public class EndState : IPayloadedState<Enumenators.ScenarioEndType>
    {
        private ISceneRepository _sceneRepository;

        public EndState(ISceneRepository sceneRepository)
        {
            _sceneRepository = sceneRepository;
        }

        public void Exit()
        {
        }

        public void Enter(Enumenators.ScenarioEndType state)
        {
            Cursor.visible = true;
            
            foreach (GameObject enemyGameObject in _sceneRepository.EnemiesGameObjects)
            {
                if (enemyGameObject.TryGetComponent(out IPauseService enemyPauseService))
                {
                    enemyPauseService.Pause();
                }
            }

            GameObject tempPlayer = _sceneRepository.PlayerGameObject;
            if (tempPlayer.TryGetComponent(out IPauseService playerPauseService))
            {
                playerPauseService.Pause();
            }

            MainPanel tempMainPanel = _sceneRepository.MainPanel;

            if (tempMainPanel != null)
            {
                tempMainPanel.ShowViewPanel(Enumenators.PanelType.ResultPanel);
                tempMainPanel.ResultState(state);
            }
        }
    }
}