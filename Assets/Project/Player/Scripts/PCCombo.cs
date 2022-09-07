using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PCCombo : MonoBehaviour
{
    private PCReferences pcReferences;
    [HideInInspector] public Weapon currentWeapon;
    [HideInInspector] public bool isAttacking;
    [HideInInspector] public float attackTimer;
    [HideInInspector] public float attackCount;
    [HideInInspector] public bool comboHitOver;
    [HideInInspector] public int currentComboProgress;
    [HideInInspector] public float comboDelayTimer;
    [HideInInspector] public float comboCancelTimer;
    [HideInInspector] public bool delayAfterHit;
    private bool comboCancelDelay;

    private void Awake()
    {
        pcReferences = this.gameObject.GetComponent<PCReferences>();
    }

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

    private void ComboSetup()
    {
        comboHitOver = false;
        delayAfterHit = false;
        currentComboProgress = 0;
        currentWeapon.weaponAttacks[currentComboProgress].attackObject.SetActive(false);
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
        if (comboCancelDelay) comboCancelDelay = false;
        attackTimer = currentWeapon.weaponAttacks[currentComboProgress].duration;
        currentWeapon.weaponAttacks[currentComboProgress].attackObject.SetActive(true);
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
            isAttacking = false;
            currentAttack.attackObject.SetActive(false);
            EndComboHit();
        }
    }

    private void CheckActivatingHitboxes(WeaponAttack currentAttack)
    {
        foreach (WeaponAttack.WeaponAttackHitboxSequence hitboxToCheck in currentAttack.weaponAttackHitboxSequence)
        {
            if (attackCount > hitboxToCheck.activationDelayAfterStart) hitboxToCheck.hitbox.SetActive(true);
            if (attackCount > hitboxToCheck.deactivationDelayAfterStart) hitboxToCheck.hitbox.SetActive(false);
        }
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
        if (currentComboProgress + 1 == currentWeapon.weaponAttacks.Length)
        {
            currentComboProgress = 0;
            comboDelayTimer = pcReferences.pcData.comboEndCooldown;
        }
        else
        {
            currentComboProgress++;
            comboDelayTimer = pcReferences.pcData.comboDelayBetweenHits;
            comboCancelTimer = pcReferences.pcData.comboResetCooldown;
            comboCancelDelay = true;
        }
        delayAfterHit = true;
        comboHitOver = true;
    }
}
