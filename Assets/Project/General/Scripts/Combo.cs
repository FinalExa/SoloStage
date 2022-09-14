using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Combo : MonoBehaviour
{
    [HideInInspector] public Weapon currentWeapon;
    [HideInInspector] public int currentComboProgress;
    [HideInInspector] public bool isAttacking;
    [HideInInspector] public bool comboHitOver;
    [HideInInspector] public bool delayAfterHit;
    [HideInInspector] public float attackTimer;
    [HideInInspector] public float attackCount;
    [HideInInspector] public float comboDelayTimer;
    [HideInInspector] public float comboCancelTimer;
    protected bool comboCancelDelay;

    private void Start()
    {
        ComboSetup();
    }
    private void FixedUpdate()
    {
        if (isAttacking) Attacking();
        if (delayAfterHit) DelayAfterHit();
        if (comboCancelDelay) CountToCancelCombo();
    }

    public void SetWeapon(Weapon weaponToSet)
    {
        if (currentWeapon != weaponToSet) currentWeapon = weaponToSet;
    }
    private void ComboSetup()
    {
        comboHitOver = true;
        delayAfterHit = false;
        currentComboProgress = 0;
    }
    public void StartComboHitCheck()
    {
        if (!delayAfterHit) StartComboHit();
    }

    private void DelayAfterHit()
    {
        if (comboDelayTimer > 0) comboDelayTimer -= Time.fixedDeltaTime;
        else delayAfterHit = false;
    }

    private void StartComboHit()
    {
        comboHitOver = false;
        comboCancelDelay = false;
        attackTimer = currentWeapon.weaponAttacks[currentComboProgress].duration;
        currentWeapon.weaponAttacks[currentComboProgress].attackObject.SetActive(true);
        currentWeapon.currentDamage = currentWeapon.weaponAttacks[currentComboProgress].damage;
        attackCount = 0;
        isAttacking = true;
    }

    private void Attacking()
    {
        WeaponAttack currentAttack = currentWeapon.weaponAttacks[currentComboProgress];
        if (attackTimer > 0)
        {
            attackTimer -= Time.fixedDeltaTime;
            attackCount += Time.fixedDeltaTime;
            CheckActivatingHitboxes(currentAttack);
        }
        else
        {
            CheckActivatingHitboxes(currentAttack);
            isAttacking = false;
            currentAttack.attackObject.SetActive(false);
            EndComboHit();
        }
    }

    private void CheckActivatingHitboxes(WeaponAttack currentAttack)
    {
        foreach (WeaponAttack.WeaponAttackHitboxSequence hitboxToCheck in currentAttack.weaponAttackHitboxSequence)
        {
            if (attackCount >= hitboxToCheck.activationDelayAfterStart)
            {
                hitboxToCheck.hitbox.SetActive(true);
                Infusion(hitboxToCheck);
            }
            if (attackCount >= hitboxToCheck.deactivationDelayAfterStart)
            {
                hitboxToCheck.hitbox.SetActive(false);
                hitboxToCheck.attackRef.canApplyElement = false;
            }
        }
    }

    public virtual void Infusion(WeaponAttack.WeaponAttackHitboxSequence hitboxToCheck)
    {
        return;
    }

    private void CountToCancelCombo()
    {
        if (comboCancelTimer > 0) comboCancelTimer -= Time.fixedDeltaTime;
        else
        {
            currentWeapon.weaponAttacks[currentComboProgress].attackObject.SetActive(false);
            currentComboProgress = 0;
            currentWeapon.weaponAttacks[currentComboProgress].attackObject.SetActive(true);
            comboCancelDelay = false;
        }
    }

    public void EndComboHit()
    {
        currentWeapon.hitTargets.Clear();
        if (currentComboProgress + 1 == currentWeapon.weaponAttacks.Length)
        {
            currentComboProgress = 0;
            comboDelayTimer = currentWeapon.comboEndDelay;
        }
        else
        {
            comboDelayTimer = currentWeapon.weaponAttacks[currentComboProgress].afterDelay;
            currentComboProgress++;
            comboCancelTimer = currentWeapon.comboCancelTime;
            comboCancelDelay = true;
        }
        delayAfterHit = true;
        comboHitOver = true;
    }
}
