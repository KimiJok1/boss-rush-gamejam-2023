using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]private float speed = 6.0f;
    private float horizontalInput;

    [Header("Jumping")]
    [SerializeField]private float jumpForce = 4.0f;
    [SerializeField]private float gravityModifier = 1.0f;
    private bool isOnGround = false;

    [Header("Sprites")]
    [SerializeField]private GameObject sprite;
    private GameObject canvas;

    [Header("Stats")]
    private int health = 100;
    [SerializeField]private int maxHealth = 100;

    void Start()
    {
        // gravity
        Physics.gravity *= gravityModifier;
        canvas = GameObject.Find("Canvas");
        health = maxHealth;
    }

    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    public void UpdateUI()
    {
        canvas.transform.Find("Healthbar").GetComponent<Slider>().value = health;
        canvas.transform.Find("HealthText").GetComponent<TextMeshProUGUI>().text = health.ToString() + "/" + maxHealth.ToString();
    }

    public void OnHit()
    {
        health -= 10;

        if (health <= 0)
            Die();
        else
            UpdateUI();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
