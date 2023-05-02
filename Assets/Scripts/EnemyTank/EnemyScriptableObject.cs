using UnityEngine;

namespace BattleTank.EnemyTank
{
    [CreateAssetMenu( fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/New EnemyScriptableObject" )]
    public class EnemyScriptableObject : ScriptableObject
    {
        public EnemyView EnemyPrefab;
        public float Health;
        public float MoveSpeed;
    }
}
