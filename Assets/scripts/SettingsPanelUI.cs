using UnityEngine;
using UnityEngine.UI;

public class SettingsPanelUI : MonoBehaviour
{
    public Toggle musicToggle;
    public Toggle sfxToggle;

    void OnEnable()
    {
        musicToggle.isOn = SettingsManager.instance.musicEnabled;
        sfxToggle.isOn = SettingsManager.instance.sfxEnabled;
    }

    public void OnMusicToggleChanged(bool value)
    {
        Debug.Log("Music toggle: " + value);
        SettingsManager.instance.SetMusic(value);
    }

    public void OnSFXToggleChanged(bool value)
    {
        SettingsManager.instance.SetSFX(value);
    }
}