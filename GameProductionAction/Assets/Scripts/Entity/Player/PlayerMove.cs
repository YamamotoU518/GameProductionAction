using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f;
    [SerializeField] private float _jumpPower = 2f;
    [SerializeField] private GameObject _pointer = default;

    private float _positionX;
    private float _positionY;
    private float _jumpHeight = 0f;
    private int _jumpCount = 0;
    
    void Update()
    {
        _positionX = gameObject.transform.position.x;
        _positionY = gameObject.transform.position.y;
        
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

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) >= 1)
        {
            float posX = Input.GetAxisRaw("Horizontal");
            _positionX += posX * _speed;
            gameObject.transform.position = new Vector2(_positionX, _positionY + _jumpHeight);
        }

        float x = _pointer.transform.position.x - gameObject.transform.position.x;
        float y = _pointer.transform.position.y - gameObject.transform.position.y;
        float radian = Mathf.Atan2(y, x);
        gameObject.transform.rotation = Quaternion.AngleAxis(radian * 180 / Mathf.PI, new Vector3(0, 0, 1));
    }
}
