using UnityEngine;

namespace BattleTank.EnemyTank
{
    public class EnemyController
    {
        public EnemyModel EnemyModel { get; private set; }
        public EnemyView EnemyView { get; private set; }

        private PatrolPointScriptableObject startingPoint;
        private PatrolPointScriptableObject targetPoint;
        private Vector3 enemyFacingDirection;
        private float speed = 5f;

        public EnemyController(EnemyModel _enemyModel, EnemyView _enemyView )
        {
            this.EnemyModel = _enemyModel;
            this.EnemyView = _enemyView;

            this.EnemyView.SetTankController( this );
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
    }
}
