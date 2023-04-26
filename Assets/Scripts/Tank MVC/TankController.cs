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

    private void GetReferences( )
    {
        
    }
    public void Move( )
    {
       /* if ( forwardInput )
            tankBody.AddRelativeForce( Vector3.forward * tankSpeed * Time.deltaTime );
        else if ( backwardInput )
            tankBody.AddRelativeForce( Vector3.back * tankSpeed * Time.deltaTime );*/
    }
    public void Rotate( ) 
    {

    }
}
