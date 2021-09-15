using System;
using DG.Tweening;
using FSM.Player;
using Sirenix.OdinInspector;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float m_Duration = 0.2f;
    [SerializeField] private float m_Strength = 0.5f;
    [SerializeField] private int m_Vibrato = 100;
    [SerializeField] private Vector3 m_RigOffset;
    [SerializeField] private float m_MouseRotateSpeed = 1f;
    private Transform m_CamPos;
    private Transform m_Player;
    private float m_MouseX;
    private float m_MouseY;

    private void Awake()
    {
        m_Player = FindObjectOfType<PlayerController>().transform;
        m_CamPos = Camera.main.transform;

        var weapons = FindObjectsOfType<Weapon>();
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].Shake += () => m_CamPos.DOShakePosition(m_Duration, m_Strength, m_Vibrato);
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

    void CamMove()
    {
        if (Input.GetMouseButton(1))
        {
            m_MouseX += -Input.GetAxis("Mouse X");
            m_MouseY += Input.GetAxis("Mouse Y");
            m_MouseY = Mathf.Clamp(m_MouseY, -50f, 0f);
            var rotation = transform.rotation;
            rotation = Quaternion.Euler(new Vector3(rotation.x + m_MouseY,rotation.y + m_MouseX, 0) * m_MouseRotateSpeed);
            transform.rotation = rotation;
        }
    }
}