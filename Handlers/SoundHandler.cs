using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _jumpSound;
    [SerializeField] private AudioSource _collectGoldSound;
    [SerializeField] private AudioSource _takeDamageSound;
    [SerializeField] private AudioSource _loseSound;
    [SerializeField] private AudioSource _finishSound;

    public void Jump()
    {
        _jumpSound.Play();
    }

    public void CollectGold()
    {
        _collectGoldSound.Play();
    }

    public void TakeDamage()
    {
        _takeDamageSound.Play();
    }

    public void Die()
    {
        _loseSound.Play();
    }

    public void Finish()
    {
        _finishSound.Play();
    }
}