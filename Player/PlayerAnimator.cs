using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private const string IdleTrigger = "Idle";
    private const string MoveTrigger = "Run";
    private const string JumpTrigger = "Jump";
    private const string TakeDamageTrigger = "TakeDamage";

    private Animator _animator;

    public void Initialize()
    {
        _animator = GetComponent<Animator>();
    }

    public void Idle()
    {
        _animator.SetTrigger(IdleTrigger);
    }

    public void Move()
    {
        _animator.SetTrigger(MoveTrigger);
    }

    public void Jump()
    {
        _animator.SetTrigger(JumpTrigger);
    }

    public void TakeDamage()
    {
        _animator.SetTrigger(TakeDamageTrigger);
    }
}