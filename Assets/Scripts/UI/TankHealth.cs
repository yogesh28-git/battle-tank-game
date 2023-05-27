using UnityEngine;
using UnityEngine.UI;

namespace BattleTank.UI
{
    public class TankHealth : MonoBehaviour
    {
        private Camera cam;
        [SerializeField] private Gradient gradient;
        [SerializeField] private Slider healthBar;
        [SerializeField] private BoxCollider boxCollider;
        [SerializeField] private Image fill;

        private ITank tank;
        private int currHealth;
        private int maxHealth; 

        private void Start( )
        {
            this.tank = boxCollider.GetComponent<ITank>( );
            this.cam = UIService.Instance.CameraMain;

            maxHealth = tank.GetHealth( );

            healthBar.maxValue = maxHealth;

            currHealth = maxHealth;
        }
        private void LateUpdate( )
        {
            transform.LookAt( transform.position + cam.transform.forward );

            currHealth = tank.GetHealth( );

            healthBar.value = currHealth;
            fill.color = gradient.Evaluate( healthBar.normalizedValue );
        }
    }
}
