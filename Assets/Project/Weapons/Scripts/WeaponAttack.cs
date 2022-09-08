using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class WeaponAttack
{
    public float damage;
    public float duration;
    public float afterDelay;
    public GameObject attackObject;
    [System.Serializable]
    public struct WeaponAttackHitboxSequence
    {
        public GameObject hitbox;
        public float activationDelayAfterStart;
        public float deactivationDelayAfterStart;
    }
    public WeaponAttackHitboxSequence[] weaponAttackHitboxSequence;
    public bool hasAnimation;
}