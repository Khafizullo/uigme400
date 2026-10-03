using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _menu1;
    [SerializeField] private GameObject _menu2;
    // Start is called before the first frame update
    void Start()
    {
        _menu1.SetActive(true);
        _menu2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateMenu()
    {
        _menu2.SetActive(true);
        _menu1.SetActive(false);
    }
}
