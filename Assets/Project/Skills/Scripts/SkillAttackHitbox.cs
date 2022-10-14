using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAttackHitbox : Attack
{
    [HideInInspector] public Skill originSkill;

    public void InitializeAttack(string damageTag, float elementDuration, Skill skill, Reaction.Element element)
    {
        originSkill = skill;
        InitializeAttack(damageTag, elementDuration);
        infusedElement = element;
        canApplyElement = true;
    }
    protected override void SendAttackData()
    {
        if (otherAttackCheck != null)
        {
            if (otherCollider.CompareTag(whoToDamage))
            {
                otherAttackCheck.CheckReceivedAttackData(whoToDamage, canApplyElement, infusedElement, elementDuration, true, originSkill.skillDamage);
                originSkill.SkillEnd();
            }
            else if (otherCollider.CompareTag("Invulnerable")) originSkill.SkillEnd();
        }
    }
}
