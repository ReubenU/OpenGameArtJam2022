

public abstract class DroneBaseState
{
    EntityStateManager _stateManager;

    public DroneBaseState(EntityStateManager stateManager)
    {
        _stateManager = stateManager;
    }

    public abstract void UpdateState();
}
