using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorTree;

public class TaskMoveToPlayer : Node
{
    private NavMeshAgent thisAgent;
    private GameObject target;

    public TaskMoveToPlayer(NavMeshAgent _thisAgent, GameObject _target)
    {
        thisAgent = _thisAgent;
        target = _target;
    }

    public override NodeState Evaluate()
    {
        if (thisAgent.isStopped) thisAgent.isStopped = false;
        thisAgent.SetDestination(target.transform.position);
        state = NodeState.RUNNING;
        return state;
    }
}