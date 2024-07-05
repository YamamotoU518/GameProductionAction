using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bullet = null;
    public int Hp { get; set; }
  
    void Start()
    {
        Hp = 5;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (bullet)
                Instantiate(bullet, this.gameObject.transform.position, quaternion.identity);
        }
    }
}
