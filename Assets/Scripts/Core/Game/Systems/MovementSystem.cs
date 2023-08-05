using UnityEngine;

namespace Core.Game.Systems
{
    public class MovementSystem : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _rotationSpeed = 30;

        #endregion

        private float currentRotation = 0f;

        public void Move(Vector2 input)
        {
            Vector3 moveDirection = transform.TransformDirection(new Vector3(input.x, 0, input.y));
            moveDirection *= _speed;
            _characterController.Move(moveDirection * Time.deltaTime);
        }

        public void Rotate(Vector2 value)
        {
            float rotationAmount = value.x * _rotationSpeed * Time.deltaTime;
            currentRotation += rotationAmount;
            transform.rotation = Quaternion.Euler(0f, currentRotation, 0f);
        }
    }
}