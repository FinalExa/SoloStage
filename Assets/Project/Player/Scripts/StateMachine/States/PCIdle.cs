public class PCIdle : PCState
{
    public PCIdle(PCStateMachine pcStateMachine) : base(pcStateMachine)
    {
    }
    public override void Update()
    {
        Transitions();
    }

    #region Transitions
    private void Transitions()
    {
        Inputs inputs = _pcStateMachine.pcController.pcReferences.inputs;
        GoToMovementState(inputs);
        GoToAttackState(inputs);
        GoToDodgeState(inputs);
        GoToSkillState(inputs);
    }
    #region ToMovementState
    private void GoToMovementState(Inputs inputs)
    {
        if ((inputs.MovementInput != UnityEngine.Vector3.zero)) _pcStateMachine.SetState(new PCMoving(_pcStateMachine));
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
        if (inputs.DodgeInput) _pcStateMachine.SetState(new PCDodge(_pcStateMachine));
    }
    #endregion
    #region ToSkillState
    private void GoToSkillState(Inputs inputs)
    {
        if (inputs.RightClickInput) _pcStateMachine.SetState(new PCSkill(_pcStateMachine));
    }
    #endregion
    #endregion
}