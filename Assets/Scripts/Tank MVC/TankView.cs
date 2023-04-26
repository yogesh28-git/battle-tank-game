using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    private void Start()
    {
        Debug.Log( "TankView has been instantiated! " + gameObject );
    }

    public void SetTankController( TankController _tankController )
    {
        tankController = _tankController;
    }

    //Input Parameters
    private bool forwardInput = false;
    private bool backwardInput = false;
    private bool leftInput = false;
    private bool rightInput = false;

    public Rigidbody tankRigidBody;
    public Rigidbody TankBody { get { return tankRigidBody; } }

    private void InputHandler( ) 
    {
        forwardInput = Input.GetKey( KeyCode.W );
        backwardInput = Input.GetKey( KeyCode.S );
        leftInput = Input.GetKey( KeyCode.A );
        rightInput = Input.GetKey( KeyCode.D );
    }
    private void Update( )
    {
        InputHandler( );


    }
}
