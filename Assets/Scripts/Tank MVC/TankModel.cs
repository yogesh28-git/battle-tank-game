using UnityEngine;

public class TankModel
{
    private TankController tankController;
    public void SetTankController(TankController _tankController )
    {
        tankController = _tankController;
    }

    public float forwardForce { get { return 800; } private set { } }
    public float rotationAmount { get { return 50; } private set { } }
}
