using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Weapons;

public class State
{
    protected Player player;
    protected StateMachine stateMachine;
    protected PlayerData playerData;

    protected bool isAnimationDone;
    protected bool isExitingState;

    private string animBoolName;

    public State(Player player, StateMachine stateMachine, PlayerData playerData, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);
        isAnimationDone = false;
        isExitingState = false;
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
        isExitingState = true;
    }

    public virtual void LUpdate()
    {

    }

    public virtual void PUpdate()
    {

    }


    public virtual void AnimationTrigger() => isAnimationDone = false;
    public virtual void AnimationFinishedTrigger() => isAnimationDone = true;
}


