using Core.Services.InteractService;
using UnityEngine;

namespace Core.Services.InteractionService
{
    public class PhysicsRaycastInteractionService : IInteractionService
    {
        private LayerMask _mask = LayerMask.GetMask("Enemy");
        private Ray _rayOrigin;
        private RaycastHit _hitInfo;
        private Camera _interactCamera;

        public void Init()
        {
            _interactCamera = Camera.main;
        }

        public bool TryGetInteractObject(out IInteractService interactService)
        {
            if (Physics.Raycast(_interactCamera.transform.position, _interactCamera.transform.forward, out _hitInfo,
                    100.0f, _mask))
            {
                Debug.DrawRay(_interactCamera.transform.position, _interactCamera.transform.forward * 100,
                    Color.yellow);
                if (_hitInfo.transform.TryGetComponent(out IInteractService interact))
                {
                    interactService = interact;
                    return true;
                }

                interactService = null;
                return true;
            }

            interactService = null;
            return false;
        }
    }
}