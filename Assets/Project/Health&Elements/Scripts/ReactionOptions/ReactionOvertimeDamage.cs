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
    protected bool firstHitDone;
    protected float timer;
    protected float damage;
    protected AttackCheck targetAttackCheck;
    protected ReactionObject originReactionObject;
    protected string whoToDamage;
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

    public virtual void OvertimeDamage()
    {
        if (firstHitOn && !firstHitDone)
        {
            DealReactionDamage(targetAttackCheck);
            firstHitDone = true;
        }
        if (timer > 0) timer -= Time.deltaTime;
        else
        {
            DealReactionDamage(targetAttackCheck);
            timer = timeBetweenHits;
        }
    }
    protected void DealReactionDamage(AttackCheck target)
    {
        if (appliesElement) target.ElementApplication(damageType, elementDuration, true);
        target.DealDamage(damage);
    }
}
