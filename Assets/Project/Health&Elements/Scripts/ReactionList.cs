using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ReactionList", menuName = "ScriptableObjects/ReactionList", order = 2)]
public class ReactionList : ScriptableObject
{
    public struct PossibleReaction
    {
        public string reactionName;
        public Element placedElement;
        public Element triggerElement;
    }
    public PossibleReaction[] list;
}
