using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using BattleTank.PlayerTank;
using BattleTank.EventSystem;

namespace BattleTank.UI
{
    public class UIService : MonoSingletonGeneric<UIService>
    {
        public Camera CameraMain { get { return cameraMain; } private set { } }

        [SerializeField] private Camera cameraMain;
        [SerializeField]private TextMeshProUGUI achievementMessage;

        private Queue<IEnumerator> achievements;
        private IEnumerator achievementDisplay;

        private string _10BulletAchievement = "Achievement: 10 Bullets Fired !!!";
        private string _25BulletAchievement = "Achievement: 25 Bullets Fired !!!";
        private string _50BulletAchievement = "Achievement: 50 Bullets Fired !!!";

        private void Start( )
        {
            achievementMessage.enabled = false;
            EventService.Instance.OnBulletsHit.AddListener( UnlockAchievement );
            PlayerView.OnAchievementUnlock += UnlockAchievement;
        }
        private void OnDestroy( )
        {
            PlayerView.OnAchievementUnlock -= UnlockAchievement;
        }

        private void UnlockAchievement()
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

            achievementDisplay = AchievementDisplay( 3 );
            if (achievements.Count == 0 )
            {
                StartCoroutine( achievementDisplay );
            }
            achievements.Enqueue( achievementDisplay );

        }

        private IEnumerator AchievementDisplay( int duration )
        {
            achievementMessage.enabled = true;
            yield return new WaitForSeconds( duration );
            achievementMessage.enabled = false;

            achievements.Dequeue( );
            if(achievements.Count > 0 )
            {
                StartCoroutine( achievements.Peek( ) );
            }
        }

    }
}
