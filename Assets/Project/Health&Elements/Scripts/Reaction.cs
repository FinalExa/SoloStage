using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction : MonoBehaviour
{
    public enum Element { NONE, FIRE, WATER, EARTH, GRASS, WIND, COLD, GRAVITY, THUNDER, SHADOW, LIGHT }
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
        targetReactionAgent.appliedElement = currentReaction.reactionLeftElement;
        targetReactionAgent.StartReactionICD(currentReaction.reactionICD);
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
                    if (reactionCombination.placedElement == _placedElement && reactionCombination.triggerElement == _triggerElement)
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
