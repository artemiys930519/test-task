using UnityEngine;

namespace Core.Game.Systems
{
    public class MovementSystem : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private Camera _lookCamera;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _rotationSpeed = 0.5f;

        #endregion

        public void Move(Vector2 input)
        {
            Vector3 moveDirection = transform.TransformDirection(new Vector3(input.x, 0, input.y));
            moveDirection *= _speed;
            _characterController.Move(moveDirection * Time.deltaTime);

            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }

        public void Rotate(Vector2 value)
        {
            float xRot = value.x * _rotationSpeed;
            float yRot = value.y * _rotationSpeed;

            transform.localRotation *= Quaternion.Euler(0f, xRot, 0f);

            _lookCamera.transform.localRotation *=
                Quaternion.Euler(-yRot, 0f, 0f);

            _lookCamera.transform.localRotation =
                ClampRotationAroundXAxis(_lookCamera.transform.localRotation);
        }


        Quaternion ClampRotationAroundXAxis(Quaternion q)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;
            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
            angleX = Mathf.Clamp(angleX, -90f, 90f);
            q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);
            return q;
        }
    }
}