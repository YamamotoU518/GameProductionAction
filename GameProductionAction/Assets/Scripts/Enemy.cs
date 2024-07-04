using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Player _player = null;
    [SerializeField] private Bullet _enemyBullet = null;
    [SerializeField] private int _angle = 0;

    private float _timer = 0;
    void Start()
    {
        
    }
    
    void Update()
    {
        _timer += Time.deltaTime;
        var _distance = Vector3.Distance(this.gameObject.transform.position, _player.gameObject.transform.position);

        if (_timer > 1f)
        {
            if (_distance < 10)
            {
                Instantiate(_enemyBullet, this.gameObject.transform.position, quaternion.Euler(0, _angle, 0));
            }
            _timer = 0;
        }
    }
}
