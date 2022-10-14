using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCheck : MonoBehaviour
{
    private Reaction reaction;
    private Health health;
    private ReactionAgent reactionAgent;

    private void Awake()
    {
        reaction = FindObjectOfType<Reaction>();
        health = this.gameObject.GetComponent<Health>();
        reactionAgent = this.gameObject.GetComponent<ReactionAgent>();
    }

    public void CheckReceivedAttackData(string damageTag, bool appliesElement, Reaction.Element element, bool reactionDamage, float elementDuration, bool dealsDamage, float damage)
    {
        if (appliesElement && reactionAgent != null) ElementApplication(element, elementDuration, damageTag, reactionDamage);
        if (dealsDamage && health != null) DealDamage(damage);
    }

    private void ElementApplication(Reaction.Element infusedElement, float elementDuration, string damageTag, bool reactionDamage)
    {
        if (reactionDamage ||
            reactionAgent.appliedElement == Reaction.Element.NONE ||
            reactionAgent.appliedElement == infusedElement) reactionAgent.SetElement(infusedElement, elementDuration);
        else if (reactionAgent.appliedElement != infusedElement && !reactionDamage) reaction.ActivateReaction(health, reactionAgent, infusedElement, damageTag);
    }

    private void DealDamage(float damage)
    {
        health.HealthAddValue(-damage);
    }
}
