using UnityEngine;

namespace Core.Infractructure.Factory
{
    public interface IFactory
    {
        public GameObject CreateUI();
        public GameObject[] CreateEnemies();

        public GameObject CreatePlayer();
    }
}