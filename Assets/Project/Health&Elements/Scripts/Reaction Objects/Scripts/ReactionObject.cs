using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ReactionObject : MonoBehaviour
{
    private int sequenceIndex;
    [SerializeField] private string reactionObjectName;
    public GameObject aoeObject;
    [SerializeField] private ReactionObjectSequence[] reactionObjectSequence;
    [HideInInspector] public NavMeshObstacle obstacle;
    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public string damageTag;

    private void Awake()
    {
        obstacle = this.gameObject.GetComponent<NavMeshObstacle>();
        navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
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
        else ReactionObjectEnd();
    }

    public void ReactionObjectEnd()
    {
        GameObject.Destroy(this.gameObject);
    }
}
