using UnityEngine;
using BattleTank.EventSystem;

namespace BattleTank.UI
{
    public class AchievementSystem
    {
        private int bulletsHit;
        private int enemiesKilled;

        private int highScore;
        private bool isHighScoreUnlocked = false;

        private string ONE_ENEMY_KILLED = "1 Enemy Killed !!!";
        private string FIVE_ENEMY_KILLED = "5 Enemies Killed !!!";
        private string TEN_ENEMY_KILLED = "10 Enemies Killed !!!";

        private string FIVE_BULLETS_HIT = "5 Bullets Hit !!!";
        private string TEN_BULLETS_HIT = "10 Bullets Hit !!!";
        private string TWENTY_BULLETS_HIT = "20 Bullets Hit !!!";

        private string HIGHSCORE_TEXT = "New HighScore: ";

        private string PREF_HIGHSCORE = UIService.Instance.PREF_HIGHSCORE;
        private string PREF_BULLETHIT = UIService.Instance.PREF_BULLETHIT;
        private string PREF_ENEMYKILLED = UIService.Instance.PREF_ENEMYKILLED;

        public AchievementSystem( )
        {
            highScore = PlayerPrefs.GetInt( PREF_HIGHSCORE, 0 );
            bulletsHit = 0;
            enemiesKilled = 0;

            EventService.Instance.OnEnemyDeath.AddListener( IncrementEnemiesKilled );
            EventService.Instance.OnEnemyDeath.AddListener( CheckEnemiesKilledAchievement );

            EventService.Instance.OnBulletHit.AddListener( IncrementBulletsHit );
            EventService.Instance.OnBulletHit.AddListener( CheckBulletsHitAchievement );
        }
        
        public void IncrementBulletsHit( int points )
        {
            bulletsHit++;
        }
        public void IncrementEnemiesKilled( int points )
        {
            enemiesKilled++;
        }
        
        public void CheckEnemiesKilledAchievement( int points = 0)
        {
            int savedPref = PlayerPrefs.GetInt( PREF_ENEMYKILLED, 0 );
            if ( savedPref >= 3 )
            {
                EventService.Instance.OnEnemyDeath.RemoveListener( CheckEnemiesKilledAchievement );
                return;
            }
            if ( enemiesKilled == 1 && savedPref == 0 )
            {
                EventService.Instance.OnAchievementUnlock.InvokeEvent( ONE_ENEMY_KILLED );
                PlayerPrefs.SetInt( PREF_ENEMYKILLED, 1 );
            }
            else if ( enemiesKilled == 5 && savedPref == 1 )
            {
                EventService.Instance.OnAchievementUnlock.InvokeEvent( FIVE_ENEMY_KILLED );
                PlayerPrefs.SetInt( PREF_ENEMYKILLED, 2 );
            }
            else if ( enemiesKilled == 10 && savedPref == 2 )
            {
                EventService.Instance.OnAchievementUnlock.InvokeEvent( TEN_ENEMY_KILLED );
                PlayerPrefs.SetInt( PREF_ENEMYKILLED, 3 );
            }
        }
        public void CheckBulletsHitAchievement( int points = 0)
        {
            int savedPref = PlayerPrefs.GetInt( PREF_BULLETHIT, 0 );
            if(savedPref >= 3 )
            {
                EventService.Instance.OnBulletHit.RemoveListener( CheckBulletsHitAchievement );
                return;
            }
            if ( bulletsHit == 5 && savedPref == 0 )
            {
                EventService.Instance.OnAchievementUnlock.InvokeEvent( FIVE_BULLETS_HIT );
                PlayerPrefs.SetInt( PREF_BULLETHIT, 1 );
            }  
            else if (bulletsHit == 10 && savedPref == 1 )
            {
                EventService.Instance.OnAchievementUnlock.InvokeEvent( TEN_BULLETS_HIT );
                PlayerPrefs.SetInt( PREF_BULLETHIT, 2 );
            }
            else if ( bulletsHit == 20 && savedPref == 2 )
            {
                EventService.Instance.OnAchievementUnlock.InvokeEvent( TWENTY_BULLETS_HIT );
                PlayerPrefs.SetInt( PREF_BULLETHIT, 3 );
            }
        }
        public void CheckHighScore(int value )
        {
            if ( isHighScoreUnlocked )
            {
                return;
            }
            if( value > highScore)
            {
                highScore = value;
                PlayerPrefs.SetInt( PREF_HIGHSCORE, value );
                EventService.Instance.OnAchievementUnlock.InvokeEvent( HIGHSCORE_TEXT + highScore );
                isHighScoreUnlocked = true;
            }
        }
    }
}