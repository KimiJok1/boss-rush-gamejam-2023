using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]private float speed = 6.0f;
    private float horizontalInput;

    [Header("Jumping")]
    [SerializeField]private float jumpForce = 4.0f;
    [SerializeField]private float gravityModifier = 1.0f;
    private bool isOnGround = false;

    [Header("Aiming")]
    [SerializeField]private float targetRange = 2.0f;

    [Header("Dashing")]
    [SerializeField]private float dashForce = 4.0f;

    [Header("Sprites")]
    [SerializeField]private GameObject sprite;
    [SerializeField]private GameObject target;

    void Start()
    {
        // gravity
        Physics.gravity *= gravityModifier;
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
        
        // dashing
        // TODO: add it

        // get mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 objectPos = Camera.main.WorldToScreenPoint(sprite.transform.position);
        Vector3 dir = mousePos - sprite.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        mousePos.z = 0;
        mousePos = sprite.transform.position + (mousePos - sprite.transform.position).normalized * targetRange;
        
        target.transform.position = mousePos;
        target.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        // mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // find enemies that collide with target
            Collider2D[] enemies = Physics2D.OverlapCircleAll(target.transform.position, 0.5f);
            foreach (Collider2D enemy in enemies)
            {
                if (enemy.gameObject.CompareTag("Enemy"))
                {
                    enemy.gameObject.GetComponent<EnemyController>().OnHit();
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

            if (checkDir)
                isOnGround = checkDir;
        }
    }
}
