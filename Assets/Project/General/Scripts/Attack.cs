using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [HideInInspector] public string whoToDamage;
    [HideInInspector] public Reaction.Element infusedElement;
    [HideInInspector] public bool canApplyElement;

    protected Reaction reaction;
    protected Collider otherCollider;
    protected Health otherHealth;
    protected ReactionAgent otherReactionAgent;

    protected virtual void Awake()
    {
        reaction = FindObjectOfType<Reaction>();
    }
    private void OnTriggerEnter(Collider other)
    {
        GetOtherReferences(other);
        ElementAndReaction();
        Damage();
    }

    protected virtual void GetOtherReferences(Collider other)
    {
        otherCollider = other;
        otherHealth = other.gameObject.GetComponent<Health>();
        otherReactionAgent = other.gameObject.GetComponent<ReactionAgent>();
    }
    protected virtual void ElementAndReaction()
    {
        if (otherHealth != null && otherReactionAgent != null && canApplyElement && infusedElement != Reaction.Element.NONE && otherCollider.CompareTag(whoToDamage) && !otherReactionAgent.InCooldown)
        {
            if (otherReactionAgent.appliedElement == Reaction.Element.NONE) otherReactionAgent.appliedElement = infusedElement;
            else if (otherReactionAgent.appliedElement != infusedElement) reaction.ActivateReaction(otherHealth, otherReactionAgent, infusedElement);
        }
    }
    protected virtual void Damage()
    {
        return;
    }
}
