using UnityEngine;
using UnityEngine.SceneManagement;

public class ThemeManager : MonoBehaviour
{
    public static ThemeManager Instance;

    public GameObject themePanel;
    public GameObject warningPanel;

    public int player1XChoice = -1;
    public int player2OChoice = -1;

    [Header("X Themes")]
    public Sprite[] xThemes;

    [Header("O Themes")]
    public Sprite[] oThemes;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Hide UI panels on start
        if (themePanel != null)
            themePanel.SetActive(false);

        if (warningPanel != null)
            warningPanel.SetActive(false);
    }

    // Opens theme selection panel
    public void OnPlayButtonPressed()
    {
        themePanel.SetActive(true);
        if (AudioManager.instance != null)
            AudioManager.instance.PlayPopupOpen();
    }

    // Closes theme selection panel
    public void OnBackButtonPressed()
    {
        themePanel.SetActive(false);
    }

    // Select X theme for Player 1
    public void SelectP1Theme(int index)
    {
        player1XChoice = index;
    }

    // Select O theme for Player 2
    public void SelectP2Theme(int index)
    {
        player2OChoice = index;
    }

    //Opens warning popup
    public void OnWarningOkPressed()
    {
        warningPanel.SetActive(false);
    }

    // Start game if both players selected themes
    public void OnStartButtonPressed()
    {
        if (CanStartGame())
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            warningPanel.SetActive(true);
            if (AudioManager.instance != null)
                AudioManager.instance.PlayPopupOpen();
        }
    }

    bool CanStartGame()
    {
        return player1XChoice != -1 && player2OChoice != -1;
    }

    public Sprite GetXTheme()
    {
        return xThemes[player1XChoice];
    }

    public Sprite GetOTheme()
    {
        return oThemes[player2OChoice];
    }
}