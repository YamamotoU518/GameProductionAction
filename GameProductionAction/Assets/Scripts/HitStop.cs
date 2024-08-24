using UnityEngine;

public class HitStop : MonoBehaviour
{
    private Player _player = default;
    private PlayerMove _playerMove = default;
    private Enemy[] _enemies = default;
    private RushEnemy _rushEnemy = default;
    private NormalBullet[] _normalBullets = default;

    private float _timer = default;
    private float _stopTime = default;
    private bool _isStop = default;
    
    void Start()
    {
        _player = FindObjectOfType<Player>();
        _playerMove = FindObjectOfType<PlayerMove>();
    }
    
    void Update()
    {
        if (_isStop)
        {
            _timer += Time.deltaTime;
            if (_timer >= _stopTime)
            {
                _player.enabled = true;
                _playerMove.enabled = true;
                _enemies = FindObjectsOfType<Enemy>();
                _rushEnemy = FindObjectOfType<RushEnemy>();
                _normalBullets = FindObjectsOfType<NormalBullet>();
                foreach (var enemy in _enemies)
                {
                    enemy.GetComponent<Enemy>().enabled = true;
                }
                if (_rushEnemy != null) _rushEnemy.enabled = true;
                foreach (var normalBullet in _normalBullets)
                {
                    normalBullet.enabled = true;
                }
                _isStop = false;
                _timer = 0;
            }
        }
    }

    public void HitNormalBullet()
    {
        _stopTime = 0.08f;
        _isStop = true;
        _player.enabled = false;
        _playerMove.enabled = false;
        _enemies = FindObjectsOfType<Enemy>();
        _rushEnemy = FindObjectOfType<RushEnemy>();
        _normalBullets = FindObjectsOfType<NormalBullet>();
        foreach (var enemy in _enemies)
        {
            enemy.GetComponent<Enemy>().enabled = false;
        }
        if (_rushEnemy != null) _rushEnemy.enabled = false;
        foreach (var normalBullet in _normalBullets)
        {
            normalBullet.enabled = false;
        }
    }

    public void HitLaserBullet()
    {
        _stopTime = 0.25f;
        _isStop = true;
        _player.enabled = false;
        _playerMove.enabled = false;
        _enemies = FindObjectsOfType<Enemy>();
        _rushEnemy = FindObjectOfType<RushEnemy>();
        _normalBullets = FindObjectsOfType<NormalBullet>();
        foreach (var enemy in _enemies)
        {
            enemy.GetComponent<Enemy>().enabled = false;
        }
        if (_rushEnemy != null) _rushEnemy.enabled = false;
        foreach (var normalBullet in _normalBullets)
        {
            normalBullet.enabled = false;
        }
    }
}
