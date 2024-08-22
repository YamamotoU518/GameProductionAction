using TMPro.EditorUtilities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField, Header("普通の弾")] private GameObject _bullet = default;
    [SerializeField, Header("レーザー")] private GameObject _laserBullet = default;

    /// <summary> これ以上押したら長押しとみなす </summary>
    [SerializeField] private float _longClickTime = default;
    /// <summary> 押された時間の長さ </summary>
    private float _clickTime = default;
    
    private int _hp = default;
  
    void Start()
    {
        _hp = 5;
    }

    void Update()
    {
        KeyRelease();

        KeyPress();
    }

    private void KeyPress()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            _clickTime += Time.deltaTime;
            //Debug.Log(_clickTime);
        }
    }

    private void KeyRelease()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
             Instantiate(_clickTime < _longClickTime ? _bullet : _laserBullet, 
                 gameObject.transform.position, 
                 gameObject.transform.rotation);
            _clickTime = 0;
        }
    }
    public void Damage(int damage)
    {
        _hp -= damage;
    }
}
