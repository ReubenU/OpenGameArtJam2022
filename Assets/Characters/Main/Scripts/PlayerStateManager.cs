
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState _currentState;

    PlayerMoveState _moveState;
    PlayerBoostState _boostState;
    PlayerDeathState _deathState;

    [SerializeField]
    private float moveSpeed = 3.0f;

    [SerializeField]
    private float boostSpeed = 10f;

    public float player_health = 100f;

    void Awake()
    {
        _moveState = new PlayerMoveState(this);
        _boostState = new PlayerBoostState(this);
        _deathState = new PlayerDeathState(this);

        _currentState = _moveState;
    }

    void Update()
    {
        _currentState.UpdateState();
    }
}
