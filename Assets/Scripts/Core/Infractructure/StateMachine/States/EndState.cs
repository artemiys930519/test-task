using Core.Enums;
using Core.Services.SceneRepository;
using Core.UI.Panels;

namespace Core.Infractructure.StateMachine.States
{
    public class EndState : IPayloadedState<bool>
    {
        private ISceneRepository _sceneRepository;

        public EndState(ISceneRepository sceneRepository)
        {
            _sceneRepository = sceneRepository;
        }

        public void Exit()
        {
        }

        public void Enter(bool state)
        {
            MainPanel tempMainPanel = _sceneRepository.MainPanel;

            if (tempMainPanel != null)
            {
                tempMainPanel.ShowViewPanel(Enumenators.PanelType.ResultPanel);
                tempMainPanel.ResultState(state);
            }
        }
    }
}