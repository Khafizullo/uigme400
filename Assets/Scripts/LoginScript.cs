using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class LoginScript : MonoBehaviour
{
    [SerializeField] private TMP_InputField[] _inputFields;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private GameObject _create;
    [SerializeField] private GameObject _login;
    [SerializeField] private TextMeshProUGUI _debugText;
    [SerializeField] private string _userName;
    [SerializeField] private string _password;
    // Start is called before the first frame update
    void Start()
    {
        _debugText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoginAccount()
    {
        if (_inputFields[2].text == _userName && _inputFields[3].text == _password)
        {
            if(_userName == "" || _password == "")
            {
                _debugText.text = "There is no account, Please create account";
                _inputFields[2].text = "";
                _inputFields[3].text = "";
            }
            else
            {
                _debugText.text = "You have succesfully loggedin";
            }
            
        }
        if(_userName == null || _password == null)
        {
            _debugText.text = "There is no account, Please create account";
            _inputFields[2].text = "";
            _inputFields[3].text = "";
        }
        if (_inputFields[2].text != _userName || _inputFields[3].text != _password)
        {
            _debugText.text = "Wrong username or password, please check again or create a new";
            _inputFields[2].text = "";
            _inputFields[3].text = "";
        }
    }

    public void CreateAccount()
    {
        if (_inputFields[0].text.Length > 3 && _inputFields[1].text.Length > 3)
        {
            _userName = _inputFields[0].text;
            _password = _inputFields[1].text;
            _debugText.text = "Account successfully created";
            Debug.Log("UserName is: " + _userName);
            Debug.Log("Password is: " + _password);
            OpenLoginAccountMenu();
        }
        else
        {
            _debugText.text = "Your username and password must be  at least 4 or more";
            _inputFields[0].text = "";
            _inputFields[1].text = "";
        }
        

    }

    public void OpenCreateAccountMenu()
    {
        _login.SetActive(false);
        _create.SetActive(true);
    }

    public void OpenLoginAccountMenu()
    {
        _login.SetActive(true);
        _create.SetActive(false);
    }
}
