using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Weapons.Components.ComponentData
{
    [System.Serializable]
    public class AttackActionHitBox : AttackData
    {
        public bool Debug;
        [field: SerializeField] public Rect HitBox { get; private set; }
    }
}
