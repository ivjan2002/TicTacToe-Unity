using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Singleton instance to ensure only one AudioManager exists
    public static AudioManager instance;

    [Header("Music")]
    public AudioClip musicClip;
    private AudioSource musicSource;

    [Header("SFX")]
    public AudioClip mainButtonClick;
    public AudioClip otherButtonClick;

    [Header("Game SFX")]
    public AudioClip xClick;
    public AudioClip oClick;

    [Header("Game SFX")]
    public AudioClip winSFX;

    [Header("UI SFX")]
    public AudioClip popupOpen;

    private AudioSource sfxSource;
    public bool sfxEnabled = true;

    void Awake()
    {
        // Prevent duplicate AudioManagers when changing scenes
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // Setup background music source
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = musicClip;
        musicSource.loop = true;

        sfxSource = gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
        musicSource.Play();

        ApplySettings(); 
    }


    // Sync audio settings with SettingsManager
    public void ApplySettings()
    {
        if (SettingsManager.instance == null) return;

        musicSource.mute = !SettingsManager.instance.musicEnabled;
        sfxEnabled = SettingsManager.instance.sfxEnabled;
    }

    public void PlayMainClick()
    {
        if (sfxEnabled && mainButtonClick != null)
            sfxSource.PlayOneShot(mainButtonClick);
    }

    public void PlayOtherClick()
    {
        if (sfxEnabled && otherButtonClick != null)
            sfxSource.PlayOneShot(otherButtonClick);
    }

    public void PlayGridClickX()
    {
        if (sfxEnabled && xClick != null)
            sfxSource.PlayOneShot(xClick);
    }

    public void PlayGridClickO()
    {
        if (sfxEnabled && oClick != null)
            sfxSource.PlayOneShot(oClick);
    }

    public void PlayWinSFX()
    {
        if (sfxEnabled && winSFX != null)
            sfxSource.PlayOneShot(winSFX);
    }

    public void PlayPopupOpen()
    {
        if (sfxEnabled && popupOpen != null)
            sfxSource.PlayOneShot(popupOpen);
    }

    public void ToggleSFX(bool isOn)
    {
        sfxEnabled = isOn;
        ApplySettings(); 
    }

    public void ToggleMusic(bool isOn)
    {
        musicSource.mute = !isOn;
        ApplySettings(); 
    }
}