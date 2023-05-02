using UnityEngine;

namespace BattleTank.PlayerTank
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        public TankController tankController { get; private set; }
        public TankView TankView { get; private set; }

        [SerializeField] private TankScriptableObject[] tankObjectList;

        private TankModel tankModel;
        private TankScriptableObject tankObject;
        private TankView tankPrefab;

        private void Awake( )
        {
            base.Awake( );
            int tankIndex = ( int ) Random.Range( 0, 3 );
            this.tankObject = tankObjectList[tankIndex];
            CreateTank( );
        }
        private void Start( )
        {
        }

        private void CreateTank( )
        {
            this.tankModel = new TankModel( tankObject );
            this.tankPrefab = tankObject.TankPrefab;
            this.TankView = GameObject.Instantiate<TankView>( tankPrefab );
            this.tankController = new TankController( tankModel, TankView );
        }
    }

}
