using UnityEngine;

public class BulletView : MonoBehaviour
{
    private float travelDistance = 10;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private Vector3 offset;

    private void Start( )
    {
        startPoint = transform.position;
        offset = transform.forward;
        offset = transform.forward * travelDistance;
        endPoint = startPoint + offset;
        Debug.Log( startPoint + " " + endPoint);
    }

    private void Update( )
    {
        transform.position = Vector3.MoveTowards( transform.position, endPoint, 0.05f);
        if(transform.position.z == endPoint.z )
        {
            Destroy( gameObject );
        }
    }

    private void OnTriggerEnter( Collider other )
    {
        Destroy( gameObject );
    }
}
