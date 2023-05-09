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
