using UnityEngine;

public class FPCameraFollow : MonoBehaviour
{
    [SerializeField]private TankService tankservice;
    private Transform player;
    private float offset;
    private float currentRot;

    private void Start( )
    {
        player = tankservice.tankController.tankView.transform;
        offset = (player.position - transform.position).z;
        currentRot = player.eulerAngles.y;
    }

    private void LateUpdate( )
    {
        float rotationAmount = player.eulerAngles.y - currentRot;
        //transform.RotateAround( player.position, Vector3.up, rotationAmount);
        currentRot = player.eulerAngles.y;

        transform.rotation = player.rotation;
        /*Vector3 front = transform.position; //transform of object2
        front.z = player.position.z - offset; //player is object1 , offset is the distance
        transform.position = front;    */

        transform.position = player.position;
    }
}
