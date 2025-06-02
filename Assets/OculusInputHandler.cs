using UnityEngine;
using UnityEngine.InputSystem;

public class OculusInputHandler : MonoBehaviour
{
    [Header("Input Action Asset")]
    public InputActionAsset inputActions;

    // Izquierda
    private InputAction leftPrimaryButton;
    private InputAction leftSecondaryButton;
    private InputAction leftMenuButton;
    private InputAction leftGripValue;
    private InputAction leftTriggerValue;
    private InputAction leftJoystick;

    public bool leftPrimaryButtonPressed;
    public bool leftSecondaryButtonPressed;
    public bool leftMenuButtonPressed;

    public bool leftGripButtonPressed;
    public bool leftTriggerButtonPressed;

    public float leftGripAmount;
    public float leftTriggerAmount;

    public Vector2 leftJoystickInput;

    // Derecha
    private InputAction rightPrimaryButton;
    private InputAction rightSecondaryButton;
    private InputAction rightMenuButton;
    private InputAction rightGripValue;
    private InputAction rightTriggerValue;
    private InputAction rightJoystick;

    public bool rightPrimaryButtonPressed;
    public bool rightSecondaryButtonPressed;
    public bool rightMenuButtonPressed;

    public bool rightGripButtonPressed;
    public bool rightTriggerButtonPressed;

    public float rightGripAmount;
    public float rightTriggerAmount;

    public Vector2 rightJoystickInput;

    void OnEnable()
    {
        var map = inputActions.FindActionMap("VRHands");

        // Izquierda
        leftPrimaryButton = map.FindAction("LeftPrimaryButton");
        leftSecondaryButton = map.FindAction("LeftSecondaryButton");
        leftMenuButton = map.FindAction("LeftMenuButton");
        leftGripValue = map.FindAction("LeftGrip");
        leftTriggerValue = map.FindAction("LeftTrigger");
        leftJoystick = map.FindAction("LeftJoystick");

        // Derecha
        rightPrimaryButton = map.FindAction("RightPrimaryButton");
        rightSecondaryButton = map.FindAction("RightSecondaryButton");
        rightMenuButton = map.FindAction("RightMenuButton");
        rightGripValue = map.FindAction("RightGrip");
        rightTriggerValue = map.FindAction("RightTrigger");
        rightJoystick = map.FindAction("RightJoystick");

        inputActions.Enable();
        Debug.Log("[Input Handler] Input Actions Enabled");
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    void FixedUpdate()
    {
        // IZQUIERDA
        leftPrimaryButtonPressed = leftPrimaryButton.ReadValue<float>() > 0.5f;
        leftSecondaryButtonPressed = leftSecondaryButton.ReadValue<float>() > 0.5f;
        leftMenuButtonPressed = leftMenuButton.ReadValue<float>() > 0.5f;

        leftGripAmount = leftGripValue.ReadValue<float>();
        leftTriggerAmount = leftTriggerValue.ReadValue<float>();
        leftJoystickInput = leftJoystick.ReadValue<Vector2>();

        leftGripButtonPressed = leftGripAmount > 0.1f;
        leftTriggerButtonPressed = leftTriggerAmount > 0.1f;

        // DERECHA
        rightPrimaryButtonPressed = rightPrimaryButton.ReadValue<float>() > 0.5f;
        rightSecondaryButtonPressed = rightSecondaryButton.ReadValue<float>() > 0.5f;
        rightMenuButtonPressed = rightMenuButton.ReadValue<float>() > 0.5f;

        rightGripAmount = rightGripValue.ReadValue<float>();
        rightTriggerAmount = rightTriggerValue.ReadValue<float>();
        rightJoystickInput = rightJoystick.ReadValue<Vector2>();

        rightGripButtonPressed = rightGripAmount > 0.1f;
        rightTriggerButtonPressed = rightTriggerAmount > 0.1f;

        // DEBUG IZQUIERDA
        Debug.Log($"[Left] Primary: {leftPrimaryButtonPressed}, Secondary: {leftSecondaryButtonPressed}, Menu: {leftMenuButtonPressed}");
        Debug.Log($"[Left] Grip: {leftGripAmount}, Trigger: {leftTriggerAmount}");
        Debug.Log($"[Left] Joystick: {leftJoystickInput}");

        // DEBUG DERECHA
        Debug.Log($"[Right] Primary: {rightPrimaryButtonPressed}, Secondary: {rightSecondaryButtonPressed}, Menu: {rightMenuButtonPressed}");
        Debug.Log($"[Right] Grip: {rightGripAmount}, Trigger: {rightTriggerAmount}");
        Debug.Log($"[Right] Joystick: {rightJoystickInput}");
    }
}