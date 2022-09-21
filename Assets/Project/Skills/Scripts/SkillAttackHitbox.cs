using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAttackHitbox : Attack
{
    [HideInInspector] public Skill originSkill;

    private void Start()
    {
        canApplyElement = true;
        whoToDamage = originSkill.whoToDamage;
    }

    protected override void Damage()
    {
        if (otherHealth != null && (otherCollider.CompareTag(whoToDamage) || otherCollider.CompareTag("Invulnerable")))
        {
            if (otherCollider.CompareTag(whoToDamage)) otherHealth.HealthAddValue(-originSkill.skillDamage);
            originSkill.SkillEnd();
        }
    }
}
