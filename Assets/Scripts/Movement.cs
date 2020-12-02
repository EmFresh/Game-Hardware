using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
public class Movement : MonoBehaviour
{
    public GameObject controllerLeft, controllerRight;
    Quaternion initRot;
    Vector2 LS = Vector2.zero, RS = Vector2.zero;
    float movementScale = 20, angle = 45;

    Controls control;
    void Awake()
    {
        control = new Controls();
        control.Main.Movement.performed += ctx => Move();
        control.Main.Look.performed += ctx => Look();
        control.Main.Jump.performed += ctx => Jump();
        initRot = controllerLeft.transform.rotation;

    }

    void Update()
    {
        transform.position += Vector3.Scale((transform.forward * LS.y + transform.right * LS.x) * movementScale * Time.deltaTime, new Vector3(1, 0, 1));
        transform.rotation = transform.rotation * Quaternion.Euler(0, RS.x * angle *2* Time.deltaTime, 0);
    }

    void OnEnable()
    {
        control.Main.Enable();
    }
    void OnDisable()
    {

        control.Main.Disable();
    }

    void Move()
    {
        LS = Gamepad.current.leftStick.ReadValue();

        //rotate 3D UI Stick
        Quaternion targetLS = Quaternion.Euler(-LS.y * angle, 0, LS.x * angle);
        controllerLeft.transform.rotation = initRot * targetLS;
    }

    void Look()
    {
        RS = Gamepad.current.rightStick.ReadValue();

        //rotate 3D UI Stick
        Quaternion targetRS = Quaternion.Euler(-RS.y * angle, 0, RS.x * angle);
        controllerRight.transform.rotation = initRot * targetRS;

    }
    void Jump()
    {
        if (Gamepad.current[GamepadButton.South].isPressed)
        {
            //TODO: Code Goes here
        }
    }
    void Fire()
    {
        if (Gamepad.current[GamepadButton.West].isPressed)
        {
            //TODO: Code Goes here
        }
    }

}