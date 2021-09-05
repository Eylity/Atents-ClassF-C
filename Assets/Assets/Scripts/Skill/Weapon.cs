using PlayerScript;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Skill
{
    public class Weapon : MonoBehaviour
    {
        private readonly Vector3 m_Direction = Vector3.zero;
        private const int FirstBloodPrefab = 1;
        private const int LastBloodPrefab = 17;
        private EBloodPrefabsName m_EffectIdx;
        private Collider m_Collider;
        private Ray m_Ray;
    
        public Transform m_RayTransform;

        private void Awake()
        {
            m_Collider = GetComponent<BoxCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!Physics.Raycast(m_Ray, out var hit) || !other.CompareTag("Dragon")) return;
        
            var angle = Mathf.Atan2(hit.normal.x, hit.normal.z) * Mathf.Rad2Deg + 180;

            m_EffectIdx = (EBloodPrefabsName) Random.Range(FirstBloodPrefab, LastBloodPrefab);
            var instance = ObjPool.ObjectPoolInstance.GetObject(m_EffectIdx);
            ObjPool.ObjectPoolInstance.ReturnObject(instance, m_EffectIdx, 5f);
            instance.transform.position = hit.point;
            instance.transform.rotation = Quaternion.Euler(0f, angle + 90, 0f);
            var settings = instance.GetComponent<BFX_BloodSettings>();
            settings.GroundHeight = hit.point.y;

            var nearestBone = GetNearestBone(hit.transform.root, hit.point);
            if (nearestBone == null) return;

            if (nearestBone != null)
            {
                var attachBloodInstance = ObjPool.ObjectPoolInstance.GetObject(EBloodPrefabsName.BloodAttach);
                ObjPool.ObjectPoolInstance.ReturnObject(attachBloodInstance, EBloodPrefabsName.BloodAttach, 20f);
                var bloodT = attachBloodInstance.transform;
                bloodT.position = hit.point;
                bloodT.localRotation = Quaternion.identity;
                bloodT.localScale = Vector3.one * (UnityEngine.Random.Range(0.75f, 1.2f));
                bloodT.LookAt(hit.point + hit.normal, m_Direction);
                bloodT.Rotate(90, 0, 0);
                bloodT.transform.parent = nearestBone;
            }

            m_Collider.enabled = false;
        }

        private void Update()
        {
            m_Ray.origin = m_RayTransform.position;
            m_Ray.direction = m_RayTransform.transform.forward;
        }

        private Transform GetNearestBone(Transform characterTransform, Vector3 hitPos)
        {
            var closestPos = 100f;
            Transform closestBone = null;
            var children = characterTransform.GetComponentsInChildren<Transform>();

            for (var i = 0; i < children.Length; i++)
            {
                var dist = Vector3.Distance(children[i].position, hitPos);
                if (dist < closestPos)
                {
                    closestPos = dist;
                    closestBone = children[i];
                }
            }

            var distRoot = Vector3.Distance(characterTransform.position, hitPos);
            if (distRoot < closestPos)
            {
                closestPos = distRoot;
                closestBone = characterTransform;
            }

            return closestBone;
        }
    }
}