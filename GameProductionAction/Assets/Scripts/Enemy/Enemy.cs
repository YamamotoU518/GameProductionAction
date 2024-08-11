using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected Player _player = null;
    [SerializeField] protected Bullet _enemyBullet = null;
    [SerializeField] protected int _angle = 0;

    private int _hp = default;
    public int HP => _hp;

    private float _timer = 0;
    void Start()
    {
        _hp = 3;
        _player = FindObjectOfType<Player>();
    }
    
    void Update()
    {
        _timer += Time.deltaTime;
        var _distance = Vector3.Distance(this.gameObject.transform.position, _player.gameObject.transform.position);

        if (_timer > 3f)
        {
            if (_distance < 10)
            {
                Instantiate(_enemyBullet, this.gameObject.transform.position, quaternion.Euler(0, _angle, 0));
            }
            _timer = 0;
        }
    }

    public void Damage()
    {
        _hp--;
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
