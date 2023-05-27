using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using BattleTank.EventSystem;

namespace BattleTank.UI
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private Button restartButton;
        private void Start()
        {
            gameOverPanel.SetActive( false );
            restartButton.onClick.AddListener( Restart );
            EventService.Instance.OnPlayerDeath.AddListener( ShowGameOver );
        }
        private void ShowGameOver( )
        {
            gameOverPanel.SetActive( true );
        }
        private void Restart( )
        {
            SceneManager.LoadScene( SceneManager.GetActiveScene( ).buildIndex );
        }
    }
}
