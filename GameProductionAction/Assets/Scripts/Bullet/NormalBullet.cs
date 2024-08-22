using UnityEngine;

public class NormalBullet : Bullet
{
    private readonly float _speed = 0.01f;
    
    [SerializeField] private int _damage = 1;
    
    void Update()
    {
        float positionX = gameObject.transform.position.x;
        transform.Translate(Vector2.right * _speed);
        FindTargets();
        if (positionX > 12 || positionX < -12)
        {
            Destroy(gameObject);
        }
    }

    private void FindTargets()
    {
        var targets = GameObject.FindGameObjectsWithTag(_bulletUser == BulletUser.Player ? "Enemy" : "Player");
        if (TargetSet(_damage, gameObject, targets)) { Destroy(gameObject); }
    }
}
