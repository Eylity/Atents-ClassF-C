using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Collider m_Collider;

    private void Awake()
    {
        m_Collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dragon"))
        {
            Debug.Log("Hit Weapon");
            m_Collider.enabled = false;
        }
    }
}
