using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0f;
    private float horizontalInput;

    public float jumpForce = 4.0f;
    public float gravityModifier = 1.0f;
    private bool isOnGround = false;

    public float wallJumpForce = 4.0f;
    private bool isOnWall = false;

    public float targetRange = 2.0f;

    private GameObject sprite;

    void Start()
    {
        // gravity
        Physics.gravity *= gravityModifier;
        sprite = GameObject.Find("Sprite");
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalInput * speed, GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }

        if (isOnWall)
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -speed);
        }

        // get mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 objectPos = Camera.main.WorldToScreenPoint(sprite.transform.position);
        Vector3 dir = mousePos - sprite.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        mousePos.z = 0;
        mousePos = sprite.transform.position + (mousePos - sprite.transform.position).normalized * targetRange;
        
        sprite.transform.Find("Target").transform.position = mousePos;
        sprite.transform.Find("Target").transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
