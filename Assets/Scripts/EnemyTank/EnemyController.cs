using UnityEngine;
using BattleTank.PlayerTank;

namespace BattleTank.EnemyTank
{
    public class EnemyController
    {
        public EnemyModel EnemyModel { get; private set; }
        public EnemyView EnemyView { get; private set; }

        private PatrolPointScriptableObject startingPoint;
        private PatrolPointScriptableObject targetPoint;
        private PlayerView playerRef;
        private Vector3 enemyFacingDirection;
        private float speed = 5f;
        private BulletShooter bulletShooter;

        public EnemyController(EnemyModel _enemyModel, EnemyView _enemyView, PlayerView _playerRef )
        {
            this.EnemyModel = _enemyModel;
            this.EnemyView = _enemyView;
            this.playerRef = _playerRef;

            this.EnemyView.SetTankController( this );
            this.EnemyView.SetPlayer( playerRef );
            this.bulletShooter = EnemyView.GetBulletShooter( );
        }
        public void SetInitialPosition( )
        {
            PatrolPointScriptableObject randPoint = EnemyModel.GetRandomPoint( );
            EnemyView.transform.position = randPoint.Position;
            EnemyModel.SetStartingPoint( randPoint );
        }
        public void ResetPatrolPoints()
        {
            this.startingPoint = EnemyModel.GetStartingPoint( );
            int randNeighbourIndex = ( int ) Random.Range( 0, startingPoint.NeighbourPoints.Length );
            this.targetPoint = startingPoint.NeighbourPoints[randNeighbourIndex];
            EnemyModel.SetStartingPoint( targetPoint );
            enemyFacingDirection = ( targetPoint.Position - startingPoint.Position ).normalized;
            EnemyView.transform.LookAt( targetPoint.Position );
        }
        public void EnemyPatrol()
        {
            if ( ( EnemyView.transform.position - targetPoint.Position ).sqrMagnitude < 1 )
            {
                ResetPatrolPoints( );
            }
            EnemyView.transform.position += enemyFacingDirection * speed * Time.deltaTime;
            EnemyView.transform.LookAt( targetPoint.Position );
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
                bulletShooter.Shoot( );
                return 0;
            }
            return timer + Time.deltaTime;
        }
    }
}
