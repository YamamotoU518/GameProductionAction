using UnityEngine;

public class LaserBullet : Bullet
{
    [SerializeField, Header("Appear")] private float _appear = default;

    [SerializeField] private int _damage = 3;
    
    void Update()
    {
        FindTargets();
        Destroy(gameObject, _appear);
    }

    private void FindTargets()
    {
        var targets = GameObject.FindGameObjectsWithTag("Enemy");
        var bullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        if(TargetSet(_damage, transform.GetChild(0).gameObject, targets) || 
           TargetSet(_damage, transform.GetChild(0).gameObject, bullets))
        {
            _hitStop.HitLaserBullet();
        }
    }
}
