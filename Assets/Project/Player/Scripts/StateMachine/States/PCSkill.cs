using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCSkill : PCState
{
    public PCSkill(PCStateMachine pcStateMachine) : base(pcStateMachine)
    {
    }

    public override void Start()
    {
        if (!_pcStateMachine.pcController.skillActive)
        {
            if (_pcStateMachine.pcController.pcReferences.pcNectar.NectarSubtract(_pcStateMachine.pcController.skill.skillNectarCost)) _pcStateMachine.pcController.LaunchSkill();
        }
        Transitions();
    }
    #region Transitions
    private void Transitions()
    {
        Inputs inputs = _pcStateMachine.pcController.pcReferences.inputs;
        GoToIdleState(inputs);
        GoToMovementState(inputs);
        GoToAttackState(inputs);
        GoToDodgeState(inputs);
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
    #region ToAttackState
    private void GoToAttackState(Inputs inputs)
    {
        if (inputs.LeftClickInput && !_pcStateMachine.pcController.pcReferences.pcCombo.comboDelay) _pcStateMachine.SetState(new PCAttack(_pcStateMachine));
    }
    #endregion
    #region ToDodgeState
    private void GoToDodgeState(Inputs inputs)
    {
        if (inputs.DodgeInput && !_pcStateMachine.pcController.lockDodgeSpam) _pcStateMachine.SetState(new PCDodge(_pcStateMachine));
    }
    #endregion
    #endregion
}
