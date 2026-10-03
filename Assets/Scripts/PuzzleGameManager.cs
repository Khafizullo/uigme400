using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuzzleGameManager : MonoBehaviour
{
    [Header("Game Settings")]
    [SerializeField] private int totalPieces = 25;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject winPanel;

    [Header("Piece Container for Shuffling")]
    [SerializeField] private Transform pieceTray;

    private int _placedPieces = 0;

    void Start()
    {
        _placedPieces = 0;
        UpdateScoreDisplay();
        ShufflePieces();


        if (winPanel != null)
            winPanel.SetActive(false);

        // Delay shuffle by 1 frame to let GridLayoutGroup initialize properly
        StartCoroutine(StartShuffleRoutine());
    }

    private IEnumerator StartShuffleRoutine()
    {
        yield return null; // Wait 1 frame
        ShufflePieces();
    }

    public void OnPiecePlacedCorrectly()
    {
        _placedPieces++;
        UpdateScoreDisplay();

        if (_placedPieces >= totalPieces)
        {
            OnPuzzleCompleted();
        }
    }

    // Public method for UI Button OnClick()
    public void ShufflePieces()
    {
        if (pieceTray == null)
        {
            Debug.LogWarning("PieceTray is not assigned in the Inspector!");
            return;
        }

        int childCount = pieceTray.childCount;
        if (childCount <= 1) return;

        // Collect all child Transforms into a list
        List<Transform> children = new List<Transform>();
        for (int i = 0; i < childCount; i++)
        {
            children.Add(pieceTray.GetChild(i));
        }

        // Fisher-Yates Shuffle Algorithm
        for (int i = children.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            Transform temp = children[i];
            children[i] = children[randomIndex];
            children[randomIndex] = temp;
        }

        // Apply new order to Unity Hierarchy
        for (int i = 0; i < children.Count; i++)
        {
            children[i].SetSiblingIndex(i);
        }

        // Force Grid Layout Group to rebuild UI immediately
        UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate(pieceTray as RectTransform);
    }

    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Progress: {_placedPieces}/{totalPieces}";
        }
    }

    private void OnPuzzleCompleted()
    {
        Debug.Log("Puzzle Completed!");
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }

        int currentBest = PlayerPrefs.GetInt("HighScore_Puzzle", 0);
        if (_placedPieces > currentBest)
        {
            PlayerPrefs.SetInt("HighScore_Puzzle", _placedPieces);
            PlayerPrefs.Save();
        }
    }
}