using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioScript : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioSource _source;
    [SerializeField] private float _pitch;
    
    public void PlayeKey()
    {
        _source.pitch = _pitch;
        _source.PlayOneShot(_clip);
    }
}
