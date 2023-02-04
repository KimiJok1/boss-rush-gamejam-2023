using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Weapons
{

    public class AnimationEventHandler : MonoBehaviour
    {
        public event System.Action OnAnimationDone;

        private void OnAnimationTrigger() => OnAnimationDone?.Invoke();
        
    }
}
