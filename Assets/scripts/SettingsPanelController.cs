using UnityEngine;

public class SettingsPanelController : MonoBehaviour
{
    public GameObject settingsPanel;

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        if (AudioManager.instance != null)
            AudioManager.instance.PlayPopupOpen();
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
}