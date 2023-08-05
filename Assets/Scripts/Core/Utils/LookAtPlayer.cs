using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    #region Inspector

    [SerializeField] private float Damping;

    #endregion

    private Transform _player;

    void Update()
    {
        if (_player != null)
        {
            var playerPos = _player.position;
            RotateObject(playerPos);
        }
    }

    public void SetPlayer(Transform player)
    {
        _player = player;
    }

    private void RotateObject(Vector3 playerPos)
    {
        var lookPos = transform.position - playerPos;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            rotation,
            Time.deltaTime * Damping);
    }
}