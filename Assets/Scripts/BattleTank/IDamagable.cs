using UnityEngine;
namespace BattleTank
{
    public interface IDamagable
    {
        public int GiveDamage( );

        public void TakeDamage( int damage );

        public void Death( );

        public GameObject GetGameObject( );
    } 
}