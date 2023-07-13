using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ReactionOvertimeDamage
{
    /*public bool enabled;
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
    protected AttackReceived targetAttackReceived;
    protected string whoToDamage;
    public void SetStartupValues(AttackCheck attackCheck, string damageTag)
    {
        targetAttackCheck = attackCheck;
        whoToDamage = damageTag;
        timer = timeBetweenHits;
        damage = baseValue + (multiplier * 0f);
        firstHitDone = false;
    }

    public virtual void OvertimeDamage()
    {
        if (firstHitOn && !firstHitDone)
        {
            DealReactionDamage(targetAttackReceived);
            firstHitDone = true;
        }
        if (timer > 0) timer -= Time.deltaTime;
        else
        {
            DealReactionDamage(targetAttackReceived);
            timer = timeBetweenHits;
        }
    }
    protected void DealReactionDamage(AttackReceived target)
    {
        if (appliesElement) target.ElementApplication(damageType, elementDuration, true);
        target.DealDamage(damage);
    }*/
}
