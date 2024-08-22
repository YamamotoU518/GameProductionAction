using UnityEngine;

public class RushEnemy : MonoBehaviour
{
    private Player _player = default;
    private bool _goToPlayer = false;
    private Vector3 _playerPos = default;

    private float _xMin = default;
    private float _xMax = default;
    private float _yMin = default;
    private float _yMax = default;
    
    void Start()
    {
        _player = FindObjectOfType<Player>();
    }
    
    void Update()
    {
        var _distance = Vector3.Distance(this.gameObject.transform.position, _player.gameObject.transform.position);
        if (_distance < 5f && _goToPlayer == false)
        {
            _goToPlayer = true;
            _playerPos = _player.transform.position;
        }

        if (_goToPlayer)
        {
            transform.position += transform.TransformDirection(_playerPos) * Time.deltaTime;
            UpdateBounds();
            TargetSet();
        }

        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }
    
    private void UpdateBounds()
    {
        _xMin = transform.position.x - transform.localScale.x / 2;
        _xMax = transform.position.x + transform.localScale.x / 2;
        _yMin = transform.position.y - transform.localScale.y / 2;
        _yMax = transform.position.y + transform.localScale.y / 2;
    }

    private void TargetSet()
    {
        float playerXMin = _player.transform.position.x - _player.transform.localScale.x / 2;
        float playerXMax = _player.transform.position.x + _player.transform.localScale.x / 2;
        float playerYMin = _player.transform.position.y - _player.transform.localScale.y / 2;
        float playerYMax = _player.transform.position.y + _player.transform.localScale.y / 2;

        if (_xMin <= playerXMax && playerXMin <= _xMax && _yMin <= playerYMax && playerYMin <= _yMax)
        {
            _player.Damage(1);
        }
    }
}
