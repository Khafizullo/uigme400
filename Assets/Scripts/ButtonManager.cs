using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonManager : MonoBehaviour
{

    [SerializeField] private Toggle[] _toggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Toggle0True()
    {
        if (_toggle[0].isOn == true)
        {
            Debug.Log("Game set to Easy");
        }
    }

    public void Toggle1True()
    {
        if(_toggle[1].isOn == true)
        {
            Debug.Log("Game set to medium");
        }
    }

    public void Toggle2True()
    {
        if( _toggle[2].isOn == true)
        {
            Debug.Log("Game set to Hard");
        }
    }
}
