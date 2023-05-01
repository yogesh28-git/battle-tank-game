using UnityEngine;

namespace BattleTank.EnemyTank
{
    public class EnemyService : MonoSingletonGeneric<EnemyService>
    {
        [SerializeField] private EnemyView enemyPrefab;

        private EnemyModel enemyModel;
        private EnemyView enemyView;
        private EnemyController enemyController;

        private void Awake( )
        {
            base.Awake( );
        }
        private void Start( )
        {
            enemyView = GameObject.Instantiate<EnemyView>( enemyPrefab );
            enemyModel = new EnemyModel( );
            enemyController = new EnemyController( enemyModel, enemyView );
        }
    }
}
