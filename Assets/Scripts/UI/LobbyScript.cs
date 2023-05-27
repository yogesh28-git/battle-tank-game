using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace BattleTank.UI
{
    public class LobbyScript : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenuPanel;
        [SerializeField] private Button playButton;
        [SerializeField] private Button resetButton;
        [SerializeField] private Button quit;

        [SerializeField] private GameObject highScorePanel;
        [SerializeField] private Button highScoreButton;
        [SerializeField] private TextMeshProUGUI highScoreText;
        [SerializeField] private Button back;

        private void Start( )
        {
            mainMenuPanel.SetActive( true );
            playButton.onClick.AddListener( PlayGame );
            quit.onClick.AddListener( QuitGame );
            resetButton.onClick.AddListener( ResetGame );

            highScorePanel.SetActive( false );
            highScoreText.text ="HighScore: "+ PlayerPrefs.GetInt( UIService.Instance.PREF_HIGHSCORE, 0).ToString();
            highScoreButton.onClick.AddListener( ShowHighScore );
            back.onClick.AddListener( Back );
        }
        private void PlayGame( ) => SceneManager.LoadScene( 1 );
        private void QuitGame( ) => Application.Quit( );
        private void ResetGame( ) => PlayerPrefs.DeleteAll( );
        private void ShowHighScore() => highScorePanel.SetActive( true );
        private void Back() => highScorePanel.SetActive( false );
    }
}