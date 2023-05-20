using UnityEngine;

namespace BattleTank.PlayerTank
{
    public class FPCameraFollow : MonoBehaviour
    {
        private Transform player;

        private static FPCameraFollow instance;

        private void Start( )
        {
            if(instance == null )
            {
                instance = this;
                DontDestroyOnLoad( this.gameObject );
            }
            else
            {
                Destroy( this.gameObject );
            }
        }

        private void LateUpdate( )
        {
            player = PlayerService.Instance.PlayerController.PlayerView.transform;
            transform.rotation = player.rotation;
            transform.position = player.position;
        }
    }

}
