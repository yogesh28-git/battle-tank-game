using UnityEngine;

namespace BattleTank.PlayerTank
{
    public class PlayerController
    {
        public PlayerModel PlayerModel { get; private set; }
        public PlayerView PlayerView { get; private set; }

        private Rigidbody playerRigidBody;
        private Transform playerTransform;
        private float moveSpeed;
        private float rotationAmount;

        public PlayerController( PlayerModel _playerModel, PlayerView _playerView )
        {
            PlayerView = _playerView;
            PlayerModel = _playerModel;

            PlayerView.SetTankController( this );

            GetReferences( );
        }
        public void Move( bool forwardInput, bool backwardInput )
        {
            if ( forwardInput )
                playerRigidBody.AddRelativeForce( Vector3.forward * moveSpeed * Time.deltaTime );
            else if ( backwardInput )
                playerRigidBody.AddRelativeForce( Vector3.back * moveSpeed * Time.deltaTime );
        }
        public void Rotate( bool leftInput, bool rightInput )
        {
            if ( leftInput )
                playerTransform.Rotate( 0, -rotationAmount * Time.deltaTime, 0 );
            if ( rightInput )
                playerTransform.Rotate( 0, rotationAmount * Time.deltaTime, 0 );
        }
        private void GetReferences( )
        {
            playerTransform = PlayerView.transform;
            playerRigidBody = PlayerView.GetPlayerRigidBody( );
            moveSpeed = PlayerModel.MoveSpeed;
            rotationAmount = PlayerModel.rotationAmount;
        }
    }
}

