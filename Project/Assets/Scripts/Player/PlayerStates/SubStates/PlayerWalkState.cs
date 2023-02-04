using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerGroundState
{
    public PlayerWalkState(Player player, StateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LUpdate()
    {
        base.LUpdate();

        // player.SetVelocityX(xInput * playerData.movementSpeed);

        if (xInput == 0)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }
}
