using UnityEngine;
using BattleTank.PlayerTank;
using System.Collections;

namespace BattleTank.EnemyTank
{
    public class EnemyView : MonoBehaviour
    {

        [SerializeField] private ParticleSystem deathEffect;
        [SerializeField] private Transform shootPoint;

        private PlayerView player;
        private EnemyController enemyController;

        private IEnemyState currentState;
        private EnemyStatePatrol patrolState;
        private EnemyStateChase chaseState;
        private EnemyStateAttack attackState;

        private float playerSqrDistance;
        private float chaseSqrRadius = 900f;
        private float attackSqrRadius = 100f;

        public void SetTankController( EnemyController _enemyController )
        {
            this.enemyController = _enemyController;
        }
        public void SetPlayer(PlayerView player)
        {
            this.player = player;
        }
        public Transform GetShootPoint( )
        {
            return shootPoint;
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

            if ( playerSqrDistance < attackSqrRadius)
            {
                if(currentState.GetState( ) != TankStates.ATTACK_STATE )
                    ChangeState( attackState );
            }
            else if ( playerSqrDistance < chaseSqrRadius)
            {
                if( currentState.GetState( ) != TankStates.CHASE_STATE )
                    ChangeState( chaseState );
            }
            else
            {   
                if ( currentState.GetState( ) != TankStates.PATROL_STATE )
                    ChangeState( patrolState );
            }
        }
        private void ChangeState( IEnemyState newState )
        {
            currentState.OnStateExit( );
            currentState = newState;
            Debug.Log( "State : " + currentState.GetState( ) );
            currentState.OnStateEnter( );
        }
    }
}
