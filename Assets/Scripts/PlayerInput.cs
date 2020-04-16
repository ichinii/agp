using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInput : MonoBehaviour
{
    public float m_maxVerticalLookAngle = 70.0f;
    public float m_lookRotationSpeed = 3.0f;
    public float m_horizontalLookAngle;
    public float m_verticalLookAngle;
    public float m_tiltLookAngle;

    public abstract float RightMove();
    
    public abstract float UpMove();

    public abstract float ForwardMove();

    public abstract float HorizontalLookAngle(float previous);

    public abstract float VerticalLookAngle(float previous);

    public abstract float TiltLookAngle(float previous);

    public virtual void Update()
    {
        m_horizontalLookAngle = HorizontalLookAngle(m_horizontalLookAngle);
        m_verticalLookAngle = VerticalLookAngle(m_verticalLookAngle);
        m_tiltLookAngle = TiltLookAngle(m_tiltLookAngle);
    }

    public Vector3 CameraMoveDir()
    {
        return new Vector3(RightMove(), UpMove(), ForwardMove()).normalized;
    }

    public Vector3 CameraMoveDir(Transform trans)
    {
        var dir = CameraMoveDir();
        return dir.x * trans.right + dir.y * trans.up + dir.z * trans.forward;
    }

    public Vector3 PlayerMoveDir()
    {
        return new Vector3(RightMove(), 0, ForwardMove()).normalized;
    }

    public Vector3 PlayerMoveDir(Transform trans)
    {
        var dir = PlayerMoveDir();
        return dir.x * trans.right + dir.y * trans.up + dir.z * trans.forward;
    }

    public Vector3 EulerLookAngles()
    {
        return new Vector3(m_verticalLookAngle, m_horizontalLookAngle, m_tiltLookAngle);
    }
    public void SetEulerLookAngles(float horizontalLookAngle, float verticalLookAngle, float tiltLookAngle)
    {
        m_horizontalLookAngle = horizontalLookAngle;
        m_verticalLookAngle = verticalLookAngle;
        m_tiltLookAngle = tiltLookAngle;
    }
    public void SetEulerLookAngles(Vector3 angles)
    {
        SetEulerLookAngles(angles.x, angles.y, angles.z);
    }

    public Vector3 LookDir()
    {
        return Quaternion.Euler(EulerLookAngles()) * Vector3.forward;
    }
    public void SetLookDir(Vector3 newLookDir)
    {
        var axis = Vector3.Cross(newLookDir, Vector3.forward).normalized;
        var angle = Mathf.Acos(Vector3.Dot(newLookDir, Vector3.forward));
        var quaternion = Quaternion.AngleAxis(angle, axis);
        SetEulerLookAngles(quaternion.eulerAngles);
    }
}
