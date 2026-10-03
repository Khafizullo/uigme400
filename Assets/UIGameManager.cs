using UnityEngine;

public class UIGameManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _gamesMenuPanel;

    [Header("Actual Games")]
    [SerializeField] private GameObject _dragAndDropGame;
    [SerializeField] private GameObject _tileGame;
    [SerializeField] private GameObject _mathGame;

    void Start()
    {
        // Start the game by showing only the Main Menu
        ShowMainMenu();
    }

    // --- Menu Navigation ---

    public void ShowMainMenu()
    {
        _mainMenuPanel.SetActive(true);
        _settingsPanel.SetActive(false);
        _gamesMenuPanel.SetActive(false);

        // Turn off games if we return to the main menu
        DeactivateAllGames();
    }

    public void OpenGamesMenu()
    {
        _mainMenuPanel.SetActive(false);
        _settingsPanel.SetActive(false);
        _gamesMenuPanel.SetActive(true);

        // Turn off whichever game was just running when looking at the catalog
        DeactivateAllGames();
    }

    public void OpenSettings()
    {
        _mainMenuPanel.SetActive(false);
        _settingsPanel.SetActive(true);
        _gamesMenuPanel.SetActive(false);
    }

    // NEW: Call this from your Settings window's Cancel/Back button
    public void CloseSettings()
    {
        _settingsPanel.SetActive(false);
        _mainMenuPanel.SetActive(true); // Seamlessly return to the main menu
    }

    public void OpenMainMenu()
    {
        _mainMenuPanel.SetActive(true);
        _settingsPanel.SetActive(false);
        _gamesMenuPanel.SetActive(false);

        // Clean up active games when returning to main menu via this method
        DeactivateAllGames();
    }

    public void ExitApplication()
    {
        Debug.Log("Exiting Game...");
        Application.Quit();
    }

    // --- Game Launchers ---

    public void PlayDragAndDrop()
    {
        DeactivateAllGames(); // Safety check: clear any active games first
        _gamesMenuPanel.SetActive(false);
        _dragAndDropGame.SetActive(true);
    }

    public void PlayTileGame()
    {
        DeactivateAllGames(); // Safety check
        _gamesMenuPanel.SetActive(false);
        _tileGame.SetActive(true);
    }

    public void PlayMathGame()
    {
        DeactivateAllGames(); // Safety check
        _gamesMenuPanel.SetActive(false);
        _mathGame.SetActive(true);
    }

    private void DeactivateAllGames()
    {
        if (_dragAndDropGame != null) _dragAndDropGame.SetActive(false);
        if (_tileGame != null) _tileGame.SetActive(false);
        if (_mathGame != null) _mathGame.SetActive(false);
    }
}