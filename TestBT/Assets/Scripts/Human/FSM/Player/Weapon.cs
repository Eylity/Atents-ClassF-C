using UnityEngine;
using Random = UnityEngine.Random;

namespace Skill
{
    public class Weapon : MonoBehaviour
    {
        private readonly Vector3 m_Direction = Vector3.zero;
        private const int FirstBloodPrefab = 1;
        private const int LastBloodPrefab = 17;
        private Collider m_Collider;
        private Ray m_Ray;
    
        [SerializeField] private float m_PlayerDamage = 20f;
        public Transform m_RayTransform;

        private void Awake()
        {
            m_Collider = GetComponent<BoxCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!Physics.Raycast(m_Ray, out var hit) || !other.CompareTag("Dragon")) return;

            Debug.Log("Hit Weapon");
            var angle = Mathf.Atan2(hit.normal.x, hit.normal.z) * Mathf.Rad2Deg + 180;

            var effectIdx = (EBloodPrefabsName) Random.Range(FirstBloodPrefab, LastBloodPrefab);
            var instance = ObjPool.ObjectPoolInstance.GetObject(effectIdx);
            ObjPool.ObjectPoolInstance.ReturnObject(instance, effectIdx, 10f);
            instance.transform.position = hit.point;
            instance.transform.rotation = Quaternion.Euler(0f, angle, 0f);

            m_Collider.enabled = false;
        }

        private void Update()
        {
            m_Ray.origin = m_RayTransform.position;
            m_Ray.direction = m_RayTransform.transform.forward;
            Debug.DrawRay(m_Ray.origin,m_Ray.direction);
        }
    }
}