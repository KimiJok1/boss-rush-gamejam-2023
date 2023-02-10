using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;

public class PlayerGroundState : State
{
    protected int xInput;
    protected bool jumpInput;


    protected PlayerController PlayerController 
    {
        get
        {
            if(playerController == null)
            {
                playerController = player.GetComponent<PlayerController>();
            }
            return playerController;
        }
    }

    private PlayerController playerController;

    public PlayerGroundState(Player player, StateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        // player.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LUpdate()
    {
        base.LUpdate();

        xInput = player.inputHandler.InputX;

        if(player.inputHandler.attackInput)
        {
            stateMachine.ChangeState(player.primaryAttackState);
        }

    }

    public override void PUpdate()
    {
        base.PUpdate();

    }

    
}
