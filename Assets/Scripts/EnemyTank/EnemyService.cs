using UnityEngine;

namespace BattleTank.EnemyTank
{
    public class EnemyService : MonoSingletonGeneric<EnemyService>
    {
        [SerializeField] private MasterPatrolPointScriptableObject MasterPatrolPoint;
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
            int randIndex = ( int ) Random.Range( 0, MasterPatrolPoint.PatrolPoints.Length );
            enemyView = GameObject.Instantiate<EnemyView>( enemyPrefab , MasterPatrolPoint.PatrolPoints[randIndex].Position, Quaternion.identity );
            
            enemyModel = new EnemyModel( );
            enemyModel.SetStartingPoint( MasterPatrolPoint.PatrolPoints[randIndex] );
            
            enemyController = new EnemyController( enemyModel, enemyView );
        }
    }
}
