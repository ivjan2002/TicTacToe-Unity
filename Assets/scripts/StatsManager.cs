using UnityEngine;

[System.Serializable]
public class GameStats
{
    public int totalGames;
    public int player1Wins;
    public int player2Wins;
    public int draws;
    public float totalTime;
}

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;
    public GameStats stats = new GameStats();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadStats();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveStats()
    {
        string json = JsonUtility.ToJson(stats);
        PlayerPrefs.SetString("STATS", json);
        PlayerPrefs.Save();
    }

    public void LoadStats()
    {
        if (PlayerPrefs.HasKey("STATS"))
        {
            string json = PlayerPrefs.GetString("STATS");
            stats = JsonUtility.FromJson<GameStats>(json);
        }
    }
}