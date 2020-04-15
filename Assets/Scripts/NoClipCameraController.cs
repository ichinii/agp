using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoClipCameraController : MonoBehaviour
{
    public IPlayerInput m_input = null;
    public float m_moveSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {    
    }

    // Update is called once per frame
    void Update()
    {
        if (m_input != null) {
            transform.LookAt(transform.position + m_input.LookDir());
            var moveDir = m_input.CameraMoveDir(transform);
            transform.position += moveDir * m_moveSpeed;
        }
    }
}
