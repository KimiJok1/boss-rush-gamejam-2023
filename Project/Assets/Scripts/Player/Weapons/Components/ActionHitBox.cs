using UnityEngine;
using Game.Player;
using System;

namespace Game.Weapons.Components.ComponentData
{
    public class ActionHitBox : WeaponComponent<ActionHitBoxData, AttackActionHitBox>
    {
        public event Action<Collider2D[]> OnHit;

        private PlayerController pc;

        private Vector2 offset;

        private Collider2D[] hitColliders;

        private void HandleAttackAction()
        {
            Debug.Log("Attack Action");
            offset.Set(
                transform.position.x + attackData.HitBox.center.x * PlayerController.forwardDirection, 
                transform.position.y + attackData.HitBox.center.y
                );
    
            hitColliders = Physics2D.OverlapBoxAll(offset, attackData.HitBox.size, 0, data.HitLayers);

            if (hitColliders.Length > 0)
            {
                OnHit?.Invoke(hitColliders);
            }

        }

        protected override void OnEnable()
        {
            base.OnEnable();
            animationEventHandler.OnAttackAction += HandleAttackAction;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            animationEventHandler.OnAttackAction -= HandleAttackAction;
        }

        protected void OnDrawGizmosSelected() {

            if(data == null)
                return;
            foreach (var attackData in data.AttackData)
            {
                if(!attackData.Debug)
                    continue;
                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(
                    transform.position + (Vector3)attackData.HitBox.center,
                    (Vector3)attackData.HitBox.size
                );
            }
        }
        
    }
}
