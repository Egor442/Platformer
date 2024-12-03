using UnityEngine;

public class PlayerFinisher : MonoBehaviour
{
    [SerializeField] private FinishDisplay _finishDisplay;
    [SerializeField] private SoundHandler _sounds;

    public void Finish()
    {
        _finishDisplay.Activate();
        _sounds.Finish();
        Destroy(gameObject);     
    }
}