using UnityEngine;
using Common.Utilities;
using System;
using Game.Player;

namespace Game.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [field: SerializeField] public WeaponDataSO weaponData { get; private set;}
        [SerializeField] private float comboResetTime;

        public int ComboCount
        {
            get => comboCount;
            private set =>
                comboCount = value >= weaponData.maxComboCount ? 0 : value;
            
        }

        private Animator anim;
        [SerializeField]
        private GameObject sprite;
        public AnimationEventHandler animEventHandler { get; private set; }

        public PlayerController playerController { get; private set; }

        private int comboCount = 0;

        private Timer timer;

        public event Action OnExit;
        public event Action OnEnter;

        public void Enter()
        {
            timer.StopTimer();

            anim.SetBool("Attack", true);
            anim.SetInteger("ComboCounter", ComboCount);
            OnEnter?.Invoke();
        }

        private void Awake()
        {
            timer = new Timer(comboResetTime);
            // sprite = transform.Find("Sprite").gameObject;
            playerController = GetComponentInParent<PlayerController>();
            anim = sprite.GetComponent<Animator>();
            animEventHandler = sprite.GetComponent<AnimationEventHandler>();
        }

        private void Update() => timer.UpdateTimer();

        private void ResetComoboCount() => ComboCount = 0;

        private void Exit()
        {
            anim.SetBool("Attack", false);
            OnExit?.Invoke();
            ComboCount++;
            timer.StartTimer();
        }

        private void OnEnable() {
            animEventHandler.OnAnimationDone += Exit;
            timer.OnTimerDone += ResetComoboCount;
            
        }

        private void OnDisable() {
            animEventHandler.OnAnimationDone -= Exit;
            timer.OnTimerDone -= ResetComoboCount;
        }
    }
}


