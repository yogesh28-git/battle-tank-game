using UnityEngine;

namespace BattleTank.EnemyTank
{
    public class EnemyView : MonoBehaviour
    {
        private EnemyController enemyController;

        public void SetTankController( EnemyController _enemyController )
        {
            this.enemyController = _enemyController;
        }
        private void Start( )
        {
            enemyController.SetInitialPosition( );
            enemyController.ResetPatrolPoints( );
        }
        private void Update( )
        {
            enemyController.EnemyPatrol( );
        } 
    }
}
