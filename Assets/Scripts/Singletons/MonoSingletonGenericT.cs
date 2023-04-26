using UnityEngine;

public class MonoSingletonGeneric<T> : MonoBehaviour where T : MonoSingletonGeneric<T>
{
    public static T Instance { get; private set; }
    protected virtual void Awake( )
    {
        Debug.Log( "Awake of base class called" );
        if ( Instance == null )
        {
            Instance = this as T;
            DontDestroyOnLoad( this.gameObject );
        }
        else
        {
            Destroy( this.gameObject );
        }
    }
}
