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
            float xMin = gameObject.transform.position.x - 0.25f;
            float xMax = gameObject.transform.position.x + 0.25f;
            float yMin = gameObject.transform.position.y - 0.125f;
            float yMax = gameObject.transform.position.y + 0.125f;

       
            float enemyXMin = enemy.transform.position.x - 0.25f;
            float enemyXMax = enemy.transform.position.x + 0.25f;
            float enemyYMin = enemy.transform.position.y - 0.25f;
            float enemyYMax = enemy.transform.position.y + 0.25f;

            if (xMin <= enemyXMax && enemyXMin <= xMax && yMin <= enemyYMax && enemyYMin <= yMax)
            {
                enemy.Hp--;
                if (enemy.Hp <= 0) { Destroy(enemy.gameObject); }
                Destroy(this.gameObject);
            }
        }
    }
}
