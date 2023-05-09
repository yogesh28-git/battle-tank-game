namespace BattleTank.EnemyTank
{
    public class EnemyStatePatrol : IEnemyState
    {
        private EnemyView enemyView;
        private EnemyController enemyController;
        public EnemyStatePatrol(EnemyController _enemyController)
        {
            this.enemyController = _enemyController;
            this.enemyView = enemyController.EnemyView;

            enemyController.SetInitialPosition( );
            enemyController.ResetPatrolPoints( );
        }
        public void OnStateEnter( )
        {
            enemyController.ResetPatrolPoints( );
        }

        public void OnStateUpdate( )
        {
            enemyController.EnemyPatrol( );
        }

        public void OnStateExit( )
        {

        }

        public TankStates GetState( )
        {
            return TankStates.PATROL_STATE;
        }
    }
}
