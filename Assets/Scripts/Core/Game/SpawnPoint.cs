using Core.Enums;
using Core.Services.PointRegisterService;
using UnityEngine;
using Zenject;

namespace Core.Game
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private Enumenators.PointType _pointType;
        
        [Inject]
        private void Construct(IPointRegisterService pointRegisterService)
        {
            pointRegisterService.RegisterSpawnPoint(_pointType, transform);
        }
    }
}