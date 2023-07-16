using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCMovement
{
    private float currentSpeed;
    private PCController pcController;
    private Vector3 lastDirection;

    public PCMovement(PCController pcControllerRef)
    {
        pcController = pcControllerRef;
    }

    public void SetSpeed(float receivedSpeed)
    {
        currentSpeed = receivedSpeed;
    }

    public void Movement()
    {
        Rigidbody rigidbody = pcController.pcReferences.pcRb;
        Vector3 movementDirection = MovementDirection(pcController.pcReferences.mainCameraRef, pcController.pcReferences.pcInputs);
        if (movementDirection != Vector3.zero)
        {
            lastDirection = movementDirection;
            pcController.pcReferences.pcCombo.LastDirection = movementDirection;
            pcController.lookDirection = movementDirection;
        }
        Vector3 partialVelocity = movementDirection * currentSpeed;
        rigidbody.velocity = new Vector3(partialVelocity.x, rigidbody.velocity.y, partialVelocity.z);
    }

    private Vector3 MovementDirection(Camera camera, Inputs inputs)
    {
        Vector3 forward = new Vector3(camera.transform.forward.x, 0f, camera.transform.forward.z).normalized;
        Vector3 right = new Vector3(camera.transform.right.x, 0f, camera.transform.right.z).normalized;
        return (inputs.MovementInput.x * forward) + (inputs.MovementInput.z * right);
    }
}
