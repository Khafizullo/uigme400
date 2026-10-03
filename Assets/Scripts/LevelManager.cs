using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _textField;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoadScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("NextScene");

        while(!asyncLoad.isDone)
        {
            _slider.value = asyncLoad.progress;
            _textField.text = asyncLoad.progress.ToString();
            yield return null;
        }
    }
}
