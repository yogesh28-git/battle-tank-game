using UnityEngine;

namespace BattleTank.PlayerTank
{
    public class PlayerModel
    {
        public float MoveSpeed { get; private set; }
        public float Health { get; private set; }
        public float rotationAmount { get { return 50; } private set { } }

        public PlayerModel( PlayerScriptableObject playerObject )
        {
            this.MoveSpeed = playerObject.MoveSpeed;
            this.Health = playerObject.Health;
        }
    }

}
