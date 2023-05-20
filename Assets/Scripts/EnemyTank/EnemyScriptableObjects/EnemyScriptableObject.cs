using UnityEngine;

namespace BattleTank.EnemyTank
{
    [CreateAssetMenu( fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/New EnemyScriptableObject" )]
    public class EnemyScriptableObject : ScriptableObject
    {
        public EnemyView EnemyPrefab;

        public float MoveSpeed;

        public int Health;

        public int Attack;

        public int Score;
    }
}
