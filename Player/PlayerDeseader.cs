using UnityEngine;
using UnityEngine.Events;

public class PlayerDeseader : MonoBehaviour
{
    [SerializeField] private LoseDisplay _loseDisplay;
    [SerializeField] private SoundHandler _sounds;

    public void Die()
    {
        _loseDisplay.Activate();
        _sounds.Die();
        Destroy(gameObject);
    }
}