using Core.UI.Panels;
using UnityEngine;

namespace Core.Services.SceneRepository
{
    public interface ISceneRepository
    {
        public GameObject PlayerGameObject { get; }
        public GameObject[] EnemiesGameObjects { get; }

        public MainPanel MainPanel { get; }

        public void RegisterMainUiPanel(MainPanel mainPanel);

        public void RegisterPlayer(GameObject playerGameObject);

        public void RegisterEnemies(GameObject[] enemiesGameObject);
    }
}