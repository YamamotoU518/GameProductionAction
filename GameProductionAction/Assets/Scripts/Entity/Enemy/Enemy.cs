using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Bullet _enemyBullet = null;
    [SerializeField] private int _angle = 0;
    
    private Player _player = null;
    private int _hp = default;
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

    public void Damage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
