using UnityEngine;

namespace BattleTank.PlayerTank
{
    public class PlayerService : MonoSingletonGeneric<PlayerService>
    {
        public PlayerController PlayerController { get; private set; }

        [SerializeField] private PlayerScriptableObject[] playerObjectList;

        private PlayerView playerView;
        private PlayerModel playerModel;
        private PlayerScriptableObject playerObject;
        private PlayerView playerPrefab;

        private void Awake( )
        {
            base.Awake( );

            int tankIndex = ( int ) Random.Range( 0, playerObjectList.Length );
            this.playerObject = playerObjectList[tankIndex];
            CreateTank( );
        }
        private void CreateTank( )
        {
            this.playerModel = new PlayerModel( playerObject );
            this.playerPrefab = playerObject.PlayerPrefab;
            this.playerView = GameObject.Instantiate<PlayerView>( playerPrefab );
            this.PlayerController = new PlayerController( playerModel, playerView );
        }
    }

}
