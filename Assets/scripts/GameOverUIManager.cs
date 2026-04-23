using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour
{
    // reset game state
    public void OnRetry()
    {
        GameManager.Instance.ResetGame();

        gameObject.SetActive(false);
    }

    //exit game
    public void OnExit()
    {
        Destroy(ThemeManager.Instance.gameObject);
        SceneManager.LoadScene("PlayScene");
    }
}