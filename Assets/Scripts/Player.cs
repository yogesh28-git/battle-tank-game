using UnityEngine;

public class Player : MonoSingletonGeneric<Player>
{
    private void Awake( )
    {
        base.Awake( );
        Debug.Log( "Awake of Player class is called" );
    }

    public void battle( )
    {
        Debug.Log( "Battle function Called" );
    }
}
