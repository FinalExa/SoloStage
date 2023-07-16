using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCStateMachine : StateMachine
{
    [HideInInspector] public PCController pcController;
    [HideInInspector] public string thisStateName;
    [HideInInspector] public PCStateMachineTransitions pcStateMachineTransitions;

    public override void SetState(State state)
    {
        base.SetState(state);
        thisStateName = state.ToString();
        pcController.curState = thisStateName;
    }

    private void Awake()
    {
        pcStateMachineTransitions = new PCStateMachineTransitions(this);
        pcController = this.gameObject.GetComponent<PCController>();
        SetState(new PCIdle(this));
    }

    private void OnCollisionStay(Collision collision)
    {
        _state.Collisions(collision);
    }
}
