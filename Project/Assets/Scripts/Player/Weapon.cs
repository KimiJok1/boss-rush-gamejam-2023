using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Weapons
{
    public class Weapon : MonoBehaviour
    {
        private Animator anim;
        private GameObject sprite;
        private AnimationEventHandler animEventHandler;

        public event System.Action OnExit;

        public void Enter()
        {
            anim.SetBool("Attack", true);
        }

        private void Awake()
        {
            sprite = transform.Find("Sprite").gameObject;
            anim = sprite.GetComponent<Animator>();
            animEventHandler = sprite.GetComponent<AnimationEventHandler>();
        }

        private void Exit()
        {
            anim.SetBool("Attack", false);
            OnExit?.Invoke();
        }

        private void OnEnable() {
            animEventHandler.OnAnimationDone += Exit;
        }

        private void OnDisable() {
            animEventHandler.OnAnimationDone -= Exit;
        }
    }
}


