using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
public class PlayerController : MonoBehaviour
{
    public int forwardDirection = 1;
    [Header("Movement")]
    [SerializeField] private float speed = 6.0f;
    private float horizontalInput;

    [Header("Jumping")]
    [SerializeField] private float jumpForce = 4.0f;
    [SerializeField] private float gravityModifier = 1.0f;
    [SerializeField] private int extraJumps = 1;
    [SerializeField] private GameObject JumpEffect;
    private int jumpsLeft;
    private bool isOnGround = false;

    [Header("Aiming")]
    [SerializeField] private float targetRange = 2.0f;

    [Header("Dashing")]
    [SerializeField] private float dashForce = 4.0f;

    [Header("Sprites")]
    [SerializeField] private Transform sprite;
    [SerializeField] private Transform target;
    // [SerializeField] private Animator animator;

    private Rigidbody2D rb;

    void Start()
    {
        // gravity
        Physics.gravity *= gravityModifier;
        rb = GetComponent<Rigidbody2D>();
        jumpsLeft = extraJumps;
    }

    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        rb.velocity = new Vector2(velocity * angle.x * direction, velocity * angle.y);
    }

    public void SetVelocity(float velocity, Vector2 direction)
    {
        rb.velocity = direction * velocity;
    }


    public void SetVelocityX(float velocity)
    {
        rb.velocity = new Vector2(velocity, rb.velocity.y);
    }

    public void SetVelocityZero()
    {
        rb.velocity = Vector2.zero;
    }

    void Update()
    {
        float rawHorizontalInput = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
        {
            rb.velocity = Vector3.up * jumpForce;
            Instantiate(JumpEffect, transform.position, Quaternion.identity);
            // isOnGround = false;
            --jumpsLeft;
        }

        //flip sprite
        if (rawHorizontalInput != forwardDirection && rawHorizontalInput != 0)
        {
            flip();
        }
        
        // dashing
        // TODO: add it

    }

    void flip()
    {
        forwardDirection *= -1;
        sprite.Rotate(0f, 180f, 0f);

    }

    private bool checkDir = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy"))
        {
            checkDir = true;
            ContactPoint2D[] allPoints = new ContactPoint2D[collision.contactCount];
            collision.GetContacts(allPoints);

            foreach (var i in allPoints)
                if (i.point.y > transform.position.y) 
                    checkDir = false;

            if (checkDir) {
                // isOnGround = checkDir;
                jumpsLeft = extraJumps;
            }
            

        }
    }
}
}