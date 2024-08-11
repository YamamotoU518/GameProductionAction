using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public enum BulletUser
{
    Player,
    Enemy
}

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletUser _bulletUser = BulletUser.Player;

    private readonly float _speed = 0.01f;
    
    private float _xMin;
    private float _xMax;
    private float _yMin;
    private float _yMax;

    void Update()
    {
        UpdataBounds();
        TargetSet();
        float positionX = gameObject.transform.position.x;
        transform.Translate(Vector2.right * _speed);
        if (positionX > 12 || positionX < -12)
        {
            Destroy(gameObject);
        }
    }

    private void UpdataBounds()
    {
        _xMin = transform.position.x - transform.localScale.x / 2;
        _xMax = transform.position.x + transform.localScale.x / 2;
        _yMin = transform.position.y - transform.localScale.y / 2;
        _yMax = transform.position.y + transform.localScale.y / 2;
    }

    private void TargetSet()
    {
        var targets = GameObject.FindGameObjectsWithTag(_bulletUser == BulletUser.Player ? "Enemy" : "Player");

        foreach (var target in targets)
        {
            float targetXMin = target.transform.position.x - target.transform.localScale.x / 2;
            float targetXMax = target.transform.position.x + target.transform.localScale.x / 2;
            float targetYMin = target.transform.position.y - target.transform.localScale.y / 2;
            float targetYMax = target.transform.position.y + target.transform.localScale.y / 2;

            if (_xMin <= targetXMax && targetXMin <= _xMax && _yMin <= targetYMax && targetYMin <= _yMax)
            {
                if (_bulletUser == BulletUser.Player)
                {
                    target.GetComponent<Enemy>().Damage();
                }
                else
                {
                    target.GetComponent<Player>().Damage();
                }
                Destroy(this.gameObject);
            }
        }
    }
}