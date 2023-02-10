using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Weapons.Components.ComponentData
{
    [System.Serializable]
    public class AttackMovement : AttackData
    {
        [field: SerializeField] public Vector2 Direction { get; private set; }
        [field: SerializeField] public float velocity { get; private set; }
    }
}