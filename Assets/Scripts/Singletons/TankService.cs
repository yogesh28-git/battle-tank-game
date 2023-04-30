using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    private void Awake( )
    {
        base.Awake( ); //creating singleton instance
    }

    public TankModel tankModel { get; private set; }
    [SerializeField] private TankScriptableObject tankObject;
    public TankController tankController { get; private set; }
    private TankView tankPrefab;

    private void Start( )
    {
        tankModel = new TankModel(tankObject);
        tankPrefab = tankObject.TankPrefab;
        tankController = new TankController(tankModel, tankPrefab);
    }
}
