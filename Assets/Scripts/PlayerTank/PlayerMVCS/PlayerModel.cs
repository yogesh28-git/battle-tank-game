using UnityEngine;

namespace BattleTank.PlayerTank
{
    public class PlayerModel
    {
        public float MoveSpeed { get; private set; }
        public int Health { get; private set; }
        public int Attack { get; private set; }
        public float TurnSpeed { get; private set; }

        public PlayerModel( PlayerScriptableObject playerObject )
        {
            this.MoveSpeed = playerObject.MoveSpeed;
            this.TurnSpeed = playerObject.TurnSpeed;
            this.Health = playerObject.Health;
            this.Attack = playerObject.Attack;
        }
        public void SetHealth( int value )
        {
            this.Health = value;
        }
    }

}
