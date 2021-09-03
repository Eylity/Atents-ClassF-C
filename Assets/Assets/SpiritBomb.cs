using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritBomb : MonoBehaviour
{
    private readonly WaitForSeconds m_Timer = new WaitForSeconds(2.0f);
    private Collider m_Collider;
    private bool m_InEnemy;

    private void Awake()
    {
        m_Collider = GetComponent<SphereCollider>();
    }

    private void OnEnable()
    {
        m_InEnemy = false;
        StartCoroutine(nameof(SpiritAttack));
    }

    private void OnDisable()
    {
        StopCoroutine(nameof(SpiritAttack));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dragon"))
        {
            m_InEnemy = true;
        }
    }

    IEnumerator SpiritAttack()
    {
        yield return m_Timer;
        
        while (!m_InEnemy) yield return null;
        
        Debug.Log("SpiritBomb Hit");
    }
}
