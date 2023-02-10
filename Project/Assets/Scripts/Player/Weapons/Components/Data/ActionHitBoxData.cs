using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Weapons.Components.ComponentData
{
    public class ActionHitBoxData : ComponentData<AttackActionHitBox>
    {
        [field: SerializeField] public LayerMask HitLayers { get; private set; }
    }
}
