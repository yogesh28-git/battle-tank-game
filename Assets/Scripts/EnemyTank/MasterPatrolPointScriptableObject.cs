using UnityEngine;

namespace BattleTank.EnemyTank
{
    [CreateAssetMenu( fileName = "MasterPatrolPointScriptableObject", menuName = "ScriptableObjects/New MasterPatrolPoint" )]
    public class MasterPatrolPointScriptableObject : ScriptableObject
    {
        public PatrolPointScriptableObject[] PatrolPoints;
    }
}
