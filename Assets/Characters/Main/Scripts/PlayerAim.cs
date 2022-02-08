using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    PlayerInputActions playerControls;
    InputAction mousePosition;

    // Player's input system being initialized
    private void Awake()
    {
        playerControls = new PlayerInputActions();

        mousePosition = playerControls.Player.MousePosition;
    }

    private void OnEnable()
    {
        playerControls.Enable();
        mousePosition.Enable();
    }

    // Disable the input system to avoid fuckery.
    private void OnDisable()
    {
        playerControls.Disable();
        mousePosition.Disable();
    }

    // Main update loop.
    private void Update()
    {
        MouseAim();
    }

    // Player mouse aiming.
    // The player model aims directly at
    // the mouse in screen space.
    void MouseAim()
    {
        Vector2 pointer = mousePosition.ReadValue<Vector2>();

        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        float angle = Mathf.Atan2(pointer.x - screenPos.x, pointer.y - screenPos.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(Vector3.up * angle);
    }

}
