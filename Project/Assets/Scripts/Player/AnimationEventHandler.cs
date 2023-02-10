using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game.Weapons
{

    public class AnimationEventHandler : MonoBehaviour
    {
        public event Action OnAnimationDone;
        public event Action OnStartMovement;
        public event Action OnStopMovement;

        private void OnAnimationTrigger() => OnAnimationDone?.Invoke();
        private void OnStartMovementTrigger() => OnStartMovement?.Invoke();
        private void OnStopMovementTrigger() => OnStopMovement?.Invoke();
        
    }
}
