using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private int _poolSize;

    private List<GameObject> _objectPool = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject gameObject = Instantiate(_gameObject, transform.position, Quaternion.identity);

            gameObject.SetActive(false);
            _objectPool.Add(gameObject);
        }
    }

    public GameObject TryGetPooledObject()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            if (_objectPool[i].activeInHierarchy == false)
            {
                return _objectPool[i];
            }
        }

        return null;
    }

    public void ReturnPooledObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
