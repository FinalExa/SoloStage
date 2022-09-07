using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class WeaponAttack
{
    public float damage;
    public GameObject objectToActivate;
    public struct WeaponAttackHitboxSequence
    {
        public GameObject hitbox;
        public float activationDelayAfterStart;
    }
    public WeaponAttackHitboxSequence[] weaponAttackHitboxSequence;
    public bool hasAnimation;
}
