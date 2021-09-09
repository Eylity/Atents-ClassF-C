using System;
using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 m_RigOffset;
    private float m_MouseX;
    
    [SerializeField] private Transform m_Player;

    void CamMove()
    {
        if (Input.GetMouseButton(1))
        {
            m_MouseX += Input.GetAxis("Mouse X");

            transform.rotation = Quaternion.Euler(new Vector3(0f,
                transform.rotation.y + m_MouseX, 0));
        }
    }

    private void Update()
    {
        CamMove();
    }

    private void LateUpdate()
    {
        transform.position = m_Player.transform.position + m_RigOffset;
    }
}