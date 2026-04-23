using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;

    public bool musicEnabled = true;
    public bool sfxEnabled = true;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetMusic(bool value)
    {
        musicEnabled = value;
        AudioManager.instance.ToggleMusic(value);
    }

    public void SetSFX(bool value)
    {
        sfxEnabled = value;
        AudioManager.instance.ToggleSFX(value);
    }
}