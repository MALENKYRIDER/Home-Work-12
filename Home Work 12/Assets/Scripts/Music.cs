using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    private AudioSource _audioSource;
    private const string VolumeKey = "GameVolume";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("AudioSource не найден на MusicManager!");
            return;
        }

        _audioSource.volume = PlayerPrefs.GetFloat(VolumeKey, 0.5f);
        _audioSource.Play();
    }

    public void SetVolume(float volume)
    {
        if (_audioSource == null) return;
        _audioSource.volume = volume;
        PlayerPrefs.SetFloat(VolumeKey, volume);
        PlayerPrefs.Save();
    }

    public float GetVolume()
    {
        if (_audioSource == null) return 0f;
        return _audioSource.volume;
    }
}