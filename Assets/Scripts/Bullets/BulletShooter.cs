using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] private BulletView bulletPrefab;
    [SerializeField] private GameObject shooterTank;

    public void Shoot( ) 
    {
        BulletView bullet =  GameObject.Instantiate<BulletView>( bulletPrefab, transform.position, transform.rotation);
        bullet.SetShooterObject( shooterTank );
    }
}
