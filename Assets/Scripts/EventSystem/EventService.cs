namespace BattleTank.EventSystem
{
    public class EventService: SingletonGeneric<EventService> 
    {
        public EventController<int> OnBulletHit;

        public EventController<int> OnEnemyDeath;

        public EventController<string> OnAchievementUnlock;

        public EventController OnPlayerDeath;

        public EventService( )
        {
            OnBulletHit = new EventController<int>( );
            OnEnemyDeath = new EventController<int>( );
            OnAchievementUnlock = new EventController<string>( );
            OnPlayerDeath = new EventController( );
        }
    }
}