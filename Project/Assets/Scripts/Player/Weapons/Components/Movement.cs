using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;
using Game.Weapons.Components.ComponentData;

namespace Game.Weapons.Components 
{
    public class Movement : WeaponComponent<MovementData, AttackMovement>
    {
        private PlayerController pc;

        private PlayerController PlayerController => pc != null ? pc : pc = GetComponent<PlayerController>();
        
        private void HandleStartMovement()
        {
            PlayerController.SetVelocity(attackData.velocity, attackData.Direction, PlayerController.forwardDirection);
        }

        private void HandleStopMovement()
        {
            PlayerController.SetVelocityZero();
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            animationEventHandler.OnStartMovement += HandleStartMovement;
            animationEventHandler.OnStopMovement += HandleStopMovement;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            animationEventHandler.OnStartMovement -= HandleStartMovement;
            animationEventHandler.OnStopMovement -= HandleStopMovement;
        }

    }
}

