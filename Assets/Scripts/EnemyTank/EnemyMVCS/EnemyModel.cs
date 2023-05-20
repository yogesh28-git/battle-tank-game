using UnityEngine;

namespace BattleTank.EnemyTank
{
    public class EnemyModel
    {
        public float MoveSpeed { get; private set; }
        public int Health { get; private set; }
        public int Attack { get; private set; }

        public int Score { get; private set; }

        private PatrolPointScriptableObject startingPoint;
        private MasterPatrolPointScriptableObject masterPatrolPoint;
        public EnemyModel( EnemyScriptableObject enemyObject, MasterPatrolPointScriptableObject _masterPatrolPoint )
        {
            this.masterPatrolPoint = _masterPatrolPoint;
            startingPoint = GetRandomPoint( );

            this.MoveSpeed = enemyObject.MoveSpeed;
            this.Health = enemyObject.Health;
            this.Attack = enemyObject.Attack;
            this.Score = enemyObject.Score;
        }
        public void SetHealth( int value )
        {
            this.Health = value;
        }
        public PatrolPointScriptableObject GetRandomPoint() 
        {
            int randIndex = ( int ) Random.Range( 0, masterPatrolPoint.PatrolPoints.Length );
            PatrolPointScriptableObject randomPatrolPoint = masterPatrolPoint.PatrolPoints[randIndex];
            return randomPatrolPoint;
        }
        public Vector3 GetStartingPoint( )
        {
            return this.startingPoint.Position;
        }
        public void UpdateStartingPoint( )
        {
            int randNeighbourIndex = ( int ) Random.Range( 0, startingPoint.NeighbourPoints.Length );
            startingPoint = startingPoint.NeighbourPoints[randNeighbourIndex];
        }
    }
}
