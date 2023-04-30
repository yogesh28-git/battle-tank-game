using UnityEngine;

public class BulletView : MonoBehaviour
{
    private float travelDistance = 10;
    private Vector3 startPoint;
    private Vector3 endPoint;

    private void Start( )
    {
        startPoint = transform.position;
        endPoint = startPoint + new Vector3( 0, 0, 10 );
        Debug.Log( startPoint + " " + endPoint );
    }

    private void Update( )
    {
        transform.position = Vector3.MoveTowards( transform.position, endPoint, 0.05f);
        if(transform.position.z >= endPoint.z )
        {
            Destroy( gameObject );
        }
    }

    private void OnTriggerEnter( Collider other )
    {
        //Destroy( gameObject );
    }
}
