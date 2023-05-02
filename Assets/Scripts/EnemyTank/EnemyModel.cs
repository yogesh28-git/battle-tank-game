using UnityEngine;

namespace BattleTank.EnemyTank
{
    public class EnemyModel
    {
        public float MoveSpeed { get; private set; }
        public float Health { get; private set; }
        public float RotationAmount { get { return 50; } private set { } }

        private EnemyController enemyController;
        private PatrolPointScriptableObject startingPoint;
        private MasterPatrolPointScriptableObject masterPatrolPoint;

        public void SetMasterPatrolPoint( MasterPatrolPointScriptableObject _masterPatrolPoint )
        {
            this.masterPatrolPoint = _masterPatrolPoint;
        }
        public PatrolPointScriptableObject GetRandomPoint() 
        {
            int randIndex = ( int ) Random.Range( 0, masterPatrolPoint.PatrolPoints.Length );
            PatrolPointScriptableObject randomPatrolPoint = masterPatrolPoint.PatrolPoints[randIndex];
            return randomPatrolPoint;
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
