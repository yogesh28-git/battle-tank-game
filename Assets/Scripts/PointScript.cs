using UnityEngine;

namespace BattleTank.EnemyTank
{
    public class PointScript : MonoBehaviour
    {
        public MasterPatrolPointScriptableObject master;

        private void Start( )
        {
            int size = master.PatrolPoints.Length;
            int randSize = ( int ) Random.Range( 0, size );

            
        }
    }
}
