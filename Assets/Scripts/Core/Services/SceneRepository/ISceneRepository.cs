using Core.UI.Panels;

namespace Core.Services.SceneRepository
{
    public interface ISceneRepository
    {
        public MainPanel GetMainPanel();
        public void RegisterMainUiPanel(MainPanel mainPanel);
    }    
}
