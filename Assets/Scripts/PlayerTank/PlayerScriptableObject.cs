using UnityEngine;

namespace BattleTank.PlayerTank
{
    [CreateAssetMenu( fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/New PlayerScriptableObject" )]
    public class PlayerScriptableObject : ScriptableObject
    {
        public PlayerView PlayerPrefab;

        public float MoveSpeed;

        public float TurnSpeed;

        public int Health;
        
        public int Attack;
    }
}

