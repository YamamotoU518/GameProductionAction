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
        _xMin = gameObject.transform.position.x - 0.25f;
        _xMax = gameObject.transform.position.x + 0.25f;
        _yMin = gameObject.transform.position.y - 0.125f;
        _yMax = gameObject.transform.position.y + 0.125f;

       
        _playerXMin = _player.transform.position.x - 0.25f;
        _playerXMax = _player.transform.position.x + 0.25f;
        _playerYMin = _player.transform.position.y - 0.25f;
        _playerYMax = _player.transform.position.y + 0.25f;

        if (_xMin <= _playerXMax && _playerXMin <= _xMax && _yMin <= _playerYMax && _playerYMin <= _yMax)
        {
            _player.Hp--;
            Destroy(this.gameObject);
        }
    }
}
