using UnityEngine;

namespace BattleTank.Bullets
{
    public class BulletService : ServicePoolGeneric<BulletService, BulletView>
    {
        [SerializeField] private BulletView bulletPrefab;

        protected override BulletView CreateNewItem(Transform newTransform)
        {
            BulletView bulletView = GameObject.Instantiate<BulletView>( bulletPrefab );
            bulletView.gameObject.SetActive( false );
            SetTransform( bulletView, newTransform );
            return bulletView;
        }

        public void Shoot( IDamagable shooterObject, Transform shootPoint )
        {
            BulletView bullet = GetFromPool( shootPoint );
            bullet.SetShooterObject( shooterObject );
        }
    }
}
