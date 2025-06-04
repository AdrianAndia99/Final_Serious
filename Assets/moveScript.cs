using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class moveScript : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;

    private InputAction leftJoystick;
    private InputAction rightJoystick;

    void OnEnable()
    {
        var map = inputActions.FindActionMap("VRHands");

        leftJoystick = map.FindAction("LeftJoystick");
        rightJoystick = map.FindAction("RightJoystick");

        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    //void Update()
    //{
    //    Vector2 leftStick = leftJoystick.ReadValue<Vector2>();
    //    Vector2 rightStick = rightJoystick.ReadValue<Vector2>();

    //    // Esto reemplaza a: OVRInput.Get(OVRInput.Button.PrimaryThumbstick)
    //    if (leftStick.magnitude > 0.1f)
    //    {
    //        Debug.Log("Left joystick moved: " + leftStick);
    //    }

    //    if (rightStick.magnitude > 0.1f)
    //    {
    //        Debug.Log("Right joystick moved: " + rightStick);
    //    }
    //}

    void Update()
    {
        var leftDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftDevices);

        if (leftDevices.Count > 0 && leftDevices[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out Vector2 stickValue))
        {
            if (stickValue.magnitude > 0.1f)
            {
                Debug.Log("Left thumbstick: " + stickValue);
            }
        }
    }
}