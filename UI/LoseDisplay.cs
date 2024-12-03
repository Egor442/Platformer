using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LoseDisplay : MonoBehaviour
{
    [SerializeField] private Button _restartButton;

    private void OnEnable()
    {
        _restartButton.Add(OnClickRestartButton);
    }

    private void OnDestroy()
    {
        _restartButton.Remove(OnClickRestartButton);
    }

    private void OnClickRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}