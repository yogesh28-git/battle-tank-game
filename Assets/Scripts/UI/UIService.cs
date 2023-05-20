using UnityEngine;

namespace BattleTank.UI
{
    public class UIService : MonoSingletonGeneric<UIService>
    {
        public Camera CameraMain { get { return cameraMain; } private set { } }
        public string PREF_HIGHSCORE { get { return "highscore"; } private set { } }
        public string PREF_ENEMYKILLED { get { return "enemykilled"; } private set { } }
        public string PREF_BULLETHIT { get { return "bulletHit"; } private set { } }
        public AchievementSystem AchievementRef { get; private set; }

        [SerializeField] private Camera cameraMain;

        private void Start( )
        {
            AchievementRef = new AchievementSystem( );
        }
        public void PauseGame( )
        {
            Time.timeScale = 0;
        }
    }
}
