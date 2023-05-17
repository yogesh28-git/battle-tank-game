namespace BattleTank
{
    public class SingletonGeneric<T> where T : SingletonGeneric<T>
    {
        public static T Instance 
        {
            get 
            { 
                if(Instance == null )
                {
                    Instance = new SingletonGeneric<T>( ) as T;
                }
                return Instance;
            } 
            private set { } 
        }
    }
}
