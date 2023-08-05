using Core.UI.Panels;
using UnityEngine;

namespace Core.Services.SceneRepository
{
    public class SceneRepository : ISceneRepository
    {
        public GameObject PlayerGameObject => _playerGameObject;
        
        public MainPanel MainPanel => _mainPanel;

        private MainPanel _mainPanel;
        private GameObject _playerGameObject;

        public void RegisterMainUiPanel(MainPanel mainPanel)
        {
            _mainPanel = mainPanel;
        }

        public void RegisterPlayer(GameObject playerGameObject)
        {
            _playerGameObject = playerGameObject;
        }
    }
}