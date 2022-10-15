using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ReactionOvertimeDamage
{
    public bool enabled;
    public float baseValue;
    public float multiplier;
    public Reaction.Element damageType;
    public float timeBetweenHits;
    public bool appliesElement;
    public float elementDuration;
    public bool firstHitOn;
    public bool hasAoe;
    public bool aoeHitsSingleTarget;
    public float aoeRange;
    private bool firstHitDone;
    private float timer;
    private float damage;
    private AttackCheck targetAttackCheck;
    private ReactionObject originReactionObject;
    private string whoToDamage;
    public void SetStartupValues(AttackCheck attackCheck, string damageTag)
    {
        targetAttackCheck = attackCheck;
        whoToDamage = damageTag;
        timer = timeBetweenHits;
        damage = baseValue + (multiplier * 0f);
        firstHitDone = false;
    }
    public void SetStartupValues(ReactionObject reactionObject, string damageTag)
    {
        originReactionObject = reactionObject;
        whoToDamage = damageTag;
        timer = timeBetweenHits;
        damage = baseValue + (multiplier * 0f);
        firstHitDone = false;
    }

    public void OvertimeDamage()
    {
        if (firstHitOn && !firstHitDone)
        {
            DamageTypeCheck();
            firstHitDone = true;
        }
        if (timer > 0) timer -= Time.deltaTime;
        else
        {
            DamageTypeCheck();
            timer = timeBetweenHits;
        }
    }
    private void DamageTypeCheck()
    {
        if (!hasAoe) DealReactionDamage(targetAttackCheck);
        else
        {
            Transform origin;
            if (targetAttackCheck != null) origin = targetAttackCheck.transform;
            else origin = originReactionObject.transform;
            AoeDamage(origin);
        }
    }
    private void AoeDamage(Transform origin)
    {
        Collider[] collidersInRange = Physics.OverlapSphere(origin.position, aoeRange);
        List<AttackCheck> targetsInRange = new List<AttackCheck>();
        targetsInRange.Clear();
        foreach (Collider collider in collidersInRange)
        {
            AttackCheck target = collider.gameObject.GetComponent<AttackCheck>();
            if (target != null && collider.CompareTag(whoToDamage) && !targetsInRange.Contains(target))
            {
                targetsInRange.Add(target);
                DealReactionDamage(target);
                if (aoeHitsSingleTarget) break;
            }
        }
    }
    private void DealReactionDamage(AttackCheck target)
    {
        if (appliesElement) target.ElementApplication(damageType, elementDuration, true);
        target.DealDamage(damage);
    }
}
