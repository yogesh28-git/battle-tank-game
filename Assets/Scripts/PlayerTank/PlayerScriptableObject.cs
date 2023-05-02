using UnityEngine;

namespace BattleTank.PlayerTank
{
    [CreateAssetMenu( fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/New PlayerScriptableObject" )]
    public class PlayerScriptableObject : ScriptableObject
    {
        public PlayerView TankPrefab;
        public int Health;
        public float MoveSpeed;
    }
}

