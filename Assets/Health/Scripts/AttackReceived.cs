using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackReceived : MonoBehaviour
{
    private Health health;
    public enum GameTargets { PLAYER, ENEMY, PUZZLE_ELEMENT }
    [SerializeField] private GameTargets thisType;
    public bool ignoresDamage;

    protected virtual void Awake()
    {
        health = this.gameObject.GetComponent<Health>();
    }

    public void AttackReceivedOperation(List<GameTargets> receivedTargets, float damage, List<WeaponAttack.WeaponAttackType> weaponAttackTypes, bool invulnerable, GameObject attacker)
    {
        if (receivedTargets.Contains(thisType))
        {
            if (!ignoresDamage) DealDamage(invulnerable, damage);
            else if (health != null)
            {
                health.OnHitSetSpriteColorChange();
                health.OnHitSound();
            }
        }
    }

    public virtual void DealDamage(bool invulnerable, float damage)
    {
        if (health != null && !invulnerable) health.HealthAddValue(-damage, true);
    }

    public void SetInvincibility(bool invincibility)
    {
        ignoresDamage = invincibility;
    }
}
