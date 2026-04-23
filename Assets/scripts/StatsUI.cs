using TMPro;
using UnityEngine;

public class StatsUI : MonoBehaviour
{
    public TMP_Text totalGamesText;
    public TMP_Text p1WinsText;
    public TMP_Text p2WinsText;
    public TMP_Text drawsText;
    public TMP_Text avgTimeText;

    public GameObject statsPanel;

    public void OpenStats()
    {
        statsPanel.SetActive(true);
        Refresh();
        if (AudioManager.instance != null)
            AudioManager.instance.PlayPopupOpen();
    }

    public void CloseStats()
    {
        statsPanel.SetActive(false);
    }

    public void Refresh()
    {
        Debug.Log("StatsManager: " + StatsManager.Instance);
        Debug.Log("TotalGamesText: " + totalGamesText);
        var stats = StatsManager.Instance.stats;

        totalGamesText.text = "Total Games: " + stats.totalGames;
        p1WinsText.text = "Player 1 Wins: " + stats.player1Wins;
        p2WinsText.text = "Player 2 Wins: " + stats.player2Wins;
        drawsText.text = "Draws: " + stats.draws;

        float avg = stats.totalGames == 0 ? 0 : stats.totalTime / stats.totalGames;

        avgTimeText.text = "Avg Time: " + avg.ToString("F2") + "s";
    }
}