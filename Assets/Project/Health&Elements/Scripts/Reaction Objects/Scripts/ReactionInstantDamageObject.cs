using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ReactionInstantDamageObject : ReactionInstantDamage
{
    public bool dealDamageOnlySomethingIsInsideAoe;
    public bool endAfterDealingDamage;

    public List<AttackCheck> GetTargetsInRange(Vector3 originPosition, string whoToDamage)
    {
        int layer = LayerMask.GetMask(whoToDamage);
        Collider[] collidersInRange = Physics.OverlapSphere(originPosition, aoeRange, layer);
        List<AttackCheck> targetsInRange = new List<AttackCheck>();
        targetsInRange.Clear();
        foreach (Collider collider in collidersInRange)
        {
            AttackCheck target = collider.gameObject.GetComponent<AttackCheck>();
            if (target != null && !targetsInRange.Contains(target)) targetsInRange.Add(target);
        }
        return targetsInRange;
    }
    public void DealInstantDamageAoeExplosion(ReactionObject reactionObject, string whoToDamage)
    {
        float damage = baseValue + (multiplier * 0f);
        List<AttackCheck> targetsInRange = GetTargetsInRange(reactionObject.transform.position, whoToDamage);
        foreach (AttackCheck target in targetsInRange)
        {
            if (target.gameObject.CompareTag(whoToDamage)) DealReactionDamage(target, damage);
        }
        if (endAfterDealingDamage) reactionObject.ReactionObjectEnd();
    }

    public void CheckForAoeExplosion(ReactionObject reactionObject, string damageTag)
    {
        if (hasAoe && dealDamageOnlySomethingIsInsideAoe && GetTargetsInRange(reactionObject.transform.position, damageTag).Count > 0)
        {
            DealInstantDamageAoeExplosion(reactionObject, damageTag);
        }
    }
}
