
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState _currentState;

    PlayerMoveState _moveState;
    PlayerBoostState _boostState;
    PlayerDeathState _deathState;

    // Physics
    public float moveSpeed = 3.0f;

    public float boostSpeed = 10f;

    public Rigidbody rigid;

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

        rigid = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
        moveControl.Enable();
    }

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
