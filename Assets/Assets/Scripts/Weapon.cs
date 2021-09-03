using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    public float m_MAxDistance = 1f;
    private EBloodPrefabsName effectIdx;
    public LayerMask m_Dragon;
    private Collider m_Collider;
    private Ray ray;
    private Vector3 direction = Vector3.zero;


    private void Awake()
    {
        ray = new Ray();

        m_Collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        RaycastHit hit;

        if (other.CompareTag("Dragon"))
        {
            if (Physics.Raycast(ray, out hit,m_MAxDistance,m_Dragon))
            {
                float angle = Mathf.Atan2(hit.normal.x, hit.normal.z) * Mathf.Rad2Deg + 180;

                effectIdx = (EBloodPrefabsName)Random.Range(1, 17);
                var instance = ObjPool.ObjectPoolInstance.GetObject(effectIdx);
                ObjPool.ObjectPoolInstance.ReturnObject(instance,effectIdx,5f);
                instance.transform.position = hit.normal;
                instance.transform.rotation = Quaternion.Euler(0f, angle + 90, 0f);
                var settings = instance.GetComponent<BFX_BloodSettings>();
                settings.GroundHeight = hit.point.y;

                var nearestBone = GetNearestBone(hit.transform.root, hit.point);
                if (nearestBone == null) return;

                if (nearestBone != null)
                {
                    var attachBloodInstance = ObjPool.ObjectPoolInstance.GetObject(EBloodPrefabsName.BloodAttach);
                    ObjPool.ObjectPoolInstance.ReturnObject(attachBloodInstance,EBloodPrefabsName.BloodAttach,20f);
                    var bloodT = attachBloodInstance.transform;
                    bloodT.position = hit.point;
                    bloodT.localRotation = Quaternion.identity;
                    bloodT.localScale = Vector3.one * (UnityEngine.Random.Range(0.75f, 1.2f));
                    bloodT.LookAt(hit.point + hit.normal, direction);
                    bloodT.Rotate(90, 0, 0);
                    bloodT.transform.parent = nearestBone;
                }
            }
            Debug.Log("Hit Weapon");
            m_Collider.enabled = false;
        }
    }

    private void LateUpdate()
    {
        ray.origin = transform.position;
        ray.direction = transform.forward;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(ray.origin, ray.direction * 0.1f, Color.green);
    }

    Transform GetNearestBone(Transform characterTransform, Vector3 hitPos)
    {
        var closestPos = 100f;
        Transform closestBone = null;
        var childs = characterTransform.GetComponentsInChildren<Transform>();

        foreach (var child in childs)
        {
            var dist = Vector3.Distance(child.position, hitPos);
            if (dist < closestPos)
            {
                closestPos = dist;
                closestBone = child;
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