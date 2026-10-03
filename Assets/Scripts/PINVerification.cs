using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PINVerification : MonoBehaviour
{
    [SerializeField] private TMP_InputField _createPIN;
    [SerializeField] private TMP_InputField _enterPIN;
    [SerializeField] private TextMeshProUGUI _debugText;

    private int _pinNumber;
    private int _enteredPINNumber;
    // Start is called before the first frame update
    void Start()
    {
        _debugText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePIN()
    {
        if(_createPIN.text.Length < 4)
        {
            _debugText.text = "Error - I need at least 4 digits";
            _createPIN.text = "";
        }
        else
        {
            _pinNumber = int.Parse( _createPIN.text );
            _createPIN.gameObject.SetActive( false );
            _enterPIN.gameObject.SetActive( true );
            _debugText.text = "";
        }
    }

    public void EnterPIN()
    {
        _enteredPINNumber = int.Parse(_enterPIN.text);
        if(_pinNumber == _enteredPINNumber)
        {
            _debugText.text = "Correct PIN entered!";
        }
        else
        {
            _debugText.text = "Incorrect PIN entered!";
            _enterPIN.text = "";
        }
    }
}
