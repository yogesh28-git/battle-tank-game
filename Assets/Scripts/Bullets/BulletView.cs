using UnityEngine;

namespace BattleTank.Bullets
{
    public class BulletView : MonoBehaviour
    {
        private float travelDistance = 10;
        private Vector3 startPoint;
        private Vector3 endPoint;
        private Vector3 offset;
        private IDamagable shooter;
        private float bulletSpeed = 20f;

        public void SetShooterObject( IDamagable tankController )
        {
            this.shooter = tankController;
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

        private void OnTriggerEnter( Collider collider )
        {
            if ( collider.gameObject == shooter.GetGameObject( ) )
            { 
                return;
            }

            ITank collidedTank = collider.GetComponent<ITank>( );

            if( collidedTank != null )
            {
                IDamagable collidedController = collidedTank.GetController( );
                collidedController.TakeDamage( shooter.GiveDamage( ) );
            }

            BulletService.Instance.ReturnToPool( this );
        }
    }
}

