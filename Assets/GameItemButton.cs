using UnityEngine;
using UnityEngine.UI;

public class GameItemButton : MonoBehaviour
{
    [SerializeField] private GameObject _coverOverlay;

    private GameManager _manager;
    private int _cardTypeID;
    private bool _isRevealed = false;

    public int CardTypeID => _cardTypeID;

    public void SetupButton(GameManager manager, int typeID)
    {
        _manager = manager;
        _cardTypeID = typeID;

        HideCard();

        Button btn = GetComponentInChildren<Button>();
        if (btn != null)
        {
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(OnCardClicked);
        }
    }

    private void OnCardClicked()
    {
        if (_isRevealed || _manager.IsProcessingTurn) return;

        RevealCard();
        _manager.CardSelected(this);
    }

    public void RevealCard()
    {
        _isRevealed = true;
        if (_coverOverlay != null) _coverOverlay.SetActive(false);
    }

    public void HideCard()
    {
        _isRevealed = false;
        if (_coverOverlay != null) _coverOverlay.SetActive(true);
    }

    // NEW: Hides all visuals but keeps the cell space intact in the Grid Layout Group
    public void DisableCardOnMatch()
    {
        _isRevealed = true; // Lock interactions permanently

        // Turn off every child object under this prefab (Image_BG, Image_item, Cover, etc.)
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}