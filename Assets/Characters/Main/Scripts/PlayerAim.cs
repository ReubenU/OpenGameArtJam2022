using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    PlayerInputActions playerControls;
    InputAction mouseMovement;

    private void Awake()
    {
        playerControls = new PlayerInputActions();

        mouseMovement = playerControls.Player.MousePosition;
    }

    private void OnEnable()
    {
        playerControls.Enable();
        mouseMovement.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
        mouseMovement.Disable();
    }

    private void Update()
    {
        MouseAim();
    }


    Vector2 pointer = new Vector2();
    float angle = 0f;
    void MouseAim()
    {
        pointer = mouseMovement.ReadValue<Vector2>();

        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        angle = Mathf.Atan2(pointer.x - screenPos.x, pointer.y - screenPos.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(Vector3.up * angle);
    }

}
