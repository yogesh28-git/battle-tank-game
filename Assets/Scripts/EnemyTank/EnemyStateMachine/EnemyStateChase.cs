namespace BattleTank.EnemyTank
{
    public class EnemyStateChase : IEnemyState
    {
        private EnemyController enemyController;
        public EnemyStateChase( EnemyController _enemyController)
        {
            this.enemyController = _enemyController;
        }
        public void OnStateEnter( )
        {

        }

        public void OnStateUpdate( )
        {
            enemyController.ChaseThePlayer( );
        }

        public void OnStateExit( )
        {

        }

        public TankStates GetState( )
        {
            return TankStates.CHASE_STATE;
        }
    }
}

