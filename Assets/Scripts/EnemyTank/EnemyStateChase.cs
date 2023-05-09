namespace BattleTank.EnemyTank
{
    public class EnemyStateChase : IEnemyState
    {
        private EnemyView enemyView;
        private EnemyController enemyController;
        public EnemyStateChase( EnemyController _enemyController )
        {
            this.enemyController = _enemyController;
            this.enemyView = enemyController.EnemyView;
        }
        public void OnStateEnter( )
        {

        }

        public void OnStateUpdate( )
        {

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

