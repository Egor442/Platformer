using UnityEngine;
using UnityEngine.UI;

public class AuthorsDisplay : MonoBehaviour
{
    [SerializeField] private Button _exitButton;

    private void OnEnable()
    {
        _exitButton.Add(OnClickExitButton);
    }

    private void OnDisable()
    {
        _exitButton.Remove(OnClickExitButton);
    }

    private void OnClickExitButton()
    {
        gameObject.Deactivate();
    }
}