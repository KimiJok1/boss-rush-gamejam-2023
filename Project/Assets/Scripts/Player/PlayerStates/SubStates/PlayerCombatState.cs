using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Weapons;

public class PlayerCombatState : PlayerAbilityState
{
    private Weapon weapon;


    public PlayerCombatState(Player player, StateMachine stateMachine, PlayerData playerData, string animBoolName, Weapon weapon) : base(player, stateMachine, playerData, animBoolName)
    {
        this.weapon = weapon;

        weapon.OnExit += ExitHandler;
    }

    public override void Enter()
    {
        base.Enter();

        weapon.Enter();
    }

    private void ExitHandler()
    {
        AnimationFinishedTrigger();
        isAbilityDone = true;
    }
}
