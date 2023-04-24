using UnityEngine;

public class TankMovement : MonoBehaviour
{
    [SerializeField] private int tankSpeed = 100;
    [SerializeField] private float tankTurn = 50;

    [SerializeField] private Rigidbody tankRigidBody;

    private bool forwardInput = false;
    private bool backwardInput = false;
    private bool leftInput = false;
    private bool rightInput = false;

    private void Update( )
    {
        forwardInput = Input.GetKey( KeyCode.W );
        backwardInput = Input.GetKey( KeyCode.S );
        leftInput = Input.GetKey( KeyCode.A );
        rightInput = Input.GetKey( KeyCode.D );
    }
    private void FixedUpdate( )
    {
        if ( forwardInput )
            tankRigidBody.AddRelativeForce( Vector3.forward * tankSpeed * Time.deltaTime );
        else if ( backwardInput )
            tankRigidBody.AddRelativeForce( Vector3.back * tankSpeed * Time.deltaTime );

        if ( leftInput )
            transform.Rotate( 0, -tankTurn*Time.deltaTime, 0);
        else if ( rightInput )
            transform.Rotate( 0, tankTurn*Time.deltaTime, 0);

    }
}
