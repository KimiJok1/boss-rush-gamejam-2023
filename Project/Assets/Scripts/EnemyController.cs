using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 6.0f;
    private float horizontalInput;

    [Header("Jumping")]
    [SerializeField] private float jumpForce = 4.0f;
    [SerializeField] private float gravityModifier = 1.0f;
    private bool isOnGround = false;

    [Header("Sprites")]
    [SerializeField] private GameObject sprite;


    void Start()
    {
        // gravity
        Physics.gravity *= gravityModifier;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }


    public void Die()
    {
        Destroy(gameObject);
    }
}
