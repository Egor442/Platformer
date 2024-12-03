using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _authortsButton;
    [SerializeField] private Button _exitButton;

    [SerializeField] private string _gameSceneName;
    [SerializeField] private GameObject _authortsDisplay;

    private void OnEnable()
    {
        _playButton.Add(OnClickPlayButton);
        _authortsButton.Add(OnClickAuthorsButton);
        _exitButton.Add(OnClickExitButton);
    }

    private void OnDisable()
    {
        _playButton.Remove(OnClickPlayButton);
        _authortsButton.Remove(OnClickAuthorsButton);
        _exitButton.Remove(OnClickExitButton);
    }

    private void OnClickPlayButton()
    {
        SceneManager.LoadScene(_gameSceneName);
    }

    private void OnClickAuthorsButton()
    {
        _authortsDisplay.Activate();
    }

    private void OnClickExitButton()
    {
        Application.Quit();
    }
}
