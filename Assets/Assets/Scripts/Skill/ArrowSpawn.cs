using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{
    private Collider m_Collider;
    private bool InEnemy;

    private void Awake()
    {
        m_Collider = GetComponent<BoxCollider>();
    }

    private void OnEnable()
    {
        InEnemy = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Dragon")) return;
        Debug.Log("Hit");
    }
}