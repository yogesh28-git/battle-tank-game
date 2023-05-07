using UnityEngine;
using BattleTank.PlayerTank;

namespace BattleTank
{
    public class FPCameraFollow : MonoBehaviour
    {
        [SerializeField] private PlayerService playerService;

        private Transform player;

        private void Start( )
        {
            player = playerService.PlayerController.PlayerView.transform;
            Debug.Log( " ", player );
        }

        private void LateUpdate( )
        {
            transform.rotation = player.rotation;
            transform.position = player.position;
        }
    }

}
