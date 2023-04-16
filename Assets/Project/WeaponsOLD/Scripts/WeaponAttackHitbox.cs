using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttackHitbox : Attack
{
    [HideInInspector] public Weapon thisWeapon;
    public void InitializeAttack(string damageTag, float sourceElementDuration, Weapon weapon)
    {
        InitializeAttack(damageTag, sourceElementDuration);
        thisWeapon = weapon;
    }
    protected override void SendAttackData()
    {
        if (otherAttackCheck != null && !thisWeapon.hitTargets.Contains(otherAttackCheck))
        {
            if (otherCollider.CompareTag(whoToDamage))
            {
                if (canApplyElement) otherAttackCheck.ElementApplication(infusedElement, elementDuration, false);
                otherAttackCheck.DealDamage(thisWeapon.currentDamage);
                thisWeapon.hitTargets.Add(otherAttackCheck);
            }
            else if (otherCollider.CompareTag("Invulnerable")) thisWeapon.hitTargets.Add(otherAttackCheck);
        }
    }
}
