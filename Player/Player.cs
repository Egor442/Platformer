using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerDeseader))]
[RequireComponent(typeof(PlayerFinisher))]
[RequireComponent(typeof(PlayerAnimator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private GoldDisplay _goldDisplay;
    [SerializeField] private SoundHandler _soundHandler;
    [SerializeField] private Spawner _bulletSpawner;

    private PlayerMover _mover;
    private PlayerDeseader _deseader;
    private PlayerFinisher _finisher;
    private PlayerAnimator _animator;

    private HealthHandler _healthHandler;

    public int Golds { get; private set; }

    public void Initialize()
    {
        _mover = GetComponent<PlayerMover>();
        _mover.Initialize();

        _deseader = GetComponent<PlayerDeseader>();
        _finisher = GetComponent<PlayerFinisher>();

        _animator = GetComponent<PlayerAnimator>();

        _healthHandler = new HealthHandler(_maxHealth);
    }

    private void Update()
    {
        _mover.TryMove();

        if (Input.GetKeyDown(KeyCode.Space) && _mover.IsGrounded)
        {
            _mover.Jump();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            _bulletSpawner.Spawn();
        }
    }

    public void PickUpGold()
    {
        Golds++;
        _goldDisplay.PickUp(Golds);
    }

    public void TakeDamage(int damage)
    {
        _healthHandler.RemoveHealth(damage);
        _animator.TakeDamage();
        _soundHandler.TakeDamage();

        if (_healthHandler.Health <= 0)
        {
            Die();
        }
    }

    public void Heal(int healPoint)
    {
        _healthHandler.AddHealth(healPoint);
    }
  
    public void Finish()
    {
        _finisher.Finish();
    }

    private void Die()
    {
        _deseader.Die();
    }
}