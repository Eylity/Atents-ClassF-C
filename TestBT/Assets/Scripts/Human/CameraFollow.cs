using DG.Tweening;
using FSM.Player;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float m_MouseRotateSpeed;
    [SerializeField] private float m_Duration = 0.2f;
    [SerializeField] private float m_Strength = 0.5f;
    [SerializeField] private int m_Vibrato = 100;
    [SerializeField] private Vector3 m_RigOffset;
    private Transform m_CamPos;
    private Transform m_Player;
    private float m_MouseX;
    private float m_MouseY;

    private void Awake()
    {
        Debug.Assert(Camera.main != null, "Camera.main Is null");
        m_CamPos = Camera.main.transform;
        m_Player = FindObjectOfType<PlayerController>().transform;

        var weapons = FindObjectsOfType<Weapon>();
        foreach (var weapon in weapons)
        {
            weapon.Shake += () => m_CamPos.DOShakePosition(m_Duration, m_Strength, m_Vibrato);
        }
    }
 
    private void Update()
    {
        CamRot();
    }

    private void LateUpdate()
    {
        transform.position = m_Player.transform.position + m_RigOffset;
    }

    private void CamRot()
    {
        if (Input.GetMouseButton(1))
        {
            m_MouseX += Input.GetAxis("Mouse X");
            m_MouseY += -Input.GetAxis("Mouse Y");
            m_MouseY = Mathf.Clamp(m_MouseY, -15f, 0f);
            var rotation = transform.rotation;
            rotation = Quaternion.Euler(new Vector3(rotation.x + m_MouseY,rotation.y + m_MouseX, 0) * m_MouseRotateSpeed);
            transform.rotation = rotation;
        }
    }
}