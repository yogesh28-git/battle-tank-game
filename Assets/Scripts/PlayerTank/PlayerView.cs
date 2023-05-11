using UnityEngine;
using System;
using BattleTank.EnemyTank;
using System.Collections;

namespace BattleTank.PlayerTank
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Rigidbody playerRigidBody;
        [SerializeField] private ParticleSystem deathEffect;
        [SerializeField] private BulletShooter bulletShooter;
        [SerializeField] private GameObject tankRenderer;

        private GameObject[] artModelsList;

        private PlayerController playerController;
        private bool forwardInput = false;
        private bool backwardInput = false;
        private bool leftInput = false;
        private bool rightInput = false;
        private bool fireInput = false;

        private int bulletCount = 0;

        public static event Action<int> OnAchievementUnlock;

        public void SetTankController( PlayerController _playerController )
        {
            this.playerController = _playerController;
        }
        public Rigidbody GetPlayerRigidBody( )
        {
            return this.playerRigidBody;
        }
        public void Death( GameObject enemy )
        {
            StartCoroutine( DestroyEverything( enemy ) );
        }
        public void SetArtModelsList( GameObject[] artModelsList )
        {
            this.artModelsList = artModelsList;
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
                bulletCount++;
                CheckForAchievement( bulletCount );
            }
        }
        private void CheckForAchievement( int bullets )
        {
            if ( bullets == 10 || bullets == 25 || bullets == 50 )
            {
                OnAchievementUnlock?.Invoke( bullets );
            }
        }
        private IEnumerator DestroyEverything( GameObject enemy )
        {
            this.deathEffect.Play( );
            yield return new WaitForSeconds( 0.3f );
            this.tankRenderer.SetActive( false );

            yield return new WaitForSeconds( 1f );

            enemy.GetComponent<EnemyView>( ).Death( );
            yield return new WaitForSeconds( 0.3f );
            Destroy( enemy.gameObject );

            yield return new WaitForSeconds( 1.5f );
            for ( int i = 0; i < artModelsList.Length; i++ )
            {
                Destroy( artModelsList[i] );
                yield return new WaitForSeconds( 1f );
            }

            this.gameObject.SetActive( false );
        }
    }
}

