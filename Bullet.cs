using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    public int Damage => _damage;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(new Vector2(_speed * Time.deltaTime, 0));
    }
}