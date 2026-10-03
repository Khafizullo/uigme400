using UnityEngine;
using TMPro;

public class GamesMenuDisplay : MonoBehaviour
{
    [Header("Best Score Text Objects")]
    [SerializeField] private TextMeshProUGUI _dragDropBestText;
    [SerializeField] private TextMeshProUGUI _tileGameBestText;
    [SerializeField] private TextMeshProUGUI _mathGameBestText;

    // This automatically runs every single time the GamesMenu panel is activated
    void OnEnable()
    {
        RefreshHighScoreDisplays();
    }

    public void RefreshHighScoreDisplays()
    {
        // Pull the integers from local storage (defaults to 0 if they haven't played yet)
        int dragDropHigh = PlayerPrefs.GetInt("HighScore_DragDrop", 0);
        int tileGameHigh = PlayerPrefs.GetInt("HighScore_TileGame", 0);
        int mathGameHigh = PlayerPrefs.GetInt("HighScore_MathGame", 0);

        // Assign the values cleanly to your TextMeshPro components
        if (_dragDropBestText != null) _dragDropBestText.text = "Best: " + dragDropHigh;
        if (_tileGameBestText != null) _tileGameBestText.text = "Best: " + tileGameHigh;
        if (_mathGameBestText != null) _mathGameBestText.text = "Best: " + mathGameHigh;
    }

    // Optional helper function: You can call this from a custom button if you ever want to clear records
    public void ResetAllHighScores()
    {
        PlayerPrefs.DeleteKey("HighScore_DragDrop");
        PlayerPrefs.DeleteKey("HighScore_TileGame");
        PlayerPrefs.DeleteKey("HighScore_MathGame");
        RefreshHighScoreDisplays();
    }
}