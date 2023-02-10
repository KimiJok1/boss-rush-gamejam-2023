using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 
using UnityEngine.UI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    private int health = 100;
    private float previousHealth = 100;
    [SerializeField] private int maxHealth = 100;

    [SerializeField] private Slider[] healthBar;
    [SerializeField] private TextMeshProUGUI healthText;

    [SerializeField] private UnityEvent OnDeath;

    private float LastHitTime = 0.0f;

    void Start()
    {
        health = maxHealth;
        previousHealth = health;

        foreach (Slider slider in healthBar)
        {
            slider.maxValue = maxHealth;
            slider.value = maxHealth;
        }
        UpdateUI();
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
                previousHealth = healthBar[1].value;
            }
        }
    }

    private void UpdateUI()
    {

        healthBar[0].value = health;
        healthText.text = health.ToString() + "/" + maxHealth.ToString();
    }


    public void TakeDamage(int damage)
    {
        previousHealth = health;
        health -= damage;
        LastHitTime = 1.0f;

        UpdateUI();
        if (health <= 0)
            OnDeath.Invoke();
    }
}
