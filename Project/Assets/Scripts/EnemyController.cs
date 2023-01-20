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
    [SerializeField] private Slider[] healthBar;
    [SerializeField] private TextMeshProUGUI healthText;

    [Header("Stats")]
    private int health = 100;
    private int previousHealth = 100;
    [SerializeField] private int maxHealth = 100;

    private float LastHitTime = 0.0f;

    void Start()
    {
        // gravity
        Physics.gravity *= gravityModifier;
        health = maxHealth;
        previousHealth = health;

        foreach (Slider slider in healthBar)
        {
            slider.maxValue = maxHealth;
            slider.value = maxHealth;
        }
    }

    void Update()
    {
        if(LastHitTime > 0.0f)
        {
            LastHitTime -= Time.deltaTime;
        }
        else
        {
            if(previousHealth > health)
            {
                healthBar[1].value -= .1f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void UpdateUI()
    {

        healthBar[0].value = health;
        healthText.text = health.ToString() + "/" + maxHealth.ToString();
    }

    public void OnHit()
    {
        previousHealth = health;
        health -= 10;
        LastHitTime = 1.0f;

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
