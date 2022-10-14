using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionAgent : MonoBehaviour
{
    public Reaction.Element appliedElement { get; private set; }
    private Health health;
    private ReactionList.PossibleReaction currentReaction;
    private float reactionDuration;
    private float elementDuration;
    private float internalCooldown;
    public bool ReactionActive { get; private set; }
    public bool ElementApplied { get; private set; }
    public bool InCooldown { get; private set; }
    private void Awake()
    {
        health = this.gameObject.GetComponent<Health>();
    }
    private void Update()
    {
        ReactionActiveDuration();
        ReactionICD();
        ElementDuration();
    }
    public void StartReaction(ReactionList.PossibleReaction reaction)
    {
        currentReaction = reaction;
        if (currentReaction.isInstantaneous)
        {
            InstantaneousReactionFunctions();
            OnReactionEnd();
        }
        else
        {
            ReactionActiveSetup();
            reactionDuration = currentReaction.reactionDuration;
            ReactionActive = true;
        }
    }
    private void InstantaneousReactionFunctions()
    {
        if (currentReaction.reactionDamage.enabled) currentReaction.reactionDamage.DealInstantDamage(health, this.gameObject.tag);
    }
    private void StartReactionICD(float ICD)
    {
        internalCooldown = ICD;
        InCooldown = true;
    }
    public void OnReactionEnd()
    {
        appliedElement = currentReaction.reactionLeftElement;
        StartReactionICD(currentReaction.reactionICD);
        ReactionActive = false;
    }
    public void SetElement(Reaction.Element element, float duration)
    {
        elementDuration = duration;
        ElementApplied = true;
        appliedElement = element;
    }

    private void ReactionICD()
    {
        if (InCooldown)
        {
            if (internalCooldown > 0) internalCooldown -= Time.deltaTime;
            else InCooldown = false;
        }
    }
    private void ElementDuration()
    {
        if (ElementApplied)
        {
            if (elementDuration > 0) elementDuration -= Time.deltaTime;
            else
            {
                ElementApplied = false;
                appliedElement = Reaction.Element.NONE;
            }
        }
    }

    private void ReactionActiveDuration()
    {
        if (ReactionActive)
        {
            if (reactionDuration > 0)
            {
                reactionDuration -= Time.deltaTime;
                ReactionActiveFunctions();
            }
            else ReactionActive = false;
        }
    }
    private void ReactionActiveSetup()
    {
        if (currentReaction.reactionOvertimeDamage.enabled) currentReaction.reactionOvertimeDamage.SetStartupValues(health, this.gameObject.tag);
    }
    private void ReactionActiveFunctions()
    {
        if (currentReaction.reactionOvertimeDamage.enabled) currentReaction.reactionOvertimeDamage.OvertimeDamage();
    }
}
