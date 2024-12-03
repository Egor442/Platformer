using UnityEngine;
using UnityEngine.Events;

public class Gold : MonoBehaviour
{
    [SerializeField] private SoundHandler _sounds;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            PickUp();
            player.PickUpGold();
        }
    }

    private void PickUp()
    {
        Destroy(gameObject);
        _sounds.CollectGold();
    }
}