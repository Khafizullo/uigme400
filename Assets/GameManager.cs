using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private int _score;
    [SerializeField] private GameObject[] _item;
    [SerializeField] private Transform _grid;

    private GameItemButton _firstSelected;
    private GameItemButton _secondSelected;
    private bool _isProcessingTurn = false;
    private int _remainingCards;

    public bool IsProcessingTurn => _isProcessingTurn;

    void Start()
    {
        _scoreText.text = "000";
        _score = 0;
        SpawnLevelItems();
    }

    public void ScoreTotal(int value)
    {
        _score += value;
        _scoreText.text = _score.ToString();

        int savedHighScore = PlayerPrefs.GetInt("HighScore_TileGame", 0);
        if (_score > savedHighScore)
        {
            PlayerPrefs.SetInt("HighScore_TileGame", _score);
            PlayerPrefs.Save();
        }
    }

    public void NextLevel()
    {
        foreach (Transform child in _grid)
        {
            Destroy(child.gameObject);
        }
        SpawnLevelItems();
    }

    private void SpawnLevelItems()
    {
        _firstSelected = null;
        _secondSelected = null;
        _isProcessingTurn = false;

        int totalCards = 16;
        _remainingCards = totalCards;

        List<int> cardSetupList = new List<int>();
        for (int i = 0; i < totalCards / 2; i++)
        {
            int randomTypeIndex = Random.Range(0, _item.Length);
            cardSetupList.Add(randomTypeIndex);
            cardSetupList.Add(randomTypeIndex);
        }

        for (int i = 0; i < cardSetupList.Count; i++)
        {
            int temp = cardSetupList[i];
            int randomIndex = Random.Range(i, cardSetupList.Count);
            cardSetupList[i] = cardSetupList[randomIndex];
            cardSetupList[randomIndex] = temp;
        }

        for (int i = 0; i < cardSetupList.Count; i++)
        {
            int itemTypeIndex = cardSetupList[i];

            GameObject clonedItem = Instantiate(_item[itemTypeIndex], transform.position, Quaternion.identity);
            clonedItem.transform.SetParent(_grid, false);

            GameItemButton itemScript = clonedItem.GetComponent<GameItemButton>();
            if (itemScript != null)
            {
                itemScript.SetupButton(this, itemTypeIndex);
            }
        }
    }

    public void CardSelected(GameItemButton clickedCard)
    {
        if (_firstSelected == null)
        {
            _firstSelected = clickedCard;
        }
        else
        {
            _secondSelected = clickedCard;
            StartCoroutine(CheckMatchRoutine());
        }
    }

    private IEnumerator CheckMatchRoutine()
    {
        _isProcessingTurn = true;

        yield return new WaitForSeconds(0.6f);

        if (_firstSelected.CardTypeID == _secondSelected.CardTypeID)
        {
            // MATCH FOUND: Award points
            ScoreTotal(10);

            // FIXED: Call the placeholder hide function instead of destroying the objects
            _firstSelected.DisableCardOnMatch();
            _secondSelected.DisableCardOnMatch();

            _remainingCards -= 2;

            if (_remainingCards <= 0)
            {
                NextLevel();
            }
        }
        else
        {
            _firstSelected.HideCard();
            _secondSelected.HideCard();
        }

        _firstSelected = null;
        _secondSelected = null;
        _isProcessingTurn = false;
    }
}