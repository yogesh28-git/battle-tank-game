using UnityEngine;

public class FPCameraFollow : MonoBehaviour
{
    [SerializeField]private TankService tankservice;
    private Transform player;
    private float currentRot;

    private void Start( )
    {
        player = tankservice.tankController.tankView.transform;
        currentRot = player.eulerAngles.y;
    }

    private void LateUpdate( )
    {
        float rotationAmount = player.eulerAngles.y - currentRot;
        currentRot = player.eulerAngles.y;

        transform.rotation = player.rotation;
        transform.position = player.position;
    }
}
