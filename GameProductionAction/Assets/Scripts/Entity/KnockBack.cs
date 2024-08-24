using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    private Vector3 _startPos = default;
    private Vector3 _endPos = default;
    private bool _getDamage = false;
    private float _startTime = default;

    private void Update()
    {
        if (_getDamage)
        {
            var diff = Time.timeSinceLevelLoad - _startTime;
            var rate = diff / 0.15f;
            transform.position = Vector3.Lerp(_startPos, _endPos, rate);
            if (transform.position == _endPos)
            {
                _getDamage = false;
            }
        }
    }

    /// <summary>ノックバックの値設定 </summary>
    /// <param name="direction"> 動く方向 </param> 1, -1
    public void Damage(int direction)
    {
        _startPos = transform.position;
        _endPos = new Vector3(_startPos.x + direction, _startPos.y, _startPos.z);
        _startTime = Time.timeSinceLevelLoad;
        _getDamage = true;
    }
}
