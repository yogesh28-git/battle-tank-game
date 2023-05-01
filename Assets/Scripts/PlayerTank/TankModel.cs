using UnityEngine;

namespace BattleTank.PlayerTank
{
    public class TankModel
    {
        private TankController tankController;
        public float moveSpeed { get; private set; }
        public float Health { get; private set; }
        public float rotationAmount { get { return 50; } private set { } }

        public TankModel( TankScriptableObject tankObject )
        {
            this.moveSpeed = tankObject.MoveSpeed;
            this.Health = tankObject.Health;
        }
        public void SetTankController( TankController _tankController )
        {
            this.tankController = _tankController;
        }

    }

}
