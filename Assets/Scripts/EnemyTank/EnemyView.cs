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

        private IEnemyState currentState;
        private EnemyStatePatrol patrolState;
        private EnemyStateChase chaseState;
        private EnemyStateAttack attackState;

        private float playerSqrDistance;
        private float chaseSqrRadius = 225f;
        private float attackSqrRadius = 81f;

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
            patrolState = new EnemyStatePatrol( this.enemyController );
            chaseState = new EnemyStateChase( this.enemyController );
            attackState = new EnemyStateAttack( this.enemyController );
            
            currentState = patrolState;
        }
        private void Update( )
        {
            currentState.OnStateUpdate( );

            CheckStateChanges( );  
        }

        private void CheckStateChanges( )
        {
            playerSqrDistance = ( this.transform.position - player.transform.position ).sqrMagnitude;

            if ( playerSqrDistance < attackSqrRadius && currentState.GetState( ) != TankStates.ATTACK_STATE )
            {
                ChangeState( attackState );
            }
            else if ( playerSqrDistance < chaseSqrRadius && currentState.GetState( ) != TankStates.CHASE_STATE )
            {
                ChangeState( chaseState );
            }
            else if ( currentState.GetState( ) != TankStates.PATROL_STATE )
            {
                ChangeState( patrolState );
            }
        }
        private void ChangeState( IEnemyState newState )
        {
            currentState.OnStateExit( );
            currentState = newState;
            currentState.OnStateEnter( );
        }
    }
}
