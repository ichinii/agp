using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardInput : MonoBehaviour, IPlayerInput
{
    public float m_maxVerticalLookAngle = 70.0f;
    public float m_lookRotationSpeed = 3.0f;
    [SerializeField] private float m_horizontalLookAngle;
    [SerializeField] private float m_verticalLookAngle;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        m_horizontalLookAngle += Input.GetAxis("Mouse X") * m_lookRotationSpeed;
        m_verticalLookAngle += Input.GetAxis("Mouse Y") * m_lookRotationSpeed;
        m_verticalLookAngle = Mathf.Clamp(m_verticalLookAngle, -m_maxVerticalLookAngle, m_maxVerticalLookAngle);
    }

    public float RightMove()
    {
        return Input.GetAxis("Horizontal");
    }
    public float UpMove()
    {
        return (Input.GetKey("space") ? 1.0f : 0.0f) - (Input.GetKey("shift") ? 1.0f : 0.0f);
    }

    public float ForwardMove()
    {
        return Input.GetAxis("Vertical");
    }

    public float HorizontalLookAngle()
    {
        return m_horizontalLookAngle;
    }

    public float VerticalLookAngle()
    {
        return m_verticalLookAngle;
    }

    public Vector3 CameraMoveDir()
    {
        return new Vector3(RightMove(), UpMove(), ForwardMove()).normalized;
    }

    public Vector3 CameraMoveDir(Transform trans)
    {
        var dir = CameraMoveDir();
        return dir.x * trans.right + dir.y * trans.up + dir.z * trans.right;
    }

    public Vector3 PlayerMoveDir()
    {
        return new Vector3(RightMove(), 0, ForwardMove()).normalized;
    }

    public Vector3 PlayerMoveDir(Transform trans)
    {
        var dir = PlayerMoveDir();
        return dir.x * trans.right + dir.y * trans.up + dir.z * trans.right;
    }

    public Vector3 EulerLookAngles()
    {
        return new Vector3(-VerticalLookAngle(), HorizontalLookAngle(), 0.0f);
    }

    public Vector3 LookDir()
    {
        return Quaternion.Euler(EulerLookAngles()) * new Vector3(0, 0, -1);
    }
}
