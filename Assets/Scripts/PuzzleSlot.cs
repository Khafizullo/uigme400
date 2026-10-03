using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleSlot : MonoBehaviour, IDropHandler
{
    public int slotID; // Set this in Inspector to match the target piece's pieceID
    private PuzzleGameManager _gameManager;

    void Start()
    {
        _gameManager = FindObjectOfType<PuzzleGameManager>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;

        PuzzlePiece piece = eventData.pointerDrag.GetComponent<PuzzlePiece>();

        if (piece != null)
        {
            // Check if piece matches this slot ID
            if (piece.pieceID == slotID)
            {
                // Correct Drop!
                piece.SnapToSlot(transform);
                piece.LockPiece();

                if (_gameManager != null)
                {
                    _gameManager.OnPiecePlacedCorrectly();
                }
            }
            else
            {
                // Incorrect slot -> send piece back to inventory
                piece.ResetToStart();
            }
        }
    }
}