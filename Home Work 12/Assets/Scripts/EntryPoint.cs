using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _quitButton;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayClick);
        _settingsButton.onClick.AddListener(OnSettingsClick);
        _quitButton.onClick.AddListener(OnQuitClick);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayClick);
        _settingsButton.onClick.RemoveListener(OnSettingsClick);
        _quitButton.onClick.RemoveListener(OnQuitClick);
    }

    private void OnPlayClick()
    {
        SceneManager.LoadScene("Play");
    }

    private void OnSettingsClick()
    {
        SceneManager.LoadScene("Settings");
    }

    private void OnQuitClick()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
