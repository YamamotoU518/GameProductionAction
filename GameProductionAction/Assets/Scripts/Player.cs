using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bullet = null;

    [SerializeField] private GameObject _pointer;
    public int Hp { get; set; }
  
    void Start()
    {
        Hp = 5;
    }

    void Update()
    {
        float x = _pointer.transform.position.x - gameObject.transform.position.x;
        float y = _pointer.transform.position.y - gameObject.transform.position.y;
        float _radian = Mathf.Atan2(y, x);
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (bullet)
                Instantiate(bullet, this.gameObject.transform.position, 
                    Quaternion.AngleAxis(_radian * 180 / Mathf.PI, new Vector3(0, 0, 1)));
        }
        gameObject.transform.rotation = Quaternion.AngleAxis(_radian * 180 / Mathf.PI, new Vector3(0, 0, 1));
    }
}
