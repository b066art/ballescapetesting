using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class StartLevelWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text startButtonText;
    [SerializeField] private Button startButton;
    [SerializeField] private float duration;

    private void Start()
    {
        startButtonText.DOColor(Color.white, duration);
        startButton.interactable = true;
    }

    public void HideWindow()
    {
        startButton.interactable = false;
        startButtonText.DOColor(Color.clear, duration);
    }
}
