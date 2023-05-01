using UnityEngine;

namespace BattleTank.EnemyTank
{
    [CreateAssetMenu( fileName = "PatrolPoint", menuName = "ScriptableObjects/New PatrolPoint" )]
    public class PatrolPointScriptableObject : ScriptableObject
    {
        public Vector3 Position;

        public PatrolPointScriptableObject[] NeighbourPoints;
    }
}
