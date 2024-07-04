using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed = 0.01f;
  void Start()
  {
      
  }
  
    void Update()
    {
        float positionX = this.gameObject.transform.position.x;
        float positionY = this.gameObject.transform.position.y;
        //positionX += 0.01f;
        this.transform.Translate(Vector2.right * _speed);
        //this.gameObject.transform.position = new Vector2(_right.x, positionY);
        if (positionX > 12 || positionX < -12) { Destroy(this.gameObject); }
    }
}
