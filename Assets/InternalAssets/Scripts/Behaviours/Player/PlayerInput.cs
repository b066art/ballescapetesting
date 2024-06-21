using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    #region Events
        public delegate void StartDrag();
        public event StartDrag OnStartDrag;
        public delegate void EndDrag();
        public event EndDrag OnEndDrag;
    #endregion

    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void Start()
    {
        playerControls.Player.Click.started += _ => { if (OnStartDrag != null) OnStartDrag(); };
        playerControls.Player.Click.canceled += _ => { if (OnEndDrag != null) OnEndDrag(); };

        Cursor.lockState = CursorLockMode.Confined;
    }

    public Vector2 GetPointerPosition()
    {
        return playerControls.Player.Position.ReadValue<Vector2>();
    }

    public void EnableInput()
    {
        playerControls.Enable();
    }

    public void DisableInput()
    {
        playerControls.Disable();
    }
}
