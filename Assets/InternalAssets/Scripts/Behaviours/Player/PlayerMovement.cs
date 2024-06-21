using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float maxThrust, thrustFactor;

    private Camera mainCamera;
    private PlayerInput playerInput;
    private Rigidbody rb;

    private Vector3 pointerStartPosition;
    private Vector3 pointerEndPosition;

    private void Awake()
    {
        mainCamera = Camera.main;
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
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
        pointerStartPosition = GetCurrentWorldPoint();
        pointerStartPosition.z = 0;
    }

    private void OnEndDrag()
    {
        pointerEndPosition = GetCurrentWorldPoint();
        pointerEndPosition.z = 0;

        Vector3 direction = (pointerEndPosition - pointerStartPosition).normalized;
        float thrust = Mathf.Clamp((pointerEndPosition - pointerStartPosition).magnitude, -maxThrust, maxThrust) * thrustFactor;
        rb.velocity = Vector3.zero;
        rb.AddForce(direction * thrust);
    }

    private Vector3 GetCurrentWorldPoint()
    {
        Vector3 pointerPosition = playerInput.GetPointerPosition();
        pointerPosition.z = -mainCamera.transform.position.z;
        return pointerPosition;
    }

    public void ResetVelocity()
    {
        rb.velocity = Vector3.zero;
    }
}
