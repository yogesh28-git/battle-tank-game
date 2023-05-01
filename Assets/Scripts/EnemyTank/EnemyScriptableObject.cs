using UnityEngine;

namespace BattleTank.EnemyTank
{
    [CreateAssetMenu( fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/New EnemyScriptableObject" )]
    public class EnemyScriptableObject : ScriptableObject
    {
        public EnemyView enemyPrefab;
        public float Health;
        public float MoveSpeed;
        public Vector3 patrolStartPoint;
        public Vector3 patrolEndPoint;
    }
}
