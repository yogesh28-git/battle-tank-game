using UnityEngine;
namespace BattleTank.EnemyTank
{
    public class EnemyStateAttack : IEnemyState
    {
        private EnemyView enemyView;
        private EnemyController enemyController;
        private float shootDelay = 1.5f;
        private float timer;
        public EnemyStateAttack( EnemyController _enemyController )
        {
            this.enemyController = _enemyController;
            this.enemyView = enemyController.EnemyView;
        }
        public void OnStateEnter( )
        {
            timer = 0f;
        }

        public void OnStateUpdate( )
        {
            timer = enemyController.AttackThePlayer( timer, shootDelay );
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


