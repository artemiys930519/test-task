using Core.Enums;
using UnityEngine;

namespace Core.Services.PointRegisterService
{
    public interface IPointRegisterService
    {
        public void RegisterSpawnPoint(Enumenators.PointType pointType, Transform pointTransform);
        public Transform[] GetAllPointByType(Enumenators.PointType pointType);
    }
}