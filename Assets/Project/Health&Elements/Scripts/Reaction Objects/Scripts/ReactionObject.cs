using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ReactionObject : MonoBehaviour
{
    private string damageTag;
    private int sequenceIndex;
    [SerializeField] private string reactionObjectName;
    [SerializeField] private ReactionObjectSequence[] reactionObjectSequence;
    [HideInInspector] public NavMeshObstacle obstacle;

    private void Awake()
    {
        obstacle = this.gameObject.GetComponent<NavMeshObstacle>();
    }
    public void SetReactionObjectParameters(string _damageTag)
    {
        damageTag = _damageTag;
        foreach (ReactionObjectSequence phase in reactionObjectSequence)
        {
            phase.SetDataFromParent(this, damageTag);
        }
    }

    private void Start()
    {
        sequenceIndex = -1;
        AdvanceSequence();
    }
    private void Update()
    {
        reactionObjectSequence[sequenceIndex].ExecuteReactionObjectOptions();
        reactionObjectSequence[sequenceIndex].ReactionObjectDuration();
    }

    public void AdvanceSequence()
    {
        if (sequenceIndex + 1 < reactionObjectSequence.Length)
        {
            sequenceIndex++;
            reactionObjectSequence[sequenceIndex].StartupReactionObjectOptions();
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
