using System;
using UnityEngine;

public enum BulletUser
{
    Player,
    Enemy
}
public class Bullet : MonoBehaviour
{
    [SerializeField] protected BulletUser _bulletUser = BulletUser.Player;
    protected HitStop _hitStop = default;
    
    private void Start()
    {
        _hitStop = FindObjectOfType<HitStop>();
    } 
    
    protected bool TargetSet(int damage, GameObject obj, GameObject[] targets)
    {
        foreach (var target in targets)
        {
            if (IsHit(obj.transform, target.transform))
            {
                if (target.CompareTag("EnemyBullet"))
                {
                    Destroy(target);
                }
                else
                {
                    target.GetComponent<IEntity>().Damage(damage, 
                        target.transform.position.x > gameObject.transform.position.x ? 1 : -1);
                }
                
                return true;
            }
        }
        return false;
    }
    
    
    private bool IsHit(Transform bullet, Transform target)
    {
        Vector3[] bulletCorners = GetCorners(bullet);
        Vector3[] targetCorners = GetCorners(target);

        // SATによる衝突判定
        if (IsSeparatingAxis(bulletCorners, targetCorners) || IsSeparatingAxis(targetCorners, bulletCorners))
        {
            return false;
        }

        return true;
    }

    /// <summary> オブジェクトの頂点を取得する </summary>
    /// <returns> 頂点の配列 </returns>
    private Vector3[] GetCorners(Transform obj)
    {
        Vector3 halfSize = obj.localScale / 2;
        Vector3[] corners = new Vector3[4];
        
        corners[0] = obj.TransformPoint(-halfSize.x, -halfSize.y, 0); // 左下
        corners[1] = obj.TransformPoint(-halfSize.x, halfSize.y, 0);  // 左上
        corners[2] = obj.TransformPoint(halfSize.x, halfSize.y, 0);   // 右上
        corners[3] = obj.TransformPoint(halfSize.x, -halfSize.y, 0);  // 右下
        
        return corners;
    }

    /// <summary> 分離軸を見つける </summary>
    /// <param name="axisCorners"> 調べたいオブジェクトの頂点 </param>
    /// <param name="otherCorners"> もう一つのオブジェクトの頂点 </param>
    /// <returns>true = 衝突していない、false = 衝突している</returns>
    private bool IsSeparatingAxis(Vector3[] axisCorners, Vector3[] otherCorners)
    {
        for (int i = 0; i < axisCorners.Length; i++)
        {
            Vector3 edge = axisCorners[(i + 1) % axisCorners.Length] - axisCorners[i];
            Vector3 axis = new Vector3(-edge.y, edge.x, 0).normalized;

            float minA = float.MaxValue, maxA = float.MinValue;
            float minB = float.MaxValue, maxB = float.MinValue;

            foreach (var corner in axisCorners)
            {
                float projection = Vector3.Dot(corner, axis);
                minA = Mathf.Min(minA, projection);
                maxA = Mathf.Max(maxA, projection);
            }

            foreach (var corner in otherCorners)
            {
                float projection = Vector3.Dot(corner, axis);
                minB = Mathf.Min(minB, projection);
                maxB = Mathf.Max(maxB, projection);
            }

            if (maxA < minB || maxB < minA) { return true; }
        }

        return false;
    }
}