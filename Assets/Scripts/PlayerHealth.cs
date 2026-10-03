using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _healthNumber;
    [SerializeField] private int _health;
    // Start is called before the first frame update
    void Start()
    {
        _health = 100;
        _slider.value = _health;
        _healthNumber.text = _health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if(_health >= 1)
            {
                _health -= 20;
                _slider.value = _health;
                _healthNumber.text = _health.ToString();
            }
            
            
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            if(_health < 99)
            {
                _health += 20;
                _slider.value = _health;
                _healthNumber.text = _health.ToString();
            }
            
        }
    }
}
