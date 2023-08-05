using UnityEngine;

namespace Core.Services.InteractionService
{
    public class PhysicsRaycastInteractionService : IInteractionService
    {
        Ray RayOrigin;
        RaycastHit HitInfo;

        public void TryInteract()
        {
            RayOrigin = Camera.main.ViewportPointToRay(new Vector3(0, 0, 0));

            if (Physics.Raycast(RayOrigin, out HitInfo, 100f))
            {
                Debug.DrawRay(RayOrigin.direction, HitInfo.point, Color.yellow);
            }
        }
    }
}