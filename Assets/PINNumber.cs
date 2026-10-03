using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PINNumber : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textBox;
    private string _secretPIN = "1212";
    private string _actualPIN;
    // Start is called before the first frame update
    void Start()
    {
        _textBox.text = "Enter PIN";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddDigit(string number)
    {
        _textBox.text = "";
        _actualPIN += number;
        _textBox.text = _actualPIN;
    }

    public void Submit()
    {
        if(_secretPIN == _actualPIN)
        {
            _textBox.text = "PIN accepted";
            _actualPIN = null;
        }
        else
        {
            _actualPIN = null;
            _textBox.text = "Invalid PIN";
        }
    }

    public void Clear()
    {
        _actualPIN = "";
        _textBox.text = null;
    }
}
