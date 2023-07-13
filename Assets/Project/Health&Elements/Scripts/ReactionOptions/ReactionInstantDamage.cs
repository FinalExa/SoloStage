using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ReactionInstantDamage
{
    /*public bool enabled;
    public float baseValue;
    public float multiplier;
    public Reaction.Element damageType;
    public float elementDuration;
    public bool appliesElement;
    public bool hasAoe;
    public float aoeRange;
    protected List<AttackCheck> GetTargetsInRange(AttackCheck attackCheck, string whoToDamage)
    {
        int layer = LayerMask.GetMask(whoToDamage);
        Collider[] collidersInRange = Physics.OverlapSphere(attackCheck.gameObject.transform.position, aoeRange, layer);
        List<AttackCheck> targetsInRange = new List<AttackCheck>();
        targetsInRange.Clear();
        foreach (Collider collider in collidersInRange)
        {
            AttackCheck target = collider.gameObject.GetComponent<AttackCheck>();
            if (target != null && !targetsInRange.Contains(target)) targetsInRange.Add(target);
        }
        return targetsInRange;
    }

    public void DealInstantDamage(AttackCheck attackCheck, string whoToDamage)
    {
        float damage = baseValue + (multiplier * 0f);
        List<AttackCheck> targetsInRange = GetTargetsInRange(attackCheck, whoToDamage);
        if (!hasAoe) DealReactionDamage(attackCheck, damage);
        else
        {
            foreach (AttackCheck target in targetsInRange)
            {
                if (target.gameObject.CompareTag(whoToDamage)) DealReactionDamage(target, damage);
            }
        }
    }
    protected void DealReactionDamage(AttackCheck attackCheck, float damage)
    {
        if (appliesElement) attackCheck.ElementApplication(damageType, elementDuration, true);
        attackCheck.DealDamage(damage);
    }*/
}
