using UnityEngine;

namespace Core.Infractructure.Factory
{
    public interface IFactory
    {
        public GameObject CreateUI();
        public void CreateEnemies();

        public GameObject CreatePlayer();
    }
}