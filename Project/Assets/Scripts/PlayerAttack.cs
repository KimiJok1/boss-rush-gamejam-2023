using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float VerticalDirection;
    [SerializeField] private Animator animator;

    void Update()
    {
        VerticalDirection = Input.GetAxisRaw("Vertical");
        if (VerticalDirection > 0)
        {
            Debug.Log("Up");
        }
        else if (VerticalDirection < 0)
        {
            Debug.Log("Down");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Attack1");
        }
    }
}
