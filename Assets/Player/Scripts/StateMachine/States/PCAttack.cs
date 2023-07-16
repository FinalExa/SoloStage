using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCAttack : PCState
{
    private Combo pcCombo;
    public PCAttack(PCStateMachine pcStateMachine) : base(pcStateMachine)
    {
        pcCombo = _pcStateMachine.pcController.pcReferences.pcCombo;
    }

    public override void Start()
    {
        RigidbodyStop();
        pcCombo.StartComboHitCheck();
    }

    public override void Update()
    {
        if (pcCombo.GetHitOver()) Transitions();
    }

    private void RigidbodyStop()
    {
        if (_pcStateMachine.pcController.pcReferences.pcRb.velocity != Vector3.zero) _pcStateMachine.pcController.pcReferences.pcRb.velocity = new Vector3(0f, _pcStateMachine.pcController.pcReferences.pcRb.velocity.y, 0f);
    }

    #region Transitions
    private void Transitions()
    {
        Inputs inputs = _pcStateMachine.pcController.pcReferences.pcInputs;
        GoToIdleState(inputs);
        GoToMovementState(inputs);
    }
    #region ToIdleState
    private void GoToIdleState(Inputs inputs)
    {
        if (inputs.MovementInput == Vector3.zero) _pcStateMachine.SetState(new PCIdle(_pcStateMachine));
    }
    #endregion
    #region ToMovementState
    private void GoToMovementState(Inputs inputs)
    {
        if ((inputs.MovementInput != UnityEngine.Vector3.zero)) _pcStateMachine.SetState(new PCMoving(_pcStateMachine));
    }
    #endregion
    #endregion
}
