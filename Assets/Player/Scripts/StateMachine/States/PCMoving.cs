using UnityEngine;
public class PCMoving : PCState
{
    private Vector2 lastDirection;
    public PCMoving(PCStateMachine pcStateMachine) : base(pcStateMachine)
    {
    }
    public override void Update()
    {
        Movement();
        Transitions();
        UpdateSpeedValue();
    }

    #region Movement
    private void UpdateSpeedValue()
    {
        PCData pcData = _pcStateMachine.pcController.pcReferences.pcData;
        PCController pcController = _pcStateMachine.pcController;
        pcController.actualSpeed = pcData.defaultMovementSpeed;
    }
    private void Movement()
    {
        Rigidbody2D rigidbody = _pcStateMachine.pcController.pcReferences.rb;
        PCController pcController = _pcStateMachine.pcController;
        Vector2 movementWithDirection = MovementCalculateDirection();
        if (movementWithDirection != Vector2.zero) lastDirection = movementWithDirection;
        rigidbody.velocity = movementWithDirection * pcController.actualSpeed;
    }

    private Vector3 MovementCalculateDirection()
    {
        Inputs inputs = _pcStateMachine.pcController.pcReferences.inputs;
        Vector2 movementDirection = new Vector2(inputs.MovementInput.z, inputs.MovementInput.x);
        movementDirection = movementDirection.normalized;
        return movementDirection;
    }
    #endregion

    #region Transitions
    private void Transitions()
    {
        Inputs inputs = _pcStateMachine.pcController.pcReferences.inputs;
        GoToIdleState(inputs);
        //GoToAttackState(inputs);
        //GoToDodgeState(inputs);
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
    #region ToAttackState
    private void GoToAttackState(Inputs inputs)
    {
        if (inputs.LeftClickInput && !_pcStateMachine.pcController.pcReferences.pcCombo.delayAfterHit)
        {
            _pcStateMachine.SetState(new PCAttack(_pcStateMachine));
            _pcStateMachine.pcController.pcReferences.rb.velocity = Vector3.zero;
        }
    }
    #endregion
    #region ToDodgeState
    private void GoToDodgeState(Inputs inputs)
    {
        if (inputs.DodgeInput)
        {
            _pcStateMachine.SetState(new PCDodge(_pcStateMachine, lastDirection));
        }
    }
    #endregion
    #endregion
}
