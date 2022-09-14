using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorTree;

public class TaskIsCloseToPlayer : Node
{
    private GameObject thisGameObject;
    private NavMeshAgent thisAgent;
    private GameObject target;
    private float distanceFromPlayer;
    private EnemyController enemyController;

    public TaskIsCloseToPlayer(EnemyController _enemyController, GameObject _thisGameObject, NavMeshAgent _thisAgent, GameObject _target, float _distanceFromPlayer)
    {
        enemyController = _enemyController;
        thisGameObject = _thisGameObject;
        thisAgent = _thisAgent;
        target = _target;
        distanceFromPlayer = _distanceFromPlayer;
    }

    public override NodeState Evaluate()
    {
        float distance = Vector3.Distance(thisGameObject.transform.position, target.transform.position);
        if (distance <= distanceFromPlayer)
        {
            thisAgent.isStopped = true;
            state = NodeState.SUCCESS;
            return state;
        }
        //enemyController.ResetAttackTimer();
        state = NodeState.FAILURE;
        return state;
    }
}
