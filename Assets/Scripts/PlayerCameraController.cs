﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public PlayerInput m_input = null;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (m_input != null) {
            transform.LookAt(transform.position + m_input.LookDir());
        }
    }
}
