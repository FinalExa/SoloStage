using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionAgent : MonoBehaviour
{
    public Reaction.Element appliedElement;
    private float elementDuration;
    private float internalCooldown;
    public bool ElementApplied { get; private set; }
    public bool InCooldown { get; private set; }
    private void Update()
    {
        ReactionICD();
        ElementDuration();
    }

    public void StartReactionICD(float ICD)
    {
        internalCooldown = ICD;
        InCooldown = true;
    }
    public void SetElement(float duration, Reaction.Element element)
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
}
