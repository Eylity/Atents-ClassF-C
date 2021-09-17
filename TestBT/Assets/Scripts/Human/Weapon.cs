using System;
using FSM.Player;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Collider m_Collider;
    private Ray m_Ray;

    public Transform m_RayTransform;
    
    // 무기 타격시 카메라 흔들리는 효과를 내기위한 Action함수
    public Action Shake;

    private void Awake() => m_Collider = GetComponent<BoxCollider>();

    private void OnTriggerEnter(Collider other)
    {
        if (Physics.Raycast(m_Ray, out var hit) && other.CompareTag("Dragon"))
        {
            Shake();
            DragonController.instance.hp -= PlayerController.Instance.PlayerStat.m_Damage;

            // 혈픈효과의 회전값 적용
            // 레이가 맞은 위치의 x 와 z 각도를 구한다. 
            // Rad2Deg 는 라디안 값을 각도로 변환
            var angle = Mathf.Atan2(hit.normal.x, hit.normal.z) * Mathf.Rad2Deg;

            PlayerManager.Instance.GetBlood(hit.point,10f,Quaternion.Euler(0f, angle, 0f));
            m_Collider.enabled = false;
        }
    }

    private void Update()
    {
        m_Ray.origin = m_RayTransform.position;
        m_Ray.direction = m_RayTransform.transform.forward;
    }
}