using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using BattleTank.EventSystem;

namespace BattleTank.UI
{
    public class InGameUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI achievementMessage;
        [SerializeField] private TextMeshProUGUI scoreTMP;

        private Queue<IEnumerator> achievements = new Queue<IEnumerator>();
        private IEnumerator achievementDisplay;
        private string scoreText = "Score: ";
        private int score;

        private void Start( )
        {
            PlayerPrefs.DeleteAll( );
            score = 0;
            scoreTMP.text = scoreText + score;
            achievementMessage.enabled = false;
            EventService.Instance.OnAchievementUnlock.AddListener( UnlockAchievement );
            EventService.Instance.OnEnemyDeath.AddListener( scoreUpdate );
            EventService.Instance.OnBulletHit.AddListener( scoreUpdate );
        }
        private void OnDestroy( )
        {
            EventService.Instance.OnAchievementUnlock.RemoveListener( UnlockAchievement );
            EventService.Instance.OnEnemyDeath.RemoveListener( scoreUpdate );
            EventService.Instance.OnBulletHit.RemoveListener( scoreUpdate );
        }
        private void UnlockAchievement( string message )
        {
            achievementDisplay = AchievementDisplay( 3, message );
            if ( achievements.Count == 0 )
            {
                StartCoroutine( achievementDisplay );
            }
            achievements.Enqueue( achievementDisplay );

        }
        private IEnumerator AchievementDisplay( int duration,string message )
        {
            achievementMessage.text = message;
            achievementMessage.enabled = true;
            yield return new WaitForSeconds( duration );
            achievementMessage.enabled = false;

            achievements.Dequeue( );
            if ( achievements.Count > 0 )
            {
                StartCoroutine( achievements.Peek( ) );
            }
        }
        public void scoreUpdate( int value )
        {
            score += value;
            scoreTMP.text = scoreText + score;
            UIService.Instance.AchievementRef.CheckHighScore( score );
        }
    }
        
}