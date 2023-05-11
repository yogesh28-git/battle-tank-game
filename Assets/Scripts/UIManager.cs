using UnityEngine;
using TMPro;
using System.Collections;
using BattleTank.PlayerTank;

namespace BattleTank
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]private TextMeshProUGUI achievementMessage;

        private Coroutine achievementDisplay;

        private string _10BulletAchievement = "Achievement: 10 Bullets Fired !!!";
        private string _25BulletAchievement = "Achievement: 25 Bullets Fired !!!";
        private string _50BulletAchievement = "Achievement: 50 Bullets Fired !!!";

        private void Start( )
        {
            achievementMessage.enabled = false;
            PlayerView.OnAchievementUnlock += UnlockAchievement;
        }
        private void OnDestroy( )
        {
            PlayerView.OnAchievementUnlock -= UnlockAchievement;
        }

        private void UnlockAchievement(int bulletCount)
        {
            switch ( bulletCount )
            {
                case 10:
                    achievementMessage.text = _10BulletAchievement;
                    break;
                case 25:
                    achievementMessage.text = _25BulletAchievement;
                    break;
                case 50:
                    achievementMessage.text = _50BulletAchievement;
                    break;
            }

            achievementDisplay = StartCoroutine( AchievementDisplay( 3 ) );
        }

        private IEnumerator AchievementDisplay( int duration )
        {
            achievementMessage.enabled = true;
            yield return new WaitForSeconds( duration );
            achievementMessage.enabled = false;
        }

    }
}
