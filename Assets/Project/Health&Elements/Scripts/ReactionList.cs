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
    public struct ReactionObjectCreation
    {
        public bool enables;
        public ReactionObject reactionObject;
        public int quantity;
    }
    [System.Serializable]
    public struct PossibleReaction
    {
        public string reactionName;
        public ReactionCombination[] reactionCombination;
        public bool isInstantaneous;
        public float reactionDuration;
        public float reactionICD;
        public ReactionInstantDamage reactionDamage;
        public ReactionOvertimeDamage reactionOvertimeDamage;
        public ReactionObjectCreation reactionObject;
    }
    public PossibleReaction[] list;
}
