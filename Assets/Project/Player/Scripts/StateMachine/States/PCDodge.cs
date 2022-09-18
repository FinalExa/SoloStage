using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCDodge : PCState
{
    private Vector3 direction;
    private string playerTag;
    private float dodgeTimer;
    private float dodgeSpeed;
    private float timeCount;
    public PCDodge(PCStateMachine pcStateMachine, Vector3 receivedDirection) : base(pcStateMachine)
    {
        direction = receivedDirection;
    }

    public override void Start()
    {
        if (!_pcStateMachine.pcController.dodgeInCooldown) DodgeSetup();
        else Transitions();
    }

    public override void FixedUpdate()
    {
        Dodge();
    }

    private void DodgeSetup()
    {
        PCData pcData = _pcStateMachine.pcController.pcReferences.pcData;
        playerTag = _pcStateMachine.gameObject.tag;
        dodgeTimer = pcData.dodgeDuration;
        dodgeSpeed = pcData.dodgeDistance / pcData.dodgeDuration;
        timeCount = 0f;
    }

    private void Dodge()
    {
        if (dodgeTimer > 0)
        {
            dodgeTimer -= Time.fixedDeltaTime;
            timeCount += Time.fixedDeltaTime;
            PCData pcData = _pcStateMachine.pcController.pcReferences.pcData;
            if (timeCount >= pcData.dodgeInvulnerabilityStart && timeCount < pcData.dodgeInvulnerabilityEnd) _pcStateMachine.gameObject.tag = pcData.invulnerabilityTag;
            else if (timeCount >= pcData.dodgeInvulnerabilityEnd) _pcStateMachine.gameObject.tag = playerTag;
            _pcStateMachine.pcController.pcReferences.rb.velocity = direction * dodgeSpeed;
            if (_pcStateMachine.pcController.receivedDamage > 0)
            {
                _pcStateMachine.pcController.DodgeInterruptedFeedbackSet();
                DodgeEnd();
            }
        }
        else DodgeEnd();
    }

    private void DodgeEnd()
    {
        _pcStateMachine.pcController.pcReferences.rb.velocity = Vector3.zero;
        _pcStateMachine.pcController.SetDodgeEndCooldown(_pcStateMachine.pcController.pcReferences.pcData.dodgeEndCooldown);
        Transitions();
    }
    #region Transitions
    private void Transitions()
    {
        Inputs inputs = _pcStateMachine.pcController.pcReferences.inputs;
        GoToIdleState(inputs);
        GoToMovementState(inputs);
        GoToAttackState(inputs);
    }
    #region ToIdleState
    private void GoToIdleState(Inputs inputs)
    {
        if (inputs.MovementInput == Vector3.zero)
        {
            _pcStateMachine.SetState(new PCIdle(_pcStateMachine));
            _pcStateMachine.pcController.pcReferences.rb.velocity = Vector3.zero;
        }
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
    #endregion
}
