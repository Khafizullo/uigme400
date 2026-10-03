using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] protected GameObject _enemy;
    [SerializeField] private Image _enemyPos;
    [SerializeField] private Image _mapPos;

    // Update is called once per frame
    void Update()
    {
        _mapPos.rectTransform.localPosition = new Vector3(_player.transform.position.x * -1, _player.transform.position.z * -1, 0);
        _enemyPos.rectTransform.localPosition = new Vector3(_enemy.transform.position.x, _enemy.transform.position.z, 0);
    }
}
