using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour, IDamageable
{
    public BossHealthManager healthManager;

    public void TakeDamage(int damage)
    {
        healthManager.TakeDamage(damage);
    }

}
