using UnityEngine;

namespace Core.Services.InputService
{
    public interface IInputService
    {
        public Vector2 GetMovementValue();
        public Vector2 GetRotationValue();
    }
}