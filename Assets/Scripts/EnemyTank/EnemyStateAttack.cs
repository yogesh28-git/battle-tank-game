namespace BattleTank.EnemyTank
{
    public class EnemyStateAttack : IEnemyState
    {
        private EnemyView enemyView;
        private EnemyController enemyController;
        public EnemyStateAttack( EnemyController _enemyController )
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
            return TankStates.ATTACK_STATE;
        }
    }
}


