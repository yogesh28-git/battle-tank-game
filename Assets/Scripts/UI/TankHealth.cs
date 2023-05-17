using UnityEngine;
using UnityEngine.UI;
using BattleTank.PlayerTank;
using BattleTank.EnemyTank;

namespace BattleTank.UI
{
    public class TankHealth : MonoBehaviour
    {
        private enum Tank
        {
            PLAYER, ENEMY
        };

        private Camera cam;
        [SerializeField] private Gradient gradient;
        [SerializeField] private Slider healthBar;
        [SerializeField] private Tank tankType;
        [SerializeField] private Image fill;
        private int currHealth;
        private int maxHealth; 
        private PlayerModel playerModel;
        private EnemyModel enemyModel;

        private void Start( )
        {
            this.cam = UIService.Instance.CameraMain;
            switch ( tankType )
            {
                case Tank.PLAYER:
                    playerModel = PlayerService.Instance.PlayerController.PlayerModel;
                    maxHealth = playerModel.Health;
                    break;
                case Tank.ENEMY:
                    enemyModel = EnemyService.Instance.EnemyController.EnemyModel;
                    maxHealth = enemyModel.Health;
                    break;
            }

            healthBar.maxValue = maxHealth;

            currHealth = maxHealth;
        }
        private void LateUpdate( )
        {
            transform.LookAt( transform.position + cam.transform.forward );

            switch ( tankType )
            {
                case Tank.PLAYER:
                    currHealth = playerModel.Health;
                    break;
                case Tank.ENEMY:
                    currHealth = enemyModel.Health;
                    break;
            }

            healthBar.value = currHealth;
            fill.color = gradient.Evaluate( currHealth/maxHealth );
        }
    }
}
