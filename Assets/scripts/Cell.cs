using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Image markImage;

    public int index;
    public bool hasX;
    public bool hasO;

    private bool isClicked = false;

    public void OnCellClicked()
    {
        if (isClicked) return;

        isClicked = true;

        GameManager.Instance.RegisterMove();

        if (GameManager.Instance.isPlayerXTurn)
        {
            markImage.sprite = GameManager.Instance.GetCurrentXTheme();
            hasX = true;
            AudioManager.instance.PlayGridClickX();
        }
        else
        {
            markImage.sprite = GameManager.Instance.GetCurrentOTheme();
            hasO = true;
            AudioManager.instance.PlayGridClickO();
        }

        markImage.enabled = true;

        GameManager.Instance.SwitchTurn();
        GameManager.Instance.CheckWin();   
        
    }

    public void ResetCell()
    {
        isClicked = false;
        hasX = false;
        hasO = false;

        markImage.sprite = null;
        markImage.enabled = false;
    }
}