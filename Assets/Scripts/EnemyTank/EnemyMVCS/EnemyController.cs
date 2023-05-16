using UnityEngine;
using BattleTank.PlayerTank;
using BattleTank.Bullets;

namespace BattleTank.EnemyTank
{
    public class EnemyController
    {
        public EnemyModel EnemyModel { get; private set; }
        public EnemyView EnemyView { get; private set; }

        private Vector3 targetPos;
        private PlayerView playerRef;
        private float speed;
        private Transform shootPoint;

        public EnemyController(EnemyModel _enemyModel, EnemyView _enemyView, PlayerView _playerRef )
        {
            this.EnemyModel = _enemyModel;
            this.EnemyView = _enemyView;
            this.playerRef = _playerRef;

            this.EnemyView.SetTankController( this );
            this.EnemyView.SetPlayer( playerRef );
            this.shootPoint = EnemyView.GetShootPoint( );
            this.speed = EnemyModel.MoveSpeed;
        }
        public void SetInitialPosition( )
        {
            EnemyView.transform.position = EnemyModel.GetStartingPoint( );
        }
        public void ResetPatrolPoints()
        {
            EnemyModel.UpdateStartingPoint( );
            this.targetPos = EnemyModel.GetStartingPoint( );
        }
        public void EnemyPatrol()
        {
            if ( ( EnemyView.transform.position - targetPos ).sqrMagnitude < 1 )
            {
                ResetPatrolPoints( );
            }
            Vector3 currentPos = EnemyView.transform.position;

            Vector3 newEnemyPos = Vector3.MoveTowards( currentPos, targetPos, speed * Time.deltaTime );
            EnemyView.transform.LookAt( targetPos );

            EnemyView.transform.position = newEnemyPos;
        }

        public void ChaseThePlayer( )
        {
            Vector3 playerPos = playerRef.transform.position;
            Vector3 enemyPos = EnemyView.transform.position;

            Vector3 newEnemyPos = Vector3.MoveTowards( enemyPos, playerPos, speed * Time.deltaTime );
            EnemyView.transform.LookAt( playerPos );

            EnemyView.transform.position = newEnemyPos;
        }

        public float AttackThePlayer(float timer, float delay)
        {
            Vector3 playerPos = playerRef.transform.position;
            EnemyView.transform.LookAt( playerPos );
            if ( timer > delay )
            {
                BulletService.Instance.Shoot( EnemyView.gameObject, this.shootPoint );
                return 0;
            }
            return timer + Time.deltaTime;
        }
    }
}
