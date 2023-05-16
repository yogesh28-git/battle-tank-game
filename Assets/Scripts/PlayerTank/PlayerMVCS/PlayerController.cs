using UnityEngine;

namespace BattleTank.PlayerTank
{
    public class PlayerController
    {
        public PlayerModel PlayerModel { get; private set; }
        public PlayerView PlayerView { get; private set; }

        private Rigidbody playerRigidBody;
        private Transform playerTransform;

        public PlayerController( PlayerModel _playerModel, PlayerView _playerView )
        {
            PlayerView = _playerView;
            PlayerModel = _playerModel;

            PlayerView.SetPlayerController( this );

            GetReferences( );
        }
        public void Move( float vertical )
        {
            float moveSpeed = PlayerModel.MoveSpeed;
            playerRigidBody.AddRelativeForce( Vector3.forward * moveSpeed * vertical );
        }
        public void Rotate( float horizontal )
        {
            float turnSpeed = PlayerModel.TurnSpeed;
            playerTransform.Rotate( 0, horizontal * turnSpeed * Time.deltaTime, 0 );
        }
        private void GetReferences( )
        {
            playerTransform = PlayerView.transform;
            playerRigidBody = PlayerView.GetPlayerRigidBody( );
        }
    }
}

