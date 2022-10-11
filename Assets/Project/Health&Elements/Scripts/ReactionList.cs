using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ReactionList", menuName = "ScriptableObjects/ReactionList", order = 2)]
public class ReactionList : ScriptableObject
{
    [System.Serializable]
    public struct ReactionCombination
    {
        public Reaction.Element placedElement;
        public Reaction.Element triggerElement;
    }
    [System.Serializable]
    public struct ReactionDamage
    {
        public bool enabled;
        public float baseValue;
        public float multiplier;
    }
    [System.Serializable]
    public struct PossibleReaction
    {
        public string reactionName;
        public ReactionCombination[] reactionCombination;
        public ReactionDamage reactionDamage;
        public Reaction.Element reactionDamageType;
        public Reaction.Element reactionLeftElement;
        public float reactionICD;
    }
    public PossibleReaction[] list;
}
