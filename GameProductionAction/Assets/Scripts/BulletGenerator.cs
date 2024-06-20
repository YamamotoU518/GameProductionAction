using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _bullet = null;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (_bullet)
                Instantiate(_bullet, this.gameObject.transform.position, quaternion.identity);
        }
    }
}
