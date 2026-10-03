using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private int _buttonValue;
    [SerializeField] private PINNumber _pinNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DisplayButtonValue()
    {
        _pinNumber.AddDigit(_buttonValue.ToString());
    }
}
