using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    private void Awake( )
    {
        base.Awake( ); //creating singleton instance
    }

    public TankModel tankModel { get; private set; }
    public TankController tankController { get; private set; }
    [SerializeField] private TankView tankPrefab;

    private void Start( )
    {
        tankModel = new TankModel( );
        tankController = new TankController(tankModel, tankPrefab);
    }
}
