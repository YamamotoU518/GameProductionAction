using UnityEngine;

public enum PlayerState
{
    Normal,
    SuperArmor
}

public class Player : MonoBehaviour, IEntity
{
    [SerializeField, Header("普通の弾")] private GameObject _bullet = default;
    [SerializeField, Header("レーザー")] private GameObject _laserBullet = default;
    [SerializeField] private float _superArmorTime = 1f;
    [SerializeField] private PlayerState _playerState = PlayerState.Normal;

    /// <summary> これ以上押したら長押しとみなす </summary>
    [SerializeField] private float _longClickTime = default;
    /// <summary> 押された時間の長さ </summary>
    private float _clickTime = default;

    private KnockBack _knockBack = default;
    
    private int _hp = default;
    private float _timer = default;
  
    void Start()
    {
        _hp = 5;
        _knockBack = gameObject.GetComponent<KnockBack>();
    }

    void Update()
    {
        KeyRelease();

        KeyPress();

        if (_playerState == PlayerState.SuperArmor)
        {
            _timer += Time.deltaTime;
            if (_timer >= _superArmorTime)
            {
                _playerState = PlayerState.Normal;
                _timer = 0;
            }
        }
    }

    private void KeyPress()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            _clickTime += Time.deltaTime;
            //Debug.Log(_clickTime);
        }
    }

    private void KeyRelease()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
             Instantiate(_clickTime < _longClickTime ? _bullet : _laserBullet, 
                 gameObject.transform.position, 
                 gameObject.transform.rotation);
            _clickTime = 0;
        }
    }
    public void Damage(int damage, int direction)
    {
        if (_playerState == PlayerState.SuperArmor) { return; }
        _hp -= damage;
        _knockBack.Damage(direction);
        _playerState = PlayerState.SuperArmor;
    }
}
