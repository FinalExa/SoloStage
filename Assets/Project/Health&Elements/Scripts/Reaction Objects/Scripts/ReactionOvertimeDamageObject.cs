using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ReactionOvertimeDamageObject : ReactionOvertimeDamage
{
    public bool hasAoe;
    public bool aoeHitsSingleTarget;
    public float aoeRange;

    public override void OvertimeDamage()
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
}
