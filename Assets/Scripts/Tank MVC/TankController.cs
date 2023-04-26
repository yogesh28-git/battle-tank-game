using UnityEngine;

public class TankController
{
    public TankModel tankModel { get; private set; }
    public TankView tankView { get; private set; }
    public TankController( TankModel _tankModel, TankView tankPrefab ) 
    {
        tankView = GameObject.Instantiate<TankView>( tankPrefab );
        tankModel = _tankModel;

        tankView.SetTankController(this);
        tankModel.SetTankController( this );

        GetReferences( );
    }

    private Rigidbody tankBody;
    private Transform tankTransform;
    private float forwardForce;
    private float rotationAmount;

    private void GetReferences( )
    {
        tankTransform = tankView.transform;
        tankBody = tankView.GetTankRigidBody();
        forwardForce = tankModel.forwardForce;
        rotationAmount = tankModel.rotationAmount;
    }
    public void Move(bool forwardInput, bool backwardInput)
    {
        if ( forwardInput )
            tankBody.AddRelativeForce( Vector3.forward * forwardForce * Time.deltaTime );
        else if ( backwardInput )
            tankBody.AddRelativeForce( Vector3.back * forwardForce * Time.deltaTime );
    }
    public void Rotate( bool leftInput, bool rightInput ) 
    {
        if ( leftInput )
            tankTransform.Rotate( 0, -rotationAmount * Time.deltaTime, 0 );
        if ( rightInput )
            tankTransform.Rotate( 0, rotationAmount * Time.deltaTime, 0 );
    }
}
