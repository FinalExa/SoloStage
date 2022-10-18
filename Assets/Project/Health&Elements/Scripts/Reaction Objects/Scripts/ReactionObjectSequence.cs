using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class ReactionObjectSequence
{
    [SerializeField] private string sequenceName;
    [SerializeField] private float duration;
    [SerializeField] private bool isObstacle;
    [SerializeField] private ReactionOvertimeDamageObject reactionOvertimeDamageObject;
    [SerializeField] private ReactionObjectNavmeshAgent reactionObjectNavmeshAgent;
    [SerializeField] private ReactionInstantDamageObject reactionInstantDamageObject;
    private float durationTimer;
    private ReactionObject reactionObject;


    public void SetDataFromParent(ReactionObject reactionObj, string _damageTag)
    {
        reactionObject = reactionObj;
    }

    public void StartupReactionObjectOptions()
    {
        if (isObstacle) reactionObject.obstacle.enabled = true;
        else reactionObject.obstacle.enabled = false;
        durationTimer = duration;
        //reactionObject.aoeObject.SetActive(false);
        reactionObject.navMeshAgent.enabled = false;
        StartOvertime();
        StartNavmesh();
    }

    public void StartOvertime()
    {
        if (reactionOvertimeDamageObject.enabled)
        {
            reactionOvertimeDamageObject.SetStartupValues(reactionObject, reactionObject.damageTag);
            if (reactionOvertimeDamageObject.hasAoe)
            {
                reactionObject.aoeObject.SetActive(true);
                reactionObject.aoeObject.transform.localScale *= reactionOvertimeDamageObject.aoeRange;
            }
        }

    }

    public void StartNavmesh()
    {
        if (reactionObjectNavmeshAgent.enabled)
        {
            reactionObject.navMeshAgent.enabled = true;
            reactionObjectNavmeshAgent.StartUp(reactionObject, reactionObject.damageTag);
        }
    }

    public void ExecuteReactionObjectOptions()
    {
        if (reactionOvertimeDamageObject.enabled) reactionOvertimeDamageObject.OvertimeDamage();
        if (reactionObjectNavmeshAgent.enabled) reactionObjectNavmeshAgent.TrackAndFollow();
        if (reactionInstantDamageObject.enabled && reactionInstantDamageObject.GetTargetsInRange(reactionObject.transform.position, reactionObject.damageTag).Count > 0) reactionInstantDamageObject.DealInstantDamageAoeExplosion(reactionObject, reactionObject.damageTag);
    }
    public void ReactionObjectDuration()
    {
        if (durationTimer > 0) durationTimer -= Time.deltaTime;
        else reactionObject.AdvanceSequence();
    }
}
