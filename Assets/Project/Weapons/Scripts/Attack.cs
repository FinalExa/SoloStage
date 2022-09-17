using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Reaction reaction;
    public Weapon thisWeapon;
    public string whoToDamage;
    public Element infusedElement;
    public bool canApplyElement;
    private void Awake()
    {
        reaction = FindObjectOfType<Reaction>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Health otherHealth = other.gameObject.GetComponent<Health>();
        ReactionAgent otherReactionAgent = other.gameObject.GetComponent<ReactionAgent>();
        if (otherHealth != null && otherReactionAgent != null && canApplyElement && other.CompareTag(whoToDamage) && !otherReactionAgent.InCooldown)
        {
            if (otherReactionAgent.appliedElement.element == Element.Elements.NONE) otherReactionAgent.appliedElement.element = infusedElement.element;
            else if (otherReactionAgent.appliedElement.element != infusedElement.element)
            {
                reaction.ActivateReaction(otherHealth, otherReactionAgent, infusedElement);
            }
        }
        if (otherHealth != null && other.CompareTag(whoToDamage) && !thisWeapon.hitTargets.Contains(otherHealth))
        {
            otherHealth.HealthAddValue(-thisWeapon.currentDamage);
            thisWeapon.hitTargets.Add(otherHealth);
        }
    }
}
