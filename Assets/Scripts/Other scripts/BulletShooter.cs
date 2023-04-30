using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] private BulletView bulletPrefab;

    public void Shoot( ) 
    {
        GameObject.Instantiate( bulletPrefab, transform.position, transform.rotation);
    }
}
