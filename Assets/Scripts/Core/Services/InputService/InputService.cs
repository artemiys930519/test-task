using UnityEngine;

namespace Core.Services.InputService
{
    public class InputService : IInputService
    {
        //Todo исправить на нормальное получение зависимости
        private PlayerInput _playerInput = new PlayerInput();
        
        public InputService()
        {
            _playerInput = new PlayerInput();
            _playerInput.Player.Move.Enable();
            _playerInput.Player.Look.Enable();
    
        }

        public Vector2 GetMovementValue()
        {
            return _playerInput.Player.Move.ReadValue<Vector2>();
        }

        public Vector2 GetRotationValue()
        {
            return _playerInput.Player.Look.ReadValue<Vector2>();
        }
    }
}