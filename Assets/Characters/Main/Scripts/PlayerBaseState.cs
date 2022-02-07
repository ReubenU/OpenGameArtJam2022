using UnityEngine;

public abstract class PlayerBaseState
{
    protected PlayerStateManager _stateManager;

    public PlayerBaseState(PlayerStateManager stateManager)
    {
        _stateManager = stateManager;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();

}
