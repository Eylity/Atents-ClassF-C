using System;
using System.Collections;
using FSM.Player;
using UnityEngine;

public class Healing : MonoBehaviour
{
    private readonly WaitForSeconds m_Time = new WaitForSeconds(0.1f);
    private PlayerController m_Player;
    private Collider m_Collider;
    private bool m_InPlayer;

    private void Awake()
    {
        m_Player = FindObjectOfType<PlayerController>();
    }

    private void Start()
    {
        Invoke(nameof(Enable), 0.1f);
        ObjPool.ObjectPoolInstance.ReturnObject(this.gameObject,EPrefabsName.PLAYERSKILL,6.5f);
        StartCoroutine(nameof(Heal));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        m_InPlayer = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        m_InPlayer = false;
    }

    private IEnumerator Heal()
    {
        while (true)
        {
            if (m_InPlayer)
            {
                m_Player.Stamina += 1;
                m_Player.Health += 1;
                yield return m_Time;
            }
            else
            {
                yield return null;
            }
        }
    }

    private void Enable()
    {
        m_Collider = GetComponent<BoxCollider>();
        m_Collider.enabled = true;
    }
}