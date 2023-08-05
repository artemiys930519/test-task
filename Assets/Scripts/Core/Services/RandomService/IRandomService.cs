using UnityEngine;

namespace Core.Services.RandomService
{
    public interface IRandomService
    {
        public Transform GetRandomDestinationPoint();
    }
}