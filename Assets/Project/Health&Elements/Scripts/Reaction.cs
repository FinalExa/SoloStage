using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction : MonoBehaviour
{
    [SerializeField] private ReactionList reactionList;
    [SerializeField] private ReactionText reactionText;
    private ReactionList.PossibleReaction currentReaction;

    public void ActivateReaction(Health targetHealth, ReactionAgent targetReactionAgent, Element _triggerElement)
    {
        Element _placedElement = targetReactionAgent.appliedElement;
        FindReaction(_placedElement, _triggerElement);
        if (currentReaction.reactionDamage.enabled)
        {
            float damage = currentReaction.reactionDamage.baseValue + (currentReaction.reactionDamage.multiplier * 0f);
            targetHealth.HealthAddValue(-damage);
        }
        targetReactionAgent.appliedElement.element = Element.Elements.NONE;
        targetReactionAgent.StartReactionICD(currentReaction.reactionICD);
        print(currentReaction.reactionName);
        ReactionText rt = Instantiate(reactionText, targetHealth.gameObject.transform.position, Quaternion.identity);
        rt.SetReactionText(currentReaction.reactionName);
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
