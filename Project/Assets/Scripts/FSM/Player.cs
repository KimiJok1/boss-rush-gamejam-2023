using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Weapons;

public class Player : MonoBehaviour
{
    #region Variables
    public StateMachine stateMachine;

    public PlayerCombatState playerCombatState;

    public PlayerCombatState primaryAttackState { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerWalkState WalkState { get; private set; }
    #endregion

    #region Components
    public Animator anim;
    public Rigidbody2D rb;
    public InputHandler inputHandler;
    public GameObject sprite;

    #endregion

    private Weapon weapon;

    #region Unity Methods
    private void Awake()
    {
        stateMachine = new StateMachine();
        weapon = GetComponentInChildren<Weapon>();


        primaryAttackState = new PlayerCombatState(this, stateMachine, null, "Attack", weapon);
        IdleState = new PlayerIdleState(this, stateMachine, null, "Idle");
        WalkState = new PlayerWalkState(this, stateMachine, null, "Walk");
         
    }

    private void Start() {
        sprite = transform.Find("Sprite").gameObject;
        anim = sprite.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        inputHandler = GetComponent<InputHandler>();

        stateMachine.Initialize(IdleState);
    }

    private void Update() {
        stateMachine.currentState.LUpdate();
    }

    private void FixedUpdate() {
        stateMachine.currentState.PUpdate();
    }

    private void AnimationTrigger () => stateMachine.currentState.AnimationTrigger();
    private void AnimationFinishedTrigger() => stateMachine.currentState.AnimationFinishedTrigger();


    #endregion
}
