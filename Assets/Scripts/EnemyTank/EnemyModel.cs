using UnityEngine;

namespace BattleTank.EnemyTank
{
    public class EnemyModel
    {
        private EnemyController enemyController;
        private PatrolPointScriptableObject startingPoint;
        public float MoveSpeed { get; private set; }
        public float Health { get; private set; }
        public float RotationAmount { get { return 50; } private set { } }

        public void SetTankController( EnemyController _enemyController )
        {
            this.enemyController = _enemyController;
        }
        public PatrolPointScriptableObject GetStartingPoint( )
        {
            return this.startingPoint;
        }
        public void SetStartingPoint( PatrolPointScriptableObject _patrolPoint )
        {
            this.startingPoint = _patrolPoint;
        }
    }
}
