using Core.Enums;
using Core.Services.SceneRepository;
using Core.UI.Panels;

namespace Core.Infractructure.StateMachine.States
{
    public class EndState : IState
    {
        private ISceneRepository _sceneRepository;

        public EndState(ISceneRepository sceneRepository)
        {
            _sceneRepository = sceneRepository;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            MainPanel tempMainPanel = _sceneRepository.MainPanel;

            if (tempMainPanel != null)
                tempMainPanel.ShowViewPanel(Enumenators.PanelType.ResultPanel);
        }
    }
}