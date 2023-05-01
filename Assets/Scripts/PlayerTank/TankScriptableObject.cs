using UnityEngine;

namespace BattleTank.PlayerTank
{
    [CreateAssetMenu( fileName = "TankScriptableObject", menuName = "ScriptableObjects/New PlayerScriptableObject" )]
    public class TankScriptableObject : ScriptableObject
    {
        public TankView TankPrefab;
        public int Health;
        public float MoveSpeed;
    }
}

