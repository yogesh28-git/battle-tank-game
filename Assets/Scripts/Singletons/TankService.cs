using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    private void Awake( )
    {
        base.Awake( ); //creating singleton instance
    }

    public TankModel tankModel { get; private set; }
    [SerializeField] private TankScriptableObject[] tankObjectList;
    private TankScriptableObject tankObject;
    public TankController tankController { get; private set; }
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
