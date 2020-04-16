using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerInput m_input;
    public float m_moveSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (m_input != null) {
            //var moveDir = m_input.PlayerMoveDir(transform) * m_moveSpeed;
            //var body = GetComponent<Rigidbody>();
            //body.AddForce(moveDir);
        }
    }
}
