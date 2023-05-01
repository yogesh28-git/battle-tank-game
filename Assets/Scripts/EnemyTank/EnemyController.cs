using UnityEngine;

namespace BattleTank.EnemyTank
{
    public class EnemyController : MonoBehaviour
    {
        private EnemyModel enemyModel;
        private EnemyView enemyView;
        public EnemyController(EnemyModel _enemyModel, EnemyView _enemyView )
        {
            this.enemyModel = _enemyModel;
            this.enemyView = _enemyView;

            this.enemyModel.SetTankController( this );
            this.enemyView.SetTankController( this );
        }
    }
}
