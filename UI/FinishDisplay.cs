using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class FinishDisplay : MonoBehaviour
{
    [SerializeField] private Button _mainMenuButton;

    private void OnEnable()
    {
        _mainMenuButton.Add(OnClickMainMenuButton);
    }

    private void OnDestroy()
    {
        _mainMenuButton.Remove(OnClickMainMenuButton);
    }

    private void OnClickMainMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
