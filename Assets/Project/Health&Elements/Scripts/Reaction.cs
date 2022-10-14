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
        if (FindReaction(_placedElement, _triggerElement))
        {
            targetReactionAgent.StartReaction(currentReaction);
            ReactionText rt = Instantiate(reactionText, targetHealth.gameObject.transform.position, Quaternion.identity);
            rt.SetReactionText(currentReaction.reactionName);
        }
    }

    private bool FindReaction(Element _placedElement, Element _triggerElement)
    {
        bool found = false;
        foreach (ReactionList.PossibleReaction reaction in reactionList.list)
        {
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
        return found;
    }
}
