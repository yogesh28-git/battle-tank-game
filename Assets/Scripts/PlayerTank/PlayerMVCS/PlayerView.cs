using UnityEngine;
using System;
using BattleTank.EnemyTank;
using BattleTank.Bullets;
using System.Collections;

namespace BattleTank.PlayerTank
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Rigidbody playerRigidBody;
        [SerializeField] private ParticleSystem tankExplosion;
        [SerializeField] private Transform shootPoint;

        private PlayerController playerController;

        private int bulletCount = 0;
        
        private float verticalInput;
        private float horizontalInput;
        private bool fireInput = false;

        public static event Action<int> OnAchievementUnlock;

        public void SetPlayerController( PlayerController _playerController )
        {
            this.playerController = _playerController;
        }
        public Rigidbody GetPlayerRigidBody( )
        {
            return this.playerRigidBody;
        }
        public void Death( GameObject enemy )
        {
            //implement this
        }

        private void Update( )
        {
            HandleInputs( );

            playerController.Rotate( horizontalInput );
            if ( fireInput )
            {
                BulletService.Instance.Shoot( this.gameObject, this.shootPoint);
                bulletCount++;
                CheckForAchievement( bulletCount );
            }
        }
        private void FixedUpdate( )
        {
            playerController.Move( verticalInput );
        }
        private void HandleInputs( )
        {
            fireInput = Input.GetKeyDown( KeyCode.Space );
            verticalInput = Input.GetAxis( "Vertical1" );
            horizontalInput = Input.GetAxis( "Horizontal1" );
        }

        private void CheckForAchievement( int bullets )
        {
            if ( bullets == 10 || bullets == 25 || bullets == 50 )
            {
                OnAchievementUnlock?.Invoke( bullets );
            }
        }
        
    }
}

