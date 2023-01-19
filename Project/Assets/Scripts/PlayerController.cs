using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0f;
    private float horizontalInput;

    // jump
    public float jumpForce = 4.0f;
    public float gravityModifier = 1.0f;
    private bool isOnGround = false;

    // walljump
    public float wallJumpForce = 4.0f;
    private bool isOnWall = false;

    // Start is called before the first frame update
    void Start()
    {
        // gravity
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // move the player
        horizontalInput = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalInput * speed, GetComponent<Rigidbody2D>().velocity.y);

        // jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }

        if (isOnWall)
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            isOnWall = false;
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            isOnWall = true;
        }
    }
}
