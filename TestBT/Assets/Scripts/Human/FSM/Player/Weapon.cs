using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace FSM.Player
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private float m_PlayerDamage;
        private const int FirstBloodPrefab = 0;
        private const int LastBloodPrefab = 17;
        private Collider m_Collider;
        private Ray m_Ray;

        public Transform m_RayTransform;

        public delegate void CameraShake();

        public CameraShake Shake;

        private void Awake() => m_Collider = GetComponent<BoxCollider>();

        private void OnTriggerEnter(Collider other)
        {
            if (Physics.Raycast(m_Ray, out var hit) && other.CompareTag("Dragon"))
            {
                Shake();
                DragonController.instance.hp -= m_PlayerDamage;
                Debug.Log($"Hit Weapon\nCurrent Dragon HP : {DragonController.instance.hp}");

                var angle = Mathf.Atan2(hit.normal.x, hit.normal.z) * Mathf.Rad2Deg + 180;

                var effectIdx = (EBloodPrefabsName) Random.Range(FirstBloodPrefab, LastBloodPrefab);
                var instance = ObjPool.ObjectPoolInstance.GetObject(effectIdx);
                ObjPool.ObjectPoolInstance.ReturnObject(instance, effectIdx, 10f);
                instance.transform.position = hit.point;
                instance.transform.rotation = Quaternion.Euler(0f, angle, 0f);

                m_Collider.enabled = false;
            }
        }

        private void Update()
        {
            m_Ray.origin = m_RayTransform.position;
            m_Ray.direction = m_RayTransform.transform.forward;
            Debug.DrawRay(m_Ray.origin, m_Ray.direction);
        }
    }
}