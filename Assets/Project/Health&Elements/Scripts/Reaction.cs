using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction : MonoBehaviour
{
    [SerializeField] private ReactionList reactionList;
    private ReactionList.PossibleReaction currentReaction;

    public void ActivateReaction(Health targetHealth, ReactionAgent targetReactionAgent, Element _triggerElement)
    {
        Element _placedElement = targetReactionAgent.appliedElement;
        FindReaction(_placedElement, _triggerElement);
        print(currentReaction.reactionName);
        if (currentReaction.reactionDamage.enabled)
        {
            float damage = currentReaction.reactionDamage.baseValue + (currentReaction.reactionDamage.multiplier * 0f);
            targetHealth.HealthAddValue(-damage);
        }
        targetReactionAgent.appliedElement.element = Element.Elements.NONE;
        targetReactionAgent.StartReactionICD(currentReaction.reactionICD);
    }

    private void FindReaction(Element _placedElement, Element _triggerElement)
    {
        foreach (ReactionList.PossibleReaction reaction in reactionList.list)
        {
            bool found = false;
            if (reaction.reactionCombination.Length > 0)
            {
                foreach (ReactionList.ReactionCombination reactionCombination in reaction.reactionCombination)
                {
                    if (reactionCombination.placedElement.element == _placedElement.element && reactionCombination.triggerElement.element == _triggerElement.element)
                    {
                        currentReaction = reaction;
                        found = true;
                        break;
                    }
                }
            }
            if (found) break;
        }
    }
}
