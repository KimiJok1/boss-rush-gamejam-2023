using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    private int jumpCount;

    public PlayerJumpState(Player player, StateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        jumpCount = playerData.jumpsTotal;
    }

    public override void Enter()
    {
        base.Enter();
        player.inputHandler.UseJump();
        isAbilityDone = true;
        reduceJumpCount();
    }

    bool canJump => jumpCount > 0;

    public void ResetJumpCount() => jumpCount = playerData.jumpsTotal;
    public void reduceJumpCount() => jumpCount--;
}
