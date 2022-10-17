using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : Weapon
{
    public float performableRange;
    public Reaction.Element weaponElement;
    public float enemyElementDuration;
    protected override void SetSingleAttackHitbox(WeaponAttackHitbox weaponAttackHitbox)
    {
        if (weaponAttackHitbox != null)
        {
            weaponAttackHitbox.InitializeAttack(damageTag, elementDuration, this);
            if (weaponElement != Reaction.Element.NONE)
            {
                weaponAttackHitbox.canApplyElement = true;
                weaponAttackHitbox.infusedElement = weaponElement;
                weaponAttackHitbox.elementDuration = enemyElementDuration;
            }
        }
    }
}
