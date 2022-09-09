using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction : MonoBehaviour
{
    [SerializeField] private ReactionList reactionList;

    public void ActivateReaction(Health target)
    {
        print("Reaction");
        target.HealthAddValue(-50);
        target.appliedElement.element = Element.Elements.NONE;
    }
}
