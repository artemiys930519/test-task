using Core.UI.Panels;
using ScriptableObjects;
using UnityEngine;

namespace Core.Services.SceneRepository
{
    public class SceneRepository : ISceneRepository
    {
        public ScenarioData ScenarioData => _scenarioData;

        public GameObject PlayerGameObject => _playerGameObject;
        public GameObject[] EnemiesGameObjects => _enemiesGameObject;

        public MainPanel MainPanel => _mainPanel;

        private MainPanel _mainPanel;
        private GameObject _playerGameObject;
        private GameObject[] _enemiesGameObject;

        private ScenarioData _scenarioData;

        public SceneRepository(ScenarioData scenarioData)
        {
            _scenarioData = scenarioData;
        }

        public void RegisterMainUiPanel(MainPanel mainPanel)
        {
            _mainPanel = mainPanel;
        }

        public void RegisterPlayer(GameObject playerGameObject)
        {
            _playerGameObject = playerGameObject;
        }

        public void RegisterEnemies(GameObject[] enemiesGameObject)
        {
            _enemiesGameObject = enemiesGameObject;
        }
    }
}