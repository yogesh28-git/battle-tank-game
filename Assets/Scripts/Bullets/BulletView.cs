using UnityEngine;
using BattleTank.EnemyTank;
using BattleTank.PlayerTank;

namespace BattleTank.Bullets
{
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

        private void OnEnable( )
        {
            startPoint = transform.position;
            offset = transform.forward * travelDistance;
            endPoint = startPoint + offset;
        }

        private void Update( )
        {
            transform.position = Vector3.MoveTowards( transform.position, endPoint, bulletSpeed * Time.deltaTime );
            if ( ( endPoint - transform.position ).sqrMagnitude < 0.1 )
            {
                BulletService.Instance.ReturnToPool( this );
            }
        }

        private void OnTriggerEnter( Collider collidedObject )
        {
            if ( collidedObject.gameObject != shooterObject.gameObject )
            {
                BulletService.Instance.ReturnToPool( this );
            }

            if ( collidedObject.CompareTag( "PlayerTank" ) && shooterObject.CompareTag( "EnemyTank" ) )
            {
                collidedObject.gameObject.GetComponent<PlayerView>( ).Death(shooterObject.gameObject);
            }
            else if ( collidedObject.CompareTag( "EnemyTank" ) && shooterObject.CompareTag( "PlayerTank" ) )
            {
                collidedObject.gameObject.GetComponent<EnemyView>().Death( );
                Destroy( collidedObject.gameObject ,1f);
            }
        }
    }
}

