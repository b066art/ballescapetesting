using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class TimeScaleController : MonoBehaviour
{
    [SerializeField] private float minTimeScale;

    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        playerInput.OnStartDrag += OnStartDrag;
        playerInput.OnEndDrag += OnEndDrag;
    }

    private void OnDisable()
    {
        playerInput.OnStartDrag -= OnStartDrag;
        playerInput.OnEndDrag -= OnEndDrag;
    }

    private void OnStartDrag()
    {
        Time.timeScale = minTimeScale;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }

    private void OnEndDrag()
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }
}
