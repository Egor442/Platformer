using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GoldTextAnimator : MonoBehaviour
{
    private const string PickUpTrigger = "PickUp";
    private const string IdleTrigger = "Idle";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PickUp()
    {
        _animator.SetTrigger(PickUpTrigger);
        _animator.SetTrigger(IdleTrigger);
    }
}