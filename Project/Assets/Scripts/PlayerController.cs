using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
    [SerializeField] private Animator animator;

    private Rigidbody2D rb;

    void Start()
    {
        // gravity
        Physics.gravity *= gravityModifier;
        rb = GetComponent<Rigidbody2D>();
        jumpsLeft = extraJumps;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        
        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
        {
            rb.velocity = Vector3.up * jumpForce;
            Instantiate(JumpEffect, transform.position, Quaternion.identity);
            // isOnGround = false;
            --jumpsLeft;
        }

        //flip sprite
        if (horizontalInput > 0)
        {
            sprite.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (horizontalInput < 0)
        {
            sprite.localEulerAngles = new Vector3(0, -180, 0);
        }
        
        // dashing
        // TODO: add it

        // get mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 objectPos = Camera.main.WorldToScreenPoint(sprite.position);
        Vector3 dir = mousePos - sprite.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        mousePos.z = 0;
        mousePos = sprite.position + (mousePos - sprite.position).normalized * targetRange;
        
        target.position = mousePos;
        target.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        // mouse button click
        if (Input.GetButtonDown("Fire1"))
        {
            // find enemies that collide with target
            Collider2D[] enemies = Physics2D.OverlapCircleAll(target.position, 0.5f);
            foreach (Collider2D enemy in enemies)
            {
                if (enemy.CompareTag("Enemy"))
                {
                    enemy.GetComponent<EnemyHealth>().TakeDamage(10);
                }
            }
        }
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
