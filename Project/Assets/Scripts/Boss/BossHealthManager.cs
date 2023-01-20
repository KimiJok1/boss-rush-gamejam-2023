using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthManager : MonoBehaviour
{
    [SerializeField] private Slider[] healthBar;

    private float LastHitTime = 0.0f;
    private int previousHealth = 100;
    private int health = 100;

    void Start()
    {
        SetMaxHealth(100);
        SetHealth(80);
    }

    void Update()
    {
        if( LastHitTime > 0.0f )
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

    void SetMaxHealth(int _health)
    {
        previousHealth = _health;
        health = _health;
        foreach(Slider slider in healthBar)
        {
            slider.maxValue = _health;
            slider.value = _health;
        }
    }

    void SetHealth(int _health)
    {
        LastHitTime = 1.0f;
        previousHealth = health;
        health = _health;
        healthBar[0].value = _health;
    }
}
