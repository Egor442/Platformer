using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _damage;
    [SerializeField] private float _explotionRadius;

    private EnemyMover _mover;
    private HealthHandler _healthHandler;

    private bool _isTargetTrigered;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _healthHandler = new HealthHandler(_maxHealth);
    }

    private void Start()
    {
        _isTargetTrigered = false;
    }

    private void Update()
    {
        if (_isTargetTrigered == false)
        {
            _mover.Move();
            _mover.TryChangeDirection();
        }

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _explotionRadius);

        foreach (Collider2D hit in hits)
        {
            if (hit.TryGetComponent(out Player player))
            {
                _isTargetTrigered = true;
                _mover.MoveOnTarget(player.transform);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
        }

        if (collision.TryGetComponent(out Bullet bullet))
        {
            TakeDamage(bullet.Damage);
        }
    }

    public void TakeDamage(int damage)
    {
        _healthHandler.RemoveHealth(damage);

        if (_healthHandler.Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}