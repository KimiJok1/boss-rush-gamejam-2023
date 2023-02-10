using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Game.Weapons.Components.ComponentData;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Data/Weapon Data")]
public class WeaponDataSO : ScriptableObject
{
        [field: SerializeField] public int maxComboCount { get; private set;}
        [SerializeField] private float comboResetTime;

        [field: SerializeReference] public List<ComponentData> components { get; private set;}

        public T GetData<T>() 
        {
                return components.OfType<T>().FirstOrDefault();
        }

        [ContextMenu("Add Movement Data")]
        private void AddMovementData() => components.Add(new MovementData());

        [ContextMenu("Add Action Hit Box Data")]
        private void AddActionHitBoxData() => components.Add(new ActionHitBoxData());

        [ContextMenu("Add Damage Data")]
        private void AddDamageData() => components.Add(new DamageData());

}
