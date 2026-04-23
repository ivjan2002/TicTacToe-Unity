using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Singleton instance for global access
    public static GameManager Instance;

    public bool isPlayerXTurn = true;

    [Header("UI")]
    public GameObject gameOverPopUp;
    public TMP_Text winText;

    [Header("HUD")]
    public TMP_Text timerText;
    public TMP_Text movesText;

    [Header("Fireworks")]
    public GameObject fireworksContainer;
    public RectTransform firework1;
    public RectTransform firework2;

    private Cell[,] board = new Cell[3, 3];
    private bool gameEnded = false;

    // timer
    private float timer = 0f;
    private bool timerRunning = true;

    // moves
    private int totalMoves = 0;
    private int player1Moves = 0;
    private int player2Moves = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SetupBoard();
        gameOverPopUp.SetActive(false);
    }

    void Update()
    {
        if (!timerRunning) return;

        timer += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    // Map all cells into 2D board array
    void SetupBoard()
    {
        Cell[] cells = FindObjectsOfType<Cell>();

        foreach (Cell c in cells)
        {
            int x = c.index % 3;
            int y = c.index / 3;
            board[x, y] = c;
        }
    }

    public Sprite GetCurrentXTheme()
    {
        return ThemeManager.Instance.xThemes[ThemeManager.Instance.player1XChoice];
    }

    public Sprite GetCurrentOTheme()
    {
        return ThemeManager.Instance.oThemes[ThemeManager.Instance.player2OChoice];
    }

    public void SwitchTurn()
    {
        isPlayerXTurn = !isPlayerXTurn;
    }

    // Register a move and update counters
    public void RegisterMove()
    {
        totalMoves++;

        if (isPlayerXTurn)
            player1Moves++;
        else
            player2Moves++;

        UpdateMovesUI();
    }

    void UpdateMovesUI()
    {
        movesText.text =
            $"Moves: {totalMoves} | Player 1: {player1Moves} | Player 2: {player2Moves}";
    }

    // Check all win conditions
    public void CheckWin()
    {
        if (gameEnded) return;

        for (int i = 0; i < 3; i++)
        {
            if (CheckLine(board[i, 0], board[i, 1], board[i, 2]))
            {
                EndGame(board[i, 0]);
                return;
            }

            if (CheckLine(board[0, i], board[1, i], board[2, i]))
            {
                EndGame(board[0, i]);
                return;
            }
        }

        if (CheckLine(board[0, 0], board[1, 1], board[2, 2]))
        {
            EndGame(board[0, 0]);
            return;
        }

        if (CheckLine(board[0, 2], board[1, 1], board[2, 0]))
        {
            EndGame(board[0, 2]);
            return;
        }

        if (totalMoves >= 9)
        {
            EndDraw();
        }
    }

    bool CheckLine(Cell a, Cell b, Cell c)
    {
        if (a == null || b == null || c == null) return false;

        return (a.hasX && b.hasX && c.hasX) ||
               (a.hasO && b.hasO && c.hasO);
    }

    // Handle win state
    void EndGame(Cell winnerCell)
    {
        if (gameEnded) return;

        gameEnded = true;
        timerRunning = false;

        var stats = StatsManager.Instance.stats;

        stats.totalGames++;
        stats.totalTime += timer;

        if (winnerCell.hasX)
            stats.player1Wins++;
        else
            stats.player2Wins++;

        StatsManager.Instance.SaveStats();

        StartCoroutine(PlayWinSequence(winnerCell));

    }

    // Handle draw state
    void EndDraw()
    {
        gameEnded = true;
        timerRunning = false;

        var stats = StatsManager.Instance.stats;

        stats.totalGames++;
        stats.totalTime += timer;
        stats.draws++;

        StatsManager.Instance.SaveStats();

        gameOverPopUp.SetActive(true);

        winText.text = $"Draw!\nTime: {timerText.text}";
    }

    IEnumerator PlayWinSequence(Cell winnerCell)
    {
        AudioManager.instance.PlayWinSFX();
        yield return new WaitForSeconds(0.1f);

        fireworksContainer.SetActive(true);

        yield return StartCoroutine(PlayFireworksAnimation());

        fireworksContainer.SetActive(false);

        gameOverPopUp.SetActive(true);

        string winner =
            winnerCell.hasX ? "Player 1 wins" : "Player 2 wins";

        winText.text =
            $"{winner}\nTime: {timerText.text}";
    }

    //Animation
    IEnumerator PlayFireworksAnimation()
    {
        float duration = 0.8f;
        float t = 0f;

        Vector3 startScale = Vector3.zero;
        Vector3 endScale = Vector3.one * 6f;

        CanvasGroup cg1 = firework1.GetComponent<CanvasGroup>();
        CanvasGroup cg2 = firework2.GetComponent<CanvasGroup>();

        if (cg1 == null) cg1 = firework1.gameObject.AddComponent<CanvasGroup>();
        if (cg2 == null) cg2 = firework2.gameObject.AddComponent<CanvasGroup>();

        firework1.localScale = startScale;
        firework2.localScale = startScale;

        cg1.alpha = 1f;
        cg2.alpha = 1f;

        while (t < duration)
        {
            t += Time.deltaTime;
            float progress = t / duration;

            firework1.localScale = Vector3.Lerp(startScale, endScale, progress);
            firework2.localScale = Vector3.Lerp(startScale, endScale, progress);
            cg1.alpha = 1f - progress;
            cg2.alpha = 1f - progress;

            yield return null;
        }

        firework1.localScale = endScale;
        firework2.localScale = endScale;

        cg1.alpha = 0f;
        cg2.alpha = 0f;

        yield return new WaitForSeconds(0.2f);
    }

    // Reset full game state
    public void ResetGame()
    {
        isPlayerXTurn = true;
        gameEnded = false;

        timer = 0f;
        timerRunning = true;

        totalMoves = 0;
        player1Moves = 0;
        player2Moves = 0;

        UpdateMovesUI();
        timerText.text = "00:00";

        Cell[] cells = FindObjectsOfType<Cell>();

        foreach (Cell c in cells)
        {
            c.ResetCell();
        }

        SetupBoard();
    }
}