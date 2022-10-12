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
    public bool hasAoe;
    public float aoeRange;

    public void DealInstantDamage(Health targetHealth, string whoToDamage)
    {
        float damage = baseValue + (multiplier * 0f);
        if (!hasAoe) targetHealth.HealthAddValue(-damage);
        else
        {
            Collider[] collidersInRange = Physics.OverlapSphere(targetHealth.gameObject.transform.position, aoeRange);
            List<Health> targetsInRange = new List<Health>();
            targetsInRange.Clear();
            foreach (Collider collider in collidersInRange)
            {
                Health target = collider.gameObject.GetComponent<Health>();
                if (target != null && collider.CompareTag(whoToDamage) && !targetsInRange.Contains(target))
                {
                    targetsInRange.Add(target);
                    target.HealthAddValue(-damage);
                    Debug.Log("yahoo");
                }
            }
        }
    }
}
