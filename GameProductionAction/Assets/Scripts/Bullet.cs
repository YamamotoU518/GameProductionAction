using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  void Start()
    {
        
    }
  
    void Update()
    {
        float positionX = this.gameObject.transform.position.x;
        float positionY = this.gameObject.transform.position.y;
        positionX += 0.01f;
        this.gameObject.transform.position = new Vector2(positionX, positionY);
        if (positionX > 12) { Destroy(this.gameObject); }
    }
}
