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
        this.transform.Translate(Vector2.right * _speed);
        if (positionX > 12 || positionX < -12) { Destroy(this.gameObject); }
    }
}
