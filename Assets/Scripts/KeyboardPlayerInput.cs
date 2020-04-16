using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardPlayerInput : PlayerInput
{
    public float m_maxVerticalLookAngle = 80.0f;
    public float m_lookRotationSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    override public float RightMove()
    {
        return Input.GetAxis("Horizontal");
    }
    override public float UpMove()
    {
        return (Input.GetKey(KeyCode.Space) ? 1.0f : 0.0f) - (Input.GetKey(KeyCode.LeftShift) ? 1.0f : 0.0f);
    }

    override public float ForwardMove()
    {
        return Input.GetAxis("Vertical");
    }

    override public float HorizontalLookAngle(float previous)
    {
        return previous + m_lookRotationSpeed * Input.GetAxis("Mouse X");
    }

    override public float VerticalLookAngle(float previous)
    {
        float angle = previous - m_lookRotationSpeed * Input.GetAxis("Mouse Y");
        return Mathf.Clamp(angle, -m_maxVerticalLookAngle, m_maxVerticalLookAngle);
    }

    override public float TiltLookAngle(float previous)
    {
        return 0.0f;
    }

    override public bool ActionFire()
    {
        return Input.GetKey(KeyCode.Mouse0);
    }

    override public bool ActionJump()
    {
        return Input.GetKey(KeyCode.Space);
    }
}
