using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UserInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputName;
    [SerializeField] private TMP_InputField _inputPassword;
    [SerializeField] private TextMeshProUGUI _inputText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputFieldName()
    {
        PlayerPrefs.SetString("name", _inputName.text);
    }

    public void InputFieldPassword()
    {
        PlayerPrefs.SetString("password", _inputPassword.text);
    }

    public void InputFieldText()
    {
        _inputText.text = "Your name is " + PlayerPrefs.GetString("name") + "Your password is " + PlayerPrefs.GetString("password");
    }
}
