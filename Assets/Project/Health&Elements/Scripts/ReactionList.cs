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
    public struct ReactionInstantDamage
    {
        public bool enabled;
        public float baseValue;
        public float multiplier;
        public Reaction.Element damageType;
        public bool hasAoE;
        public float AoERange;
    }
    [System.Serializable]
    public struct ReactionOvertimeDamage
    {
        public bool enabled;
        public float baseValue;
        public float multiplier;
        public bool firstHitOn;
        public bool timeBetweenHits;
    }
    [System.Serializable]
    public struct PossibleReaction
    {
        public string reactionName;
        public ReactionCombination[] reactionCombination;
        public ReactionInstantDamage reactionDamage;
        public Reaction.Element reactionDamageType;
        public Reaction.Element reactionLeftElement;
        public float reactionDuration;
        public float reactionICD;
    }
    public PossibleReaction[] list;
}
