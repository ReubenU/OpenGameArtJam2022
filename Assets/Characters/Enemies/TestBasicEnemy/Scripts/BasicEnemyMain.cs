using UnityEngine;

public class BasicEnemyMain : EntityStateManager
{
    // Public vars
    public Transform target;
    public Transform weaponsAiming;
    public float followDistance = 5f;

    // State management
    DroneBaseState _currentState;
    DroneBaseState _armament;

    DroneChaseState chaseState;
    DroneAim aimState;

    private void Awake()
    {
        chaseState = new DroneChaseState(this, target, followDistance);
        aimState = new DroneAim(this, weaponsAiming, target);

        _currentState = chaseState;
        _armament = aimState;
    }

    private void FixedUpdate()
    {
        if (health > 0)
            _currentState.UpdateState();
    }

    private void Update()
    {
        if (health > 0)
            _armament.UpdateState();
    }

    // Switch the drone's state to newState
    public void SwitchState(DroneBaseState newState)
    {
        _currentState = newState;
    }
}
