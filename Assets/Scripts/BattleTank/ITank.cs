namespace BattleTank 
{
    public interface ITank
    {
        public IDamagable GetController( );

        public int GetHealth( );
    }    
}