using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{
    private Collider m_Collider;

    private void Awake()
    {
        m_Collider = GetComponent<BoxCollider>();
    }

    void OnEnable()
    {
        Invoke(nameof(Enable),0.3f);
        ObjPool.ObjectPoolInstance.ReturnObject(this.gameObject,EPrefabsName.FLYATTACK,5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dragon"))
        {
            Debug.Log("Hit");
        }
    }

    private void Enable()
    {
        m_Collider = GetComponent<BoxCollider>();
        m_Collider.enabled = true;
    }
}
