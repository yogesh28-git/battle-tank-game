using UnityEngine;

namespace BattleTank.PlayerTank
{
    public class TankController
    {
        public TankModel tankModel { get; private set; }
        public TankView tankView { get; private set; }
        public TankController( TankModel _tankModel, TankView _tankView )
        {
            tankView = _tankView;
            tankModel = _tankModel;

            tankView.SetTankController( this );
            tankModel.SetTankController( this );

            GetReferences( );
        }

        private Rigidbody tankBody;
        private Transform tankTransform;
        private float moveSpeed;
        private float rotationAmount;

        private void GetReferences( )
        {
            tankTransform = tankView.transform;
            tankBody = tankView.GetTankRigidBody( );
            moveSpeed = tankModel.moveSpeed;
            rotationAmount = tankModel.rotationAmount;
        }
        public void Move( bool forwardInput, bool backwardInput )
        {
            if ( forwardInput )
                tankBody.AddRelativeForce( Vector3.forward * moveSpeed * Time.deltaTime );
            else if ( backwardInput )
                tankBody.AddRelativeForce( Vector3.back * moveSpeed * Time.deltaTime );
        }
        public void Rotate( bool leftInput, bool rightInput )
        {
            if ( leftInput )
                tankTransform.Rotate( 0, -rotationAmount * Time.deltaTime, 0 );
            if ( rightInput )
                tankTransform.Rotate( 0, rotationAmount * Time.deltaTime, 0 );
        }
    }
}

