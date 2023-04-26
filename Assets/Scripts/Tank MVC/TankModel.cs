using UnityEngine;

public class TankModel : MonoBehaviour
{
    private TankController tankController;


    private void Start( )
    {
        Debug.Log( "Model created" );
    }

    public void SetTankController(TankController _tankController )
    {
        tankController = _tankController;
    }
}
