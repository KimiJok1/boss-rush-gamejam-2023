using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private Camera mainCamera;

    public Vector2 movementInput { get; private set; }
    public int InputX { get; private set; }
    public int InputY { get; private set; }
    public bool jumpInput { get; private set; }
    public bool attackInput { get; private set; }

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        mainCamera = Camera.main;
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        // Debug.Log("Attack Input");
        if (context.started)
        {
            attackInput = true;
        }
        else if (context.canceled)
        {
            attackInput = false;
        }
        // print(attackInput);
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            jumpInput = true;
        }
        else if (context.canceled)
        {
            jumpInput = false;
        }
    }

    public void OnMovementInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();

        InputX = (int)movementInput.x;
        InputY = (int)movementInput.y;
    }
}
