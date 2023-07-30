using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCMoving : PCState
{
    public PCMoving(PCStateMachine pcStateMachine) : base(pcStateMachine)
    {
    }

    public override void Start()
    {
        _pcStateMachine.pcController.pcMovement.SetSpeed(_pcStateMachine.pcController.pcReferences.pcData.defaultMovementSpeed);
    }

    public override void Update()
    {
        _pcStateMachine.pcController.pcMovement.Movement();
        Transitions();
    }

    #region Transitions
    private void Transitions()
    {
        Inputs inputs = _pcStateMachine.pcController.pcReferences.pcInputs;
        GoToAttackState(inputs);
        GoToDodgeState(inputs);
        GoToIdleState(inputs);
    }
    #region ToMovementState
    private void GoToIdleState(Inputs inputs)
    {
        if ((inputs.MovementInput == Vector3.zero)) _pcStateMachine.SetState(new PCIdle(_pcStateMachine));
    }
    #endregion
    #region ToAttackState
    private void GoToAttackState(Inputs inputs)
    {
        if (inputs.LeftClickInput) _pcStateMachine.SetState(new PCAttack(_pcStateMachine));
    }
    #endregion

    #region ToDodgeState
    private void GoToDodgeState(Inputs inputs)
    {
        if (inputs.DodgeInput) _pcStateMachine.SetState(new PCDodge(_pcStateMachine, _pcStateMachine.pcController.lookDirection));
    }
    #endregion
    #endregion
}
