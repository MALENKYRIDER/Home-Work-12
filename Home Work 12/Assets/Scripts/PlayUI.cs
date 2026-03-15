using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayUI : MonoBehaviour
{
    [SerializeField] private Button _easyModeButton;
    [SerializeField] private Button _normalModeButton;
    [SerializeField] private Button _hardModeButton;
    [SerializeField] private Button _backButton;

    private void OnEnable()
    {
        _easyModeButton.onClick.AddListener(OnEasyModeClick);
        _normalModeButton.onClick.AddListener(OnNormalModeClick);
        _hardModeButton.onClick.AddListener(OnHardModeClick);
        _backButton.onClick.AddListener(OnBackButton);
    }

    private void OnDisable()
    {
        _easyModeButton.onClick.RemoveListener(OnEasyModeClick);
        _normalModeButton.onClick.RemoveListener(OnNormalModeClick);
        _hardModeButton.onClick.RemoveListener(OnHardModeClick);
        _backButton.onClick.RemoveListener(OnBackButton);
    }

    private void OnEasyModeClick()
    {
        GameSession.DifficultyType = DifficultyType.Easy;
        SceneManager.LoadScene("Game");
    }

    private void OnNormalModeClick()
    {
        GameSession.DifficultyType = DifficultyType.Normal;
        SceneManager.LoadScene("Game");
    }

    private void OnHardModeClick()
    {
        GameSession.DifficultyType = DifficultyType.Hard;
        SceneManager.LoadScene("Game");
    }

    private void OnBackButton()
    {
        SceneManager.LoadScene("EntryPoint");
    }
}
