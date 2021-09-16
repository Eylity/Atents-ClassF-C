using DG.Tweening;
using FSM.Player;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class CameraFollow : MonoBehaviour
{
    private const float DURATION = 0.2f;
    private const float STRENGTH = 0.5f;
    private const int VIBRATO = 100;
    [SerializeField] private Vector3 m_RigOffset = new Vector3(0f, 5f, 0f);
    [SerializeField] private float m_MouseRotateSpeed = 2f;
    [SerializeField] private float m_CamMoveSpeed = 5f;
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
            weapon.Shake += () => m_CamPos.DOShakePosition(DURATION, STRENGTH, VIBRATO);
        }
    }
 
    private void Update()
    {
        CamRot();
    }

    private void FixedUpdate()
    {
        FollowCam();
    }

    private void FollowCam()
    {
        var nextCamPos = m_Player.transform.position + m_RigOffset;
        transform.position = Vector3.Lerp(transform.position, nextCamPos,m_CamMoveSpeed * Time.deltaTime);
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