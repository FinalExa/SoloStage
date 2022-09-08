using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Weapon : MonoBehaviour
{
    public string weaponName;
    public float currentDamage;
    public float comboCancelTime;
    public float comboEndDelay;
    public WeaponAttack[] weaponAttacks;
    public List<Health> hitTargets;
    public string damageTag;

    private void Start()
    {
        ReferencesSetup();
    }

    private void ReferencesSetup()
    {
        foreach (WeaponAttack weaponAttack in weaponAttacks)
        {
            foreach (WeaponAttack.WeaponAttackHitboxSequence weaponAttackHitboxSequence in weaponAttack.weaponAttackHitboxSequence)
            {
                Attack attackToSet = weaponAttackHitboxSequence.hitbox.GetComponent<Attack>();
                if (attackToSet != null)
                {
                    attackToSet.thisWeapon = this;
                    attackToSet.whoToDamage = damageTag;
                }
            }
        }
    }
}
