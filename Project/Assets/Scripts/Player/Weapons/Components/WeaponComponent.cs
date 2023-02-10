using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Weapons.Components
{
    public abstract class WeaponComponent : MonoBehaviour
    {

        protected Weapon weapon;

        protected bool isAttackActive;

        protected AnimationEventHandler animationEventHandler => weapon.animEventHandler;


        protected virtual void Awake()
        {
            weapon = GetComponent<Weapon>();
        }

        protected virtual void HandleEnter()
        {
            isAttackActive = true;
        }

        protected virtual void HandleExit()
        {
            isAttackActive = false;
        }

        protected virtual void OnEnable()
        {
            weapon.OnEnter += HandleEnter;
            weapon.OnExit += HandleExit;
        }

        protected virtual void OnDisable()
        {
            weapon.OnEnter -= HandleEnter;
            weapon.OnExit -= HandleExit;
        }


    }

    public abstract class WeaponComponent<T1, T2> : WeaponComponent where T1 : ComponentData.ComponentData<T2> where T2 : ComponentData.AttackData
    {
        protected T1 data;
        protected T2 attackData;

        protected override void HandleEnter()
        {
            base.HandleEnter();

            attackData = data.AttackData[weapon.ComboCount];
        }


        protected override void Awake()
        {
            base.Awake();

            data = weapon.weaponData.GetData<T1>();
        }
    }
}