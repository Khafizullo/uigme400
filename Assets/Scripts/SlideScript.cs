using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlideScript : MonoBehaviour
{

    [SerializeField] private Toggle[] _toggle;
    [SerializeField] private Sprite[] _dinoPics;
    [SerializeField] private Image _picField;
    [SerializeField] private TextMeshProUGUI _textField;
    //Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle0()
    {
        if (_toggle[0].isOn == true)
        {
            _picField.sprite = _dinoPics[0];
            _textField.text = "Horseplay is allowed";
        }

        if (_toggle[1].isOn == true)
        {
            _picField.sprite = _dinoPics[1];
            _textField.text = "Horseplay is allowed but be carefull";
        }

        if (_toggle[2].isOn == true)
        {
            _picField.sprite = _dinoPics[2];
            _textField.text = "Horseplay is not allowed";
        }
    }

}
