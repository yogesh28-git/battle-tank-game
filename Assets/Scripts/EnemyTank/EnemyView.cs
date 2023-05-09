using UnityEngine;
using BattleTank.PlayerTank;
using System.Collections;

namespace BattleTank.EnemyTank
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem deathEffect;
        [SerializeField] private BulletShooter bulletShooter;

        private PlayerView player;

        private EnemyController enemyController;

        private bool isPlayerInRange = false;  //I will use states for enemy once I learn it.
        private bool isFiring = false;

        private IEnemyState currentState;
        private EnemyStateIdle idleState;
        private EnemyStatePatrol patrolState;
        private EnemyStateChase chaseState;
        private EnemyStateAttack attackState;

        public void SetTankController( EnemyController _enemyController )
        {
            this.enemyController = _enemyController;
        }
        public void SetPlayer(PlayerView player)
        {
            this.player = player;
        }
        public void Death( )
        {
            deathEffect.Play( );
        }
        private void Start( )
        {
            idleState = new EnemyStateIdle( this.enemyController );
            patrolState = new EnemyStatePatrol( this.enemyController );
            chaseState = new EnemyStateChase( this.enemyController );
            attackState = new EnemyStateAttack( this.enemyController );
            currentState = idleState;

            enemyController.SetInitialPosition( );
            enemyController.ResetPatrolPoints( );
        }
        private void Update( )
        {
            isPlayerInRange = ( this.transform.position - player.transform.position ).sqrMagnitude <= 100;
            if ( !isPlayerInRange )
            {
                enemyController.EnemyPatrol( );
            }
            else
            {
                transform.LookAt( player.transform.position );
                if ( !isFiring )
                {
                    StartCoroutine( ShootRepeating( 1f ) );
                    isFiring = true;
                }
            }
        }
        
        private IEnumerator ShootRepeating( float shootDelay)
        {
            while ( isPlayerInRange )
            {
                bulletShooter.Shoot( );
                yield return new WaitForSeconds( shootDelay );
            }
        }
    }
}
