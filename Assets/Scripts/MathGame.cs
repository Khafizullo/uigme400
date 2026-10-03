using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MathGame : MonoBehaviour
{
    [Header("UI Text Fields")]
    [SerializeField] private TextMeshProUGUI[] _textFields; // 0: Num1, 1: Num2, 2: Feedback
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _number1;
    private int _number2;
    private int _hiddenAnswer;
    private int _score;

    // NEW: Tracks if the player has already failed the current question
    private bool _hasAnswered;

    void Start()
    {
        _score = 0;
        UpdateScoreDisplay();
        GenerateNewQuestion();
    }

    private void CalculateAnswer()
    {
        _hiddenAnswer = _number1 + _number2;
    }

    public void AnswerQuestion()
    {
        // If they already answered incorrectly, stop them from submitting another guess
        if (_hasAnswered) return;

        // Safe check: TryParse prevents crashes if the input field is blank
        if (int.TryParse(_inputField.text, out int playerAnswer))
        {
            if (playerAnswer == _hiddenAnswer)
            {
                _score += 1;
                UpdateScoreDisplay();

                // CORRECT: Automatically jump directly to the next question layout
                GenerateNewQuestion();
            }
            else
            {
                // INCORRECT: Display the correct answer and freeze submissions
                _textFields[2].text = "Wrong! The correct answer is " + _hiddenAnswer;
                _score -= 1;
                UpdateScoreDisplay();

                _hasAnswered = true;   // Lock out further answer attempts for this problem
                _inputField.text = ""; // Clear out their wrong answer text string
            }
        }
        else
        {
            _textFields[2].text = "Please enter a number first!";
        }
    }

    public void Next()
    {
        // Allows them to clear the wrong answer state manually by moving forward
        GenerateNewQuestion();
    }

    private void GenerateNewQuestion()
    {
        _hasAnswered = false; // Reset the lockout state flag for the new problem

        _number1 = Random.Range(0, 99);
        _number2 = Random.Range(0, 99);
        _textFields[0].text = _number1.ToString();
        _textFields[1].text = _number2.ToString();
        _textFields[2].text = "Calculate";

        CalculateAnswer();
        _inputField.text = "";
    }

    private void UpdateScoreDisplay()
    {
        if (_scoreText != null)
        {
            _scoreText.text = "Score: " + _score;
        }

        // Keep saving high scores cleanly for your GamesMenuDisplay script
        int savedHighScore = PlayerPrefs.GetInt("HighScore_MathGame", 0);
        if (_score > savedHighScore)
        {
            PlayerPrefs.SetInt("HighScore_MathGame", _score);
            PlayerPrefs.Save();
        }
    }
}