using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TestScript : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropDown;
    [SerializeField] private TextMeshProUGUI _levelText;
    // Start is called before the first frame update
    void Start()
    {
        _levelText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropDownValue()
    {

        if(_dropDown.value == 0)
        {
            _levelText.text = "Easy level";
        }
        if( _dropDown.value == 1)
        {
            _levelText.text = "Medium level";
        }
        if(_dropDown.value == 2)
        {
            _levelText.text = "Hard level";
        }
    }
}
