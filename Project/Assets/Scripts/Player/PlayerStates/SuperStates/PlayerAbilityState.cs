using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Weapons;

public class PlayerAbilityState : State
{
    protected bool isAbilityDone;

    public PlayerAbilityState(Player player, StateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        isAbilityDone = false;
        Debug.Log("Entered Ability State");
    }

    public override void Exit()
    {
        base.Exit();
    }


    public override void LUpdate()
    {
        base.LUpdate();

        if (isAbilityDone)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PUpdate()
    {
        base.PUpdate();
    }

    
}
