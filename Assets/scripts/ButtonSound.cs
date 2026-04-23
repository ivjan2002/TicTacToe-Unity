using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public void PlayMainClick()
    {
        AudioManager.instance.PlayMainClick();
    }

    public void PlayOtherClick()
    {
        AudioManager.instance.PlayOtherClick();
    }
}