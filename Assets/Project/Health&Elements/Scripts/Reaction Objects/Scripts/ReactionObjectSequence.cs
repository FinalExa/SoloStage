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

    private string damageTag;
    private float durationTimer;
    private ReactionObject reactionObject;


    public void SetDataFromParent(ReactionObject reactionObj, string _damageTag)
    {
        reactionObject = reactionObj;
        damageTag = _damageTag;
    }

    public void StartupReactionObjectOptions()
    {
        if (isObstacle) reactionObject.obstacle.enabled = true;
        else reactionObject.obstacle.enabled = false;
        durationTimer = duration;
        reactionObject.aoeObject.SetActive(false);
        if (reactionOvertimeDamageObject.enabled)
        {
            reactionOvertimeDamageObject.SetStartupValues(reactionObject, damageTag);
            if (reactionOvertimeDamageObject.hasAoe)
            {
                reactionObject.aoeObject.SetActive(true);
                reactionObject.aoeObject.transform.localScale *= reactionOvertimeDamageObject.aoeRange;
            }
        }
    }

    public void ExecuteReactionObjectOptions()
    {
        if (reactionOvertimeDamageObject.enabled) reactionOvertimeDamageObject.OvertimeDamage();
    }
    public void ReactionObjectDuration()
    {
        if (durationTimer > 0) durationTimer -= Time.deltaTime;
        else reactionObject.AdvanceSequence();
    }
}
