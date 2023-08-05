using Core.UI.Panels;

namespace Core.Services.SceneRepository
{
    public class SceneRepository : ISceneRepository
    {
        private MainPanel _mainPanel;
        
        public void RegisterMainUiPanel(MainPanel mainPanel)
        {
            _mainPanel = mainPanel;
        }

        public MainPanel GetMainPanel()
        {
            return _mainPanel;
        }
    }    
}
