
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : EntityStateManager
{
    // Player's current state
    PlayerBaseState _currentState;

    // Player's current states
    PlayerMoveState _moveState;
    PlayerBoostState _boostState;
    PlayerDeathState _deathState;

    // Player controller parts
    public Transform aimingBody;

    // Stats
    public float player_health = 100f;

    // Player Controls
    public PlayerInputActions _playerControls;

    public InputAction moveControl;

    void Awake()
    {
        _moveState = new PlayerMoveState(this);
        _boostState = new PlayerBoostState(this);
        _deathState = new PlayerDeathState(this);

        _currentState = _moveState;


        _playerControls = new PlayerInputActions();

        moveControl = _playerControls.Player.Move;

        // Set rigidbody physics
        rigid = GetComponent<Rigidbody>();
    }

    // Enable input system
    private void OnEnable()
    {
        _playerControls.Enable();
        moveControl.Enable();
    }

    // Disable input system
    private void OnDisable()
    {
        _playerControls.Disable();
        moveControl.Disable();
    }

    void FixedUpdate()
    {
        _currentState.UpdateState();
    }
}
