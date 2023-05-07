using UnityEngine;

namespace BattleTank
{
    public class BulletShooter : MonoBehaviour
    {
        [SerializeField] private BulletView bulletPrefab;
        [SerializeField] private Transform shootPoint;

        public void Shoot( )
        {
            BulletView bullet = GameObject.Instantiate<BulletView>( bulletPrefab, shootPoint.position, shootPoint.rotation );
            bullet.SetShooterObject( this.gameObject );
        }
    }
}
