using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _prefab = default;
    [SerializeField] private float _spawnTime = default;

    private float _timer = default;
    private GameObject[] _prefabs = default;
    
    void Start()
    {
        _prefabs = new GameObject[1];
    }
    
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _spawnTime)
        {
            if (_prefabs[0] == null)
            {
                _prefabs[0] = Instantiate(_prefab, gameObject.transform.position, Quaternion.identity);
            }

            _timer = 0;
        }
    }
}
