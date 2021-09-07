using System.Collections;
using UnityEngine;
using Human;

namespace Human
{
    public class Arrow : MonoBehaviour
    {
        private bool m_InEnemy;

        private void OnEnable()
        {
            m_InEnemy = false;
            StartCoroutine(nameof(ArrowAttack));
        }

        private void OnDisable()
        {
            StopCoroutine(nameof(ArrowAttack));
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Dragon")) return;
            m_InEnemy = true;
        }

        private IEnumerator ArrowAttack()
        {
            while (!m_InEnemy) yield return null;
        
        }
    }
}