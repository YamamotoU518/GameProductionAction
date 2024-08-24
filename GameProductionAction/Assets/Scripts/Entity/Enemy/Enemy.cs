using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour, IEntity
{
    [SerializeField] private Bullet _enemyBullet = null;
    [SerializeField] private int _angle = 0;
    
    private Player _player = null;
    private int _hp = default;
    private float _timer = 0;
    private KnockBack _knockBack = default;
    
    void Start()
    {
        _hp = 3;
        _player = FindObjectOfType<Player>();
        _knockBack = gameObject.GetComponent<KnockBack>();
    }
    
    void Update()
    {
        _timer += Time.deltaTime;
        var distance = Vector3.Distance(this.gameObject.transform.position, _player.gameObject.transform.position);

        if (_timer > 3f)
        {
            if (distance < 10)
            {
                Instantiate(_enemyBullet, this.gameObject.transform.position, quaternion.Euler(0, _angle, 0));
            }
            _timer = 0;
        }
    }

    public void Damage(int damage, int direction)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            _knockBack.Damage(direction);
        }
    }
}
