using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private Slider _volume;
    [SerializeField] private Button _backButton;

    private const string VolumeKey = "GameVolume";

    private void Start()
    {
        if (MusicManager.Instance != null)
        {
            _volume.value = MusicManager.Instance.GetVolume();
        }
    }

    private void OnEnable()
    {
        _volume.onValueChanged.AddListener(OnVolumeChanged);
        _backButton.onClick.AddListener(OnBackClick);
    }

    private void OnVolumeChanged(float volume)
    {
        if (MusicManager.Instance != null)
        {
            MusicManager.Instance.SetVolume(volume);
        }
    }

    private void OnBackClick()
    {
        SceneManager.LoadScene("EntryPoint");
    }
}
