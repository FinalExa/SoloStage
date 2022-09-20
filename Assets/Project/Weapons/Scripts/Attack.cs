using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    protected Reaction reaction;
    [HideInInspector] public Weapon thisWeapon;
    [HideInInspector] public string whoToDamage;
    [HideInInspector] public Element infusedElement;
    [HideInInspector] public bool canApplyElement;
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
        if (otherHealth != null && otherReactionAgent != null && canApplyElement && otherCollider.CompareTag(whoToDamage) && !otherReactionAgent.InCooldown)
        {
            if (otherReactionAgent.appliedElement.element == Element.Elements.NONE) otherReactionAgent.appliedElement.element = infusedElement.element;
            else if (otherReactionAgent.appliedElement.element != infusedElement.element)
            {
                reaction.ActivateReaction(otherHealth, otherReactionAgent, infusedElement);
            }
        }
    }
    protected virtual void Damage()
    {
        if (otherHealth != null && (otherCollider.CompareTag(whoToDamage) || otherCollider.CompareTag("Invulnerable")) && !thisWeapon.hitTargets.Contains(otherHealth))
        {
            if (otherCollider.CompareTag(whoToDamage)) otherHealth.HealthAddValue(-thisWeapon.currentDamage);
            thisWeapon.hitTargets.Add(otherHealth);
        }
    }
}
