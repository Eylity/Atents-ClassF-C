using System;
using FSM.Player;
using UnityEngine;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    private const int FirstBloodPrefab = 0;
    private const int LastBloodPrefab = 17;
    private Collider m_Collider;
    private Ray m_Ray;

    public Transform m_RayTransform;
    public Action Shake;

    private void Awake() => m_Collider = GetComponent<BoxCollider>();

    private void OnTriggerEnter(Collider other)
    {
        if (Physics.Raycast(m_Ray, out var hit) && other.CompareTag("Dragon"))
        {
            Shake();
            DragonController.instance.hp -= PlayerController.GetPlayerController.PlayerStat.m_Damage;
            Debug.Log($"Hit Weapon\nCurrent Dragon HP : {DragonController.instance.hp}");

            var angle = Mathf.Atan2(hit.normal.x, hit.normal.z) * Mathf.Rad2Deg + 180;

            var effectIdx = (EBloodPrefabsName) Random.Range(FirstBloodPrefab, LastBloodPrefab);
            var instance = ObjPool.Instance.GetObject(effectIdx);
            ObjPool.Instance.ReturnObject(instance, effectIdx, 10f);
            instance.transform.position = hit.point;
            instance.transform.rotation = Quaternion.Euler(0f, angle, 0f);

            m_Collider.enabled = false;
        }
    }

    private void Update()
    {
        m_Ray.origin = m_RayTransform.position;
        m_Ray.direction = m_RayTransform.transform.forward;
    }
}