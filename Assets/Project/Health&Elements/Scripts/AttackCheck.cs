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

    public void ElementApplication(Reaction.Element infusedElement, float elementDuration, bool reactionDamage)
    {
        if (reactionAgent != null)
        {
            if (reactionDamage ||
                reactionAgent.appliedElement == Reaction.Element.NONE ||
                reactionAgent.appliedElement == infusedElement) reactionAgent.SetElement(infusedElement, elementDuration);
            else if (reactionAgent.appliedElement != infusedElement && !reactionDamage) reaction.ActivateReaction(health, reactionAgent, infusedElement);
        }
    }

    public void DealDamage(float damage)
    {
        health.HealthAddValue(-damage);
    }
}
