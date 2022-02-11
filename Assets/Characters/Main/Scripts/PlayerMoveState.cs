using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(PlayerStateManager stateManager) : base(stateManager){}

    Vector3 moveDirection = new Vector3();

    public override void EnterState()
    {
    }

    public override void UpdateState()
    {
        MovePlayer();
    }

    public override void ExitState()
    {
        
    }

    // Movement function
    Vector3 moveForce = new Vector3();
    Vector3 smooth_velocity = new Vector3();
    float time2smooth = 10;

    void MovePlayer()
    {
        Vector3 moveVector = _stateManager.moveControl.ReadValue<Vector2>();

        moveDirection = new Vector3(moveVector.x, 0f, moveVector.y) * _stateManager.moveSpeed;

        moveForce = Vector3.SmoothDamp(moveForce, moveDirection, ref smooth_velocity, time2smooth * Time.fixedDeltaTime);

        _stateManager.rigid.AddForce(moveForce - _stateManager.rigid.velocity, ForceMode.VelocityChange);
    }
}
