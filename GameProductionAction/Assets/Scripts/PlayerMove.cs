using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f;
    [SerializeField] private float _jumpPower = 2f;

    private float _positionX;
    private float _positionY;
    private float _jumpHeight = 0f;
    private int _jumpCount = 0;
    void Start()
    {
        _positionX = this.gameObject.transform.position.x;
        _positionY = this.gameObject.transform.position.y;

    }

    void Update()
    {
        float _x = Input.GetAxisRaw("Horizontal");
        if (_jumpHeight > 0f) { _jumpHeight -= 0.01f; }
        else
        {
            _jumpHeight = 0f;
            _jumpCount = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_jumpCount < 2)
            {
                _jumpHeight += _jumpPower;
                _jumpCount++;
            }
        }

        _positionX += _x * _speed;
        this.gameObject.transform.position = new Vector2(_positionX, _positionY + _jumpHeight);
    }
}
