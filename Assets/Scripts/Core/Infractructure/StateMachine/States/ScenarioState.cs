using Core.Enums;
using Core.Services.SceneRepository;

namespace Core.Infractructure.StateMachine.States
{
    public class ScenarioState : IState
    {
        private ISceneRepository _sceneRepository;
        public ScenarioState(ISceneRepository sceneRepository)
        {
            _sceneRepository = sceneRepository;
        }

        public void Exit()
        {
            
        }

        public void Enter()
        {
            _sceneRepository.GetMainPanel().ShowPanel();
            _sceneRepository.GetMainPanel().ShowViewPanel(Enumenators.PanelType.ScorePanel);
        }
    }
}

