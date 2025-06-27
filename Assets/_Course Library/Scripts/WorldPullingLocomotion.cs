using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class WorldPullingLocomotion : MonoBehaviour
{
    [Header("Grip Inputs")]
    public InputActionProperty leftGripCustom;
    public InputActionProperty rightGripCustom;

    [Header("References")]
    public CharacterController characterController;
    public Transform xrRig;        // Usually XR Origin
    public Transform leftHand;
    public Transform rightHand;

    [Header("Settings")]
    public float pullForce = 2.0f;

    void Update()
    {
        // Pull from left hand
        if (leftGripCustom.action.ReadValue<float>() > 0.5f)
        {
            Vector3 pullDirection = leftHand.forward;
            characterController.Move(pullDirection * pullForce * Time.deltaTime);
        }

        // Pull from right hand
        if (rightGripCustom.action.ReadValue<float>() > 0.5f)
        {
            Vector3 pullDirection = rightHand.forward;
            characterController.Move(pullDirection * pullForce * Time.deltaTime);
        }
    }
}
