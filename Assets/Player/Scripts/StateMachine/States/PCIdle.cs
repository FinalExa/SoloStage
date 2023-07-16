using UnityEngine;
public class PCIdle : PCState
{
    public PCIdle(PCStateMachine pcStateMachine) : base(pcStateMachine)
    {
    }
    public override void Update()
    {
        RigidbodyStop();
        Transitions();
    }

    private void RigidbodyStop()
    {
        if (_pcStateMachine.pcController.pcReferences.pcRb.velocity != Vector3.zero) _pcStateMachine.pcController.pcReferences.pcRb.velocity = new Vector3(0f, _pcStateMachine.pcController.pcReferences.pcRb.velocity.y, 0f);
    }

    #region Transitions
    private void Transitions()
    {
        Inputs inputs = _pcStateMachine.pcController.pcReferences.pcInputs;
        GoToMovementState(inputs);
        GoToAttackState(inputs);
        //GoToDodgeState(inputs);
    }
    #region ToMovementState
    private void GoToMovementState(Inputs inputs)
    {
        if ((inputs.MovementInput != Vector3.zero)) _pcStateMachine.SetState(new PCMoving(_pcStateMachine));
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
        if (inputs.DodgeInput)
        {
            //_pcStateMachine.SetState(new PCDodge(_pcStateMachine, _pcStateMachine.pcController.lookDirection));
        }
    }
    #endregion
    #endregion
}