using UnityEngine;

namespace BattleTank.EnemyTank
{
    public class EnemyModel : MonoBehaviour
    {
        private EnemyController enemyController;
        public float MoveSpeed { get; private set; }
        public float Health { get; private set; }
        public float RotationAmount { get { return 50; } private set { } }

        public void SetTankController( EnemyController _enemyController )
        {
            this.enemyController = _enemyController;
        }
    }
}
