namespace BattleTank.EnemyTank
{
    public class EnemyStateIdle : IEnemyState
    {
        private EnemyView enemyView;
        private EnemyController enemyController;
        public EnemyStateIdle( EnemyController _enemyController )
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
    }
}

