using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class WinWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text winText, restartButtonText;
    [SerializeField] private Image restartButtonImage;
    [SerializeField] private Button restartButton;
    [SerializeField] private float buttonDelay;
    [SerializeField] private float fadeInDuration;

    public void ShowWinWindow()
    {
        winText.DOColor(Color.white, fadeInDuration);
        Invoke("ShowRestartButton", buttonDelay);
    }

    private void ShowRestartButton()
    {
        restartButtonImage.DOColor(Color.white, fadeInDuration);
        restartButtonText.DOColor(Color.black, fadeInDuration);
        restartButtonImage.raycastTarget = true;
        restartButton.interactable = true;
    }
}
