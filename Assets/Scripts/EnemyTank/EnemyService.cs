using UnityEngine;
using BattleTank.PlayerTank;

namespace BattleTank.EnemyTank
{
    public class EnemyService : MonoSingletonGeneric<EnemyService>
    {
        public EnemyController EnemyController { get; private set; }

        [SerializeField] private MasterPatrolPointScriptableObject masterPatrolPoint;
        [SerializeField] private EnemyView enemyPrefab;
        [SerializeField] private PlayerService player;

        private EnemyModel enemyModel;
        private EnemyView enemyView;
        

        private void Awake( )
        {
            base.Awake( );
        }
        private void Start( )
        {
            enemyView = GameObject.Instantiate<EnemyView>( enemyPrefab );
            enemyView.SetPlayer( player.PlayerController.PlayerView );

            enemyModel = new EnemyModel( );
            enemyModel.SetMasterPatrolPoint( masterPatrolPoint );

            EnemyController = new EnemyController( enemyModel, enemyView );
        }
    }
}
