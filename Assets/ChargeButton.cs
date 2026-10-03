using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class ChargeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Slider _slider;
    [SerializeField] private UnityEngine.UI.Button _chargeButton;
    [SerializeField] private TextMeshProUGUI _textField;
    [SerializeField] private Animator _anim;

    private float _charge;
    private bool _chargeBool;

    public void OnPointerDown(PointerEventData eventData)
    {
        _chargeBool = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _chargeBool = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        _textField.text = "No Charge";      
    }

    // Update is called once per frame
    void Update()
    {
        if(_chargeBool == true)
        {
            if(_charge <= 100)
            {
                _charge += 50.0f * Time.deltaTime;
            }
            _slider.value = _charge;
            ChangeAnimSpeed();
            _textField.text = "Charging...";
        }

        if(_chargeBool == false)
        {
            if( _charge > 0)
            {
                _charge -= 300.0f * Time.deltaTime;
            }
            _slider.value = _charge;
            _textField.text = "No Charge";
        }
    }

    public void ChangeAnimSpeed()
    {
        if(_charge < 30f)
        {

            _anim.speed = 1;
        }
        if(_charge > 30f && _charge < 70f)
        {
            _anim.speed = 2;
        }
        if(_charge > 70f && _charge < 100f)
        {
            _anim.speed = 3;
        }
    }
}
