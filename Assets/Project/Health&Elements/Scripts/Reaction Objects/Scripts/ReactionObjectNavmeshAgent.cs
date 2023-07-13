using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ReactionObjectNavmeshAgent
{
    /*public bool enabled;
    public float movementSpeed;
    public float trackingRange;
    public bool followsClosestTarget;
    private int layer;
    private ReactionObject reactionObject;

    public void StartUp(ReactionObject _reactionObject, string damageTag)
    {
        layer = LayerMask.GetMask(damageTag);
        reactionObject = _reactionObject;
        reactionObject.navMeshAgent.acceleration = movementSpeed;
        reactionObject.navMeshAgent.speed = movementSpeed;
    }

    public void TrackAndFollow()
    {
        if (followsClosestTarget)
        {
            Collider[] colliders = Physics.OverlapSphere(reactionObject.transform.position, trackingRange, layer);
            bool found = false;
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.GetComponent<AttackCheck>() != null)
                {
                    reactionObject.navMeshAgent.isStopped = false;
                    reactionObject.navMeshAgent.SetDestination(collider.transform.position);
                    found = true;
                    break;
                }
            }
            if (!found) reactionObject.navMeshAgent.isStopped = true;
        }
    }*/
}
