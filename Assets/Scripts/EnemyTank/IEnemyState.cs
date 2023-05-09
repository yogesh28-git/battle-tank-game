namespace BattleTank.EnemyTank
{
    public interface IEnemyState
    {
        public void OnStateEnter( );

        public void OnStateUpdate( );

        public void OnStateExit( );

        public TankStates GetState( );
    }
}
