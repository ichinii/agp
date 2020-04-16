using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardPlayerInput : PlayerInput
{
    // Start is called before the first frame update
    void Start()
    {
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
        return previous + Input.GetAxis("Mouse X");
    }

    override public float VerticalLookAngle(float previous)
    {
        return previous + Input.GetAxis("Mouse Y");
    }

    override public float TiltLookAngle(float previous)
    {
        return 0.0f;
    }
}
