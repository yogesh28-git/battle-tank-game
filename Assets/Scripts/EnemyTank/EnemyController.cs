using UnityEngine;

namespace BattleTank.EnemyTank
{
    public class EnemyController
    {
        private EnemyModel enemyModel;
        private EnemyView enemyView;

        private PatrolPointScriptableObject startingPoint;
        private PatrolPointScriptableObject targetPoint;
        private Vector3 enemyFacingDirection;
        private float speed = 5f;

        public EnemyController(EnemyModel _enemyModel, EnemyView _enemyView )
        {
            this.enemyModel = _enemyModel;
            this.enemyView = _enemyView;

            this.enemyModel.SetTankController( this );
            this.enemyView.SetTankController( this );
        }

        public void ResetPatrolPoints()
        {
            this.startingPoint = enemyModel.GetStartingPoint( );
            int randNeighbourIndex = ( int ) Random.Range( 0, startingPoint.NeighbourPoints.Length );
            this.targetPoint = startingPoint.NeighbourPoints[randNeighbourIndex];
            enemyModel.SetStartingPoint( targetPoint );
            enemyFacingDirection = ( targetPoint.Position - startingPoint.Position ).normalized;
            enemyView.transform.LookAt( targetPoint.Position );
        }
        public void EnemyPatrol()
        {
            if ( ( enemyView.transform.position - targetPoint.Position ).sqrMagnitude < 1 )
            {
                ResetPatrolPoints( );
            }
            enemyView.transform.position += enemyFacingDirection * speed * Time.deltaTime;
        }
    }
}
