using UnityEngine;

namespace BattleTank.PlayerTank
{
    public class PlayerController : IDamagable
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
        public GameObject GetGameObject()
        {
            return PlayerView.gameObject;
        }
        public int GiveDamage( )
        {
            return PlayerModel.Attack;
        }
        public void TakeDamage( int damage )
        {
            int health = PlayerModel.Health - damage;
            health = health >= 0 ? health : 0;
            PlayerModel.SetHealth( health );
        }
        public void Death( )
        {
            PlayerView.gameObject.SetActive( false );
        }
        private void GetReferences( )
        {
            playerTransform = PlayerView.transform;
            playerRigidBody = PlayerView.GetPlayerRigidBody( );
        }
    }
}

