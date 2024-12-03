using System.Collections;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private Transform _spawnPosition;

    public void Spawn()
    {
        GameObject gameObject = TryGetPooledObject();
        gameObject.transform.position = _spawnPosition.position;
        gameObject.SetActive(true);

        StartCoroutine(DisableObject(gameObject));
    }

    private IEnumerator DisableObject(GameObject gameObject)
    {
        yield return new WaitForSeconds(_lifeTime);
        gameObject.SetActive(false);
    }
}