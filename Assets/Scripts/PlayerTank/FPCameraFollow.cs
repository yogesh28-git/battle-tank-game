using UnityEngine;

namespace BattleTank.PlayerTank
{
    public class FPCameraFollow : MonoBehaviour
    {
        private Transform player;

        private void Start( )
        {
            player = PlayerService.Instance.PlayerController.PlayerView.transform;
        }

        private void LateUpdate( )
        {
            transform.rotation = player.rotation;
            transform.position = player.position;
        }
    }

}
