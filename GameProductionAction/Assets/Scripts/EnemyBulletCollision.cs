using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyBulletCollision : MonoBehaviour
{
    private Player _player;
    private float _xMin;
    private float _xMax;
    private float _yMin;
    private float _yMax;
    private float _playerXMin;
    private float _playerXMax;
    private float _playerYMin;
    private float _playerYMax;
    
    void Start()
    {
        _player = GameObject.FindObjectOfType<Player>();
    }
    
    void Update()
    {
        _xMin = gameObject.transform.position.x - gameObject.transform.localScale.x / 2;
        _xMax = gameObject.transform.position.x + gameObject.transform.localScale.x / 2;
        _yMin = gameObject.transform.position.y - gameObject.transform.localScale.y / 2;
        _yMax = gameObject.transform.position.y + gameObject.transform.localScale.y / 2;

       
        _playerXMin = _player.transform.position.x - _player.transform.localScale.x / 2;
        _playerXMax = _player.transform.position.x + _player.transform.localScale.x / 2;
        _playerYMin = _player.transform.position.y - _player.transform.localScale.y / 2;
        _playerYMax = _player.transform.position.y + _player.transform.localScale.y / 2;

        if (_xMin <= _playerXMax && _playerXMin <= _xMax && _yMin <= _playerYMax && _playerYMin <= _yMax)
        {
            _player.Hp--;
            Destroy(this.gameObject);
        }
    }
}
