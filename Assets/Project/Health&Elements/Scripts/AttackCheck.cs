using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCheck : MonoBehaviour
{
    /*private Reaction reaction;
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
            if (reactionDamage)
            {
                if (reactionAgent.appliedElement != infusedElement &&
                    reactionAgent.appliedElement != Reaction.Element.NONE) reaction.ActivateReaction(reactionAgent, infusedElement);
                else reactionAgent.SetElement(infusedElement, elementDuration);
            }
            else
            {
                if (reactionAgent.appliedElement == Reaction.Element.NONE ||
                reactionAgent.appliedElement == infusedElement) reactionAgent.SetElement(infusedElement, elementDuration);
                else if (reactionAgent.appliedElement != infusedElement) reaction.ActivateReaction(reactionAgent, infusedElement);
            }
        }
    }

    public void DealDamage(float damage)
    {
        if (health != null)
        {
            health.HealthAddValue(-damage);
        }
    }*/
}
