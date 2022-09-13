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
            for (int i = 0; i < weaponAttack.weaponAttackHitboxSequence.Length; i++)
            {
                Attack attackToSet = weaponAttack.weaponAttackHitboxSequence[i].hitbox.GetComponent<Attack>();
                weaponAttack.weaponAttackHitboxSequence[i].attackRef = attackToSet;
                if (attackToSet != null)
                {
                    attackToSet.thisWeapon = this;
                    attackToSet.whoToDamage = damageTag;
                }
            }
        }
    }
}
