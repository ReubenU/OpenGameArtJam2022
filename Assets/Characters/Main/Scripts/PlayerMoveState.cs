using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(PlayerStateManager stateManager) : base(stateManager){}

    Rigidbody rigid;

    public override void EnterState()
    {
        rigid = _stateManager.gameObject.GetComponent<Rigidbody>();
    }

    public override void UpdateState()
    {
        
    }

    public override void ExitState()
    {
        
    }

    void MovePlayer()
    {
        
    }
}
