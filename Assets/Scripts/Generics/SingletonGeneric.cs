namespace BattleTank
{
    public class SingletonGeneric<T> where T : SingletonGeneric<T>
    {
        public static T Instance { get; private set; }

        public SingletonGeneric( )
        {
            if(Instance == null )
            {
                Instance = new SingletonGeneric<T>() as T;
            }
        }
    }
}
