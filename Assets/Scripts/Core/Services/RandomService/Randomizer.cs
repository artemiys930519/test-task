using Core.Enums;
using Core.Services.PointRegisterService;
using Core.Services.SceneRepository;
using UnityEngine;

namespace Core.Services.RandomService
{
    public class Randomizer : IRandomService
    {
        private IPointRegisterService _pointRegisterService;
        private ISceneRepository _sceneRepository;

        private int _requestCount = 0;

        private Randomizer(IPointRegisterService pointRegisterService, ISceneRepository sceneRepository)
        {
            _pointRegisterService = pointRegisterService;
            _sceneRepository = sceneRepository;
        }

        public Transform GetRandomDestinationPoint()
        {
            _requestCount++;
            Transform destination = null;

            if (_requestCount % 5 == 0)
            {
                if (_sceneRepository.PlayerGameObject != null)
                    destination = _sceneRepository.PlayerGameObject.transform;
            }
            else
            {
                Transform[] movingPoints = _pointRegisterService.GetAllPointByType(Enumenators.PointType.EnemyPoint);
                if (movingPoints.Length > 0)
                    destination = movingPoints[Random.Range(0, movingPoints.Length)];
            }

            return destination;
        }
    }
}