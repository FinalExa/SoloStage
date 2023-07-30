using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCDodge : PCState
{
    private Vector3 direction;
    private string playerTag;
    private float dodgeTimer;
    private float dodgeTimeCount;
    private float dodgeSpeed;
    private bool startDodge;
    private bool wait;
    private PCData pcData;
    public PCDodge(PCStateMachine pcStateMachine, Vector3 receivedDirection) : base(pcStateMachine)
    {
        direction = receivedDirection;
    }

    public override void Start()
    {
        DodgeSetup();
    }

    public override void FixedUpdate()
    {
        if (startDodge) Dodge();
    }

    private void DodgeSetup()
    {
        pcData = _pcStateMachine.pcController.pcReferences.pcData;
        playerTag = _pcStateMachine.gameObject.tag;
        _pcStateMachine.gameObject.tag = pcData.invulnerabilityTag;
        dodgeTimer = pcData.dodgeDuration;
        dodgeTimeCount = 0f;
        dodgeSpeed = pcData.dodgeDistance / pcData.dodgeDuration;
        //_pcStateMachine.pcController.pcReferences.pcRotation.rotationLocked = true;
        if (_pcStateMachine.pcController.pcReferences.uxOnDodge.hasSound) _pcStateMachine.pcController.pcReferences.uxOnDodge.sound.PlayAudio();
        startDodge = true;
    }

    private void Dodge()
    {
        if (dodgeTimer > 0)
        {
            dodgeTimer -= Time.fixedDeltaTime;
            dodgeTimeCount += Time.fixedDeltaTime;
            if (dodgeTimeCount >= pcData.dodgeInvulnerabilityStart &&
                dodgeTimeCount <= pcData.dodgeInvulnerabilityEnd &&
                !_pcStateMachine.gameObject.CompareTag(pcData.invulnerabilityTag))
            {
                _pcStateMachine.gameObject.tag = pcData.invulnerabilityTag;
                if (_pcStateMachine.pcController.pcReferences.uxOnDodge.hasSpriteColorChange) _pcStateMachine.pcController.pcReferences.uxOnDodge.spriteColorChange.StartColorChange();
            }
            else if (_pcStateMachine.gameObject.CompareTag(pcData.invulnerabilityTag))
            {
                _pcStateMachine.gameObject.tag = playerTag;
            }
            _pcStateMachine.pcController.pcReferences.pcRb.velocity = direction * dodgeSpeed;
        }
        else
        {
            startDodge = false;
            DodgeEndSetup();
        }
    }

    private void DodgeEndSetup()
    {
        _pcStateMachine.pcController.pcReferences.pcRb.velocity = Vector3.zero;
        _pcStateMachine.gameObject.tag = playerTag;
        Transitions();
    }
    #region Transitions
    private void Transitions()
    {
        Inputs inputs = _pcStateMachine.pcController.pcReferences.pcInputs;
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
        if (inputs.LeftClickInput) _pcStateMachine.SetState(new PCAttack(_pcStateMachine));
    }
    #endregion
    #endregion
}
