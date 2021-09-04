using System.Collections;
using System.Collections.Generic;
using FSM.Player;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject m_Target;
    private Vector3 m_CameraPosition;
    private Vector3 m_Eye;
    private float m_MoveX;

    void Start()
    {
        m_CameraPosition = new Vector3(0, 3f, -6f);
    }

    void LateUpdate()
    {
        m_Eye = transform.rotation * (m_Target.transform.position + m_CameraPosition);
        if (Input.GetMouseButton(1))
        {
            m_MoveX += Input.GetAxis("Mouse X");
            transform.rotation = Quaternion.Euler(0f, m_MoveX, 0);
        }

        transform.position = m_Eye - transform.rotation * Vector3.zero;
    }
}