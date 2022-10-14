using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Weapon : MonoBehaviour
{
    public string weaponName;
    public float comboCancelTime;
    public float comboEndDelay;
    public WeaponAttack[] weaponAttacks;
    [HideInInspector] public List<AttackCheck> hitTargets;
    [HideInInspector] public string damageTag;
    [HideInInspector] public float currentDamage;
    [HideInInspector] public float elementDuration;
    public void ReferencesSetup(string whoToDamage, float _elementDuration)
    {
        elementDuration = _elementDuration;
        damageTag = whoToDamage;
        foreach (WeaponAttack weaponAttack in weaponAttacks)
        {
            for (int i = 0; i < weaponAttack.weaponAttackHitboxSequence.Length; i++)
            {
                WeaponAttackHitbox attackToSet = weaponAttack.weaponAttackHitboxSequence[i].attackRef.gameObject.GetComponent<WeaponAttackHitbox>();
                weaponAttack.weaponAttackHitboxSequence[i].attackRef = attackToSet;
                if (attackToSet != null) attackToSet.InitializeAttack(damageTag, elementDuration, this);
            }
        }
    }
}
