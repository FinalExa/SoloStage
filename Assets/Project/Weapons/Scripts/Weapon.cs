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
    public virtual void ReferencesSetup(string whoToDamage, float _elementDuration)
    {
        elementDuration = _elementDuration;
        damageTag = whoToDamage;
        foreach (WeaponAttack weaponAttack in weaponAttacks) GetSingleAttack(weaponAttack);
    }

    protected virtual void GetSingleAttack(WeaponAttack weaponAttack)
    {
        for (int i = 0; i < weaponAttack.weaponAttackHitboxSequence.Length; i++) GetSingleAttackHitbox(weaponAttack, weaponAttack.weaponAttackHitboxSequence, i);
    }

    protected virtual void GetSingleAttackHitbox(WeaponAttack weaponAttack, WeaponAttack.WeaponAttackHitboxSequence[] weaponAttackHitboxSequence, int index)
    {
        SetSingleAttackHitbox(weaponAttack.weaponAttackHitboxSequence[index].attackRef.gameObject.GetComponent<WeaponAttackHitbox>());
    }

    protected virtual void SetSingleAttackHitbox(WeaponAttackHitbox weaponAttackHitbox)
    {
        if (weaponAttackHitbox != null) weaponAttackHitbox.InitializeAttack(damageTag, elementDuration, this);
    }
}
