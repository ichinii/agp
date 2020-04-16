using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerInput m_input;
    public Transform m_head;
    public GameObject m_prefab;
    public Transform m_prefabContainer;
    public float m_moveSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (m_input != null && m_head != null) {
            var moveDir = m_input.PlayerMoveDir(m_head.transform).normalized * m_moveSpeed * Time.deltaTime;
            var controller = GetComponent<CharacterController>();
            controller.Move(moveDir);

            m_head.rotation = m_input.QuaternionLookAngle();

            if (m_prefab && m_prefabContainer && m_input.ActionFire()) {
                RaycastHit hit;
                if (Physics.Raycast(m_head.transform.position, m_input.LookDir(), out hit)) {
                    var instance = Instantiate(m_prefab, m_prefabContainer);
                    instance.transform.position = hit.point;
                }
            }
        }
    }
}
