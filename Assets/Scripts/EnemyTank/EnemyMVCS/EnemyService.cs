using UnityEngine;
using BattleTank.PlayerTank;

namespace BattleTank.EnemyTank
{
    public class EnemyService : MonoSingletonGeneric<EnemyService>
    {
        public EnemyController EnemyController { get; private set; }

        [SerializeField] private MasterPatrolPointScriptableObject masterPatrolPoint;
        [SerializeField] private EnemyScriptableObject[] enemyObjectList;

        private EnemyModel enemyModel;
        private EnemyView enemyView;

        private void Awake( )
        {
            base.Awake( );
        }
        private void Start( )
        {

            int randomCount = ( int ) Random.Range( 1, 4 );
            for ( int i = 0; i < randomCount; i++ )
            {
                CreateRandomEnemyTank( );
            }
        }
        
        private void CreateRandomEnemyTank( )
        {
            int tankIndex = ( int ) Random.Range( 0, enemyObjectList.Length );
            EnemyScriptableObject enemyObject = enemyObjectList[tankIndex];

            enemyView = GameObject.Instantiate<EnemyView>( enemyObject.EnemyPrefab );

            enemyModel = new EnemyModel( masterPatrolPoint );

            EnemyController = new EnemyController( enemyModel, enemyView );
        }
    }
}
