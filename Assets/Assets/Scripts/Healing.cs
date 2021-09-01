using System.Collections;
using FSM.Player;
using UnityEngine;

public class Healing : MonoBehaviour
{
    private readonly WaitForSeconds m_Time = new WaitForSeconds(0.1f);
    private Collider m_Collider;
    private PlayerFsm m_Player;

    private void Start()
    {
        Invoke(nameof(Enable),0.1f);
        Destroy(this.gameObject,5.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        m_Player = other.GetComponent<PlayerFsm>();
        if (m_Player == null)
        {
            return;
        }
        StartCoroutine(nameof(Heal));
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine(nameof(Heal));
        }
    }

    private IEnumerator Heal()
    {
        while (true)
        {
            m_Player.Health += 1;
            yield return m_Time;
        }
    }

    private void Enable()
    {
        m_Collider = GetComponent<BoxCollider>();
        m_Collider.enabled = true;
    }
}
