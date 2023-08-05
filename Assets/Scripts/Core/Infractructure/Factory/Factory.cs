using Core.Enums;
using Core.Services.PointRegisterService;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Core.Infractructure.Factory
{
    public class Factory : IFactory
    {
        private LevelData _levelData;
        private IPointRegisterService _pointRegisterService;

        private Transform[] _enemiesPoints;
        private Transform[] _playerPoints;

        private DiContainer _diContainer;

        private Factory(LevelData levelData, DiContainer diContainer, IPointRegisterService pointRegisterService)
        {
            _levelData = levelData;
            _diContainer = diContainer;
            _pointRegisterService = pointRegisterService;
        }

        public GameObject CreateUI()
        {
            if (_levelData.UIPrefab == null)
                return null;

            return _diContainer.InstantiatePrefab(_levelData.UIPrefab);
        }

        public GameObject[] CreateEnemies()
        {
            _enemiesPoints = _pointRegisterService.GetAllPointByType(Enumenators.PointType.EnemyPoint);

            if (_enemiesPoints == null || _enemiesPoints.Length == 0)
                return null;

            if (_levelData.EnemyPrefab == null)
                return null;

            GameObject[] tempGameObjects = new GameObject[_enemiesPoints.Length];

            for (int i = 0; i < _enemiesPoints.Length; i++)
            {
                GameObject tempEnemyPrefab = _diContainer.InstantiatePrefab(_levelData.EnemyPrefab);
                tempEnemyPrefab.transform.position = _enemiesPoints[i].transform.position;
                tempEnemyPrefab.transform.rotation = _enemiesPoints[i].transform.rotation;
                tempGameObjects[i] = tempEnemyPrefab;
            }

            return tempGameObjects;
        }

        public GameObject CreatePlayer()
        {
            _playerPoints = _pointRegisterService.GetAllPointByType(Enumenators.PointType.PlayerPoint);

            if (_playerPoints == null || _playerPoints.Length == 0)
                return null;

            if (_levelData.PlayerPrefab == null)
                return null;

            GameObject tempPlayerPrefab = _diContainer.InstantiatePrefab(_levelData.PlayerPrefab);
            tempPlayerPrefab.transform.position = _playerPoints[0].transform.position;
            tempPlayerPrefab.transform.rotation = _playerPoints[0].transform.rotation;

            return tempPlayerPrefab;
        }
    }
}