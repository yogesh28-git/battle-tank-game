using UnityEngine;

namespace BattleTank.PlayerTank
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Rigidbody playerRigidBody;
        [SerializeField] private BulletShooter bulletShooter;

        private PlayerController playerController;
        private bool forwardInput = false;
        private bool backwardInput = false;
        private bool leftInput = false;
        private bool rightInput = false;
        private bool fireInput = false;

        public void SetTankController( PlayerController _playerController )
        {
            this.playerController = _playerController;
        }
        public Rigidbody GetPlayerRigidBody( )
        {
            return this.playerRigidBody;
        }
        private void InputHandler( )
        {
            forwardInput = Input.GetKey( KeyCode.W );
            backwardInput = Input.GetKey( KeyCode.S );
            leftInput = Input.GetKey( KeyCode.A );
            rightInput = Input.GetKey( KeyCode.D );
            fireInput = Input.GetKeyDown( KeyCode.Space );
        }
        private void Update( )
        {
            InputHandler( );

            playerController.Move( forwardInput, backwardInput );
            playerController.Rotate( leftInput, rightInput );
            if ( fireInput )
            {
                this.bulletShooter.Shoot( );
            }
        }
    }
}

