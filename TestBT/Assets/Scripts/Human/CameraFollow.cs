using System;
using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 m_RigOffset;
    private float m_MouseX;
    private float m_MouseY;
    Renderer ObstacleRenderer;


    [SerializeField] private Transform m_Player;

    void CamMove()
    {
        if (Input.GetMouseButton(1))
        {
            m_MouseX += Input.GetAxis("Mouse X");
            m_MouseY += Input.GetAxis("Mouse Y");
            m_MouseY = Mathf.Clamp(m_MouseY, -50f, 0f);
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x + m_MouseY,
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