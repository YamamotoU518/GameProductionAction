using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f;
    [SerializeField] private float _jumpPower = 1f;

    private float _positionX;
    private float _positionY;
    private float _jumpHeight = 0f;
    void Start()
    {
        _positionX = this.gameObject.transform.position.x;
        _positionY = this.gameObject.transform.position.y;

    }

    void Update()
    {
        float _x = Input.GetAxisRaw("Horizontal");
        if (_jumpHeight > 0f) { _jumpHeight -= 0.01f; }

        if (Input.GetKeyDown(KeyCode.Space)) { _jumpHeight = _jumpPower; }

        _positionX += _x * _speed;
        this.gameObject.transform.position = new Vector2(_positionX, _positionY + _jumpHeight);
    }
}
