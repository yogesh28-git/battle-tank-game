using UnityEngine;

public class Enemy : MonoSingletonGeneric<Enemy>
{
    protected override void Awake( )
    {
        base.Awake( );
        Debug.Log( "Awake of Enemy class is called" );
    }

    private void Start( )
    {
        Player.Instance.battle( ); //calling a function from Player class
    }
}

