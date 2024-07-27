using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    
    void Start()
    {
        
    }
    
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        gameObject.transform.position = 
            new Vector3(Camera.main.ScreenToWorldPoint(mousePos).x, Camera.main.ScreenToWorldPoint(mousePos).y, 0f);
    }
}
