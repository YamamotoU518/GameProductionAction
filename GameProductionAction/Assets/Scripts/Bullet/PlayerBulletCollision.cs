using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollision : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {
        var enemies = GameObject.FindObjectsOfType<Enemy>();
        foreach (var enemy in enemies)
        {
            float xMin = gameObject.transform.position.x - gameObject.transform.localScale.x / 2;
            float xMax = gameObject.transform.position.x + gameObject.transform.localScale.x / 2;
            float yMin = gameObject.transform.position.y - gameObject.transform.localScale.y / 2;
            float yMax = gameObject.transform.position.y + gameObject.transform.localScale.y / 2;

       
            float enemyXMin = enemy.transform.position.x - enemy.transform.localScale.x / 2;
            float enemyXMax = enemy.transform.position.x + enemy.transform.localScale.x / 2;
            float enemyYMin = enemy.transform.position.y - enemy.transform.localScale.y / 2;
            float enemyYMax = enemy.transform.position.y + enemy.transform.localScale.y / 2;

            if (xMin <= enemyXMax && enemyXMin <= xMax && yMin <= enemyYMax && enemyYMin <= yMax)
            {
                enemy.Damage();
                if (enemy.HP <= 0) { Destroy(enemy.gameObject); }
                Destroy(this.gameObject);
            }
        }
    }
}
