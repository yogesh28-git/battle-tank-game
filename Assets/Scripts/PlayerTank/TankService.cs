using UnityEngine;

namespace BattleTank.PlayerTank
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        private void Awake( )
        {
            base.Awake( ); 
        }

        public TankController tankController { get; private set; }

        [SerializeField] private TankScriptableObject[] tankObjectList;

        private TankModel tankModel;
        private TankScriptableObject tankObject;
        private TankView tankPrefab;

        private void Start( )
        {
            int tankIndex = ( int ) Random.Range( 0, 3 );
            this.tankObject = tankObjectList[tankIndex];
            CreateTank( );
        }

        private void CreateTank( )
        {
            this.tankModel = new TankModel( tankObject );
            this.tankPrefab = tankObject.TankPrefab;
            this.tankController = new TankController( tankModel, tankPrefab );
        }
    }

}
