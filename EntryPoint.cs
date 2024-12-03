using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Awake()
    {
        _player.Initialize();
    }
}