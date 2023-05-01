using UnityEngine;

namespace BattleTank.EnemyTank
{
    public class EnemyView : MonoBehaviour
    {
        private enum EnemyState
        {
            Patrol = 0,
            Shooting = 1
        };
        private EnemyController enemyController;
        private EnemyState enemyState = EnemyState.Patrol;

        public void SetTankController( EnemyController _enemyController )
        {
            this.enemyController = _enemyController;
        }
        

        private void Start( )
        {
            enemyController.ResetPatrolPoints( );
        }
        private void Update( )
        {
            enemyController.EnemyPatrol( );
        } 
    }
}
