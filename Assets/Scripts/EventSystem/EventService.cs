using UnityEngine;

namespace BattleTank.EventSystem
{
    public class EventService: SingletonGeneric<EventService> 
    {
        public EventController<int> OnBulletsHit;

        public EventController OnNewHighScore;

        public EventController OnEnemiesKilled;

        public EventService( )
        {
            OnBulletsHit = new EventController<int>( );
            OnNewHighScore = new EventController( );
            OnEnemiesKilled = new EventController( );
        }
    }
}