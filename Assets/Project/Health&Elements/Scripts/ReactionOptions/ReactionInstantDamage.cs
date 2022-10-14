using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ReactionInstantDamage
{
    public bool enabled;
    public float baseValue;
    public float multiplier;
    public Reaction.Element damageType;
    public float elementDuration;
    public bool appliesElement;
    public bool hasAoe;
    public float aoeRange;

    public void DealInstantDamage(AttackCheck attackCheck, string whoToDamage)
    {
        float damage = baseValue + (multiplier * 0f);
        if (!hasAoe)
        {
            DealReactionDamage(attackCheck, damage);
        }
        else
        {
            Collider[] collidersInRange = Physics.OverlapSphere(attackCheck.gameObject.transform.position, aoeRange);
            List<AttackCheck> targetsInRange = new List<AttackCheck>();
            targetsInRange.Clear();
            foreach (Collider collider in collidersInRange)
            {
                AttackCheck target = collider.gameObject.GetComponent<AttackCheck>();
                if (target != null && collider.CompareTag(whoToDamage) && !targetsInRange.Contains(target))
                {
                    targetsInRange.Add(target);
                    DealReactionDamage(target, damage);
                }
            }
        }
    }
    private void DealReactionDamage(AttackCheck attackCheck, float damage)
    {
        if (appliesElement) attackCheck.ElementApplication(damageType, elementDuration, true);
        attackCheck.DealDamage(damage);
    }
}
