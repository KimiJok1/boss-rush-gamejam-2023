using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;
using Game.Weapons.Components.ComponentData;

namespace Game.Weapons.Components 
{
    public class Damage : WeaponComponent<DamageData, AttackDamage>
    {
        private ActionHitBox hitBox;

        protected override void Awake()
        {
            base.Awake();

            hitBox = GetComponent<ActionHitBox>();
        }

        private void HandleDamageCollision(Collider2D[] colliders)
        {
            foreach (var collider in colliders)
            {
                if(collider.TryGetComponent(out IDamageable damageable))
                    damageable.TakeDamage(attackData.Damage);
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            hitBox.OnHit += HandleDamageCollision;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            hitBox.OnHit -= HandleDamageCollision;
        }

    }
}

