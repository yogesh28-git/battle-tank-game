using UnityEngine;

public class BulletView : MonoBehaviour
{
    private float travelDistance = 10;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private Vector3 offset;
    private GameObject shooterObject;
    private float bulletSpeed = 20f;

    public void SetShooterObject( GameObject tank )
    {
        this.shooterObject = tank;
    }

    private void Start( )
    {
        startPoint = transform.position;
        offset = transform.forward * travelDistance;
        endPoint = startPoint + offset;
    }

    private void Update( )
    {
        transform.position = Vector3.MoveTowards( transform.position, endPoint, bulletSpeed*Time.deltaTime);
        if((endPoint - transform.position).sqrMagnitude < 0.1)
        {
            Destroy( gameObject );
        }
    }

    private void OnTriggerEnter( Collider collidedObject )
    {
        if( collidedObject.gameObject != shooterObject.gameObject )
        {
            Destroy( gameObject );
        }
        
        if(collidedObject.CompareTag("PlayerTank") && shooterObject.CompareTag( "EnemyTank" ) )
        {
            Debug.Log( "Player got hit" );
        }
        else if ( collidedObject.CompareTag( "EnemyTank" ) && shooterObject.CompareTag( "PlayerTank" ) )
        {
            Debug.Log( " Enemy got Hit" );
        }
    }
}
