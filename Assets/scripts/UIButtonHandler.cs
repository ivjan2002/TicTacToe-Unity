using UnityEngine;

public class UIButtonHandler : MonoBehaviour
{
    public void PlayMainClick()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.PlayMainClick();
    }

    public void PlayOtherClick()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.PlayOtherClick();
    }
}