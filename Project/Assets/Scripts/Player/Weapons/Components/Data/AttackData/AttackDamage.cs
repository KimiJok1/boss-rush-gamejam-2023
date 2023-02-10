using System;
using UnityEngine;

namespace Game.Weapons.Components.ComponentData
{
    [System.Serializable]
    public class AttackDamage : AttackData
    {
        [field: SerializeField] public int Damage { get; private set; }
    }
}
