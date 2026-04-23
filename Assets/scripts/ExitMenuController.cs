using UnityEngine;

public class ExitMenuController : MonoBehaviour
{
    [Header("UI References")]
    public GameObject exitPanel;

    // Ensure panel is hidden at game start
    void Start()
    {
        exitPanel.SetActive(false);
    }

    // Show exit panel
    public void OnExitButtonPressed()
    {
        exitPanel.SetActive(true);
        if (AudioManager.instance != null)
            AudioManager.instance.PlayPopupOpen();
    }

    // Closes the exit panel
    public void OnNoButtonPressed()
    {
        exitPanel.SetActive(false);
    }

    // Quits the game
    public void OnYesButtonPressed()
    {
        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
        Debug.Log("Game exited");
#endif
    }
}
