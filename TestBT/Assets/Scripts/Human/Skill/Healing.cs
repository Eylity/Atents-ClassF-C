using System.Collections;
using FSM.Player;
using UnityEngine;

namespace Skill
{
    public class Healing : MonoBehaviour
    {
        private readonly WaitForSeconds m_Time = new WaitForSeconds(0.1f);
        private bool m_InPlayer;

        private void OnEnable()
        {
            StartCoroutine(nameof(Heal));
        }

        private void OnDisable()
        {
            StopCoroutine(nameof(Heal));
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                m_InPlayer = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                m_InPlayer = false;
            }
        }

        private IEnumerator Heal()
        {
            while (true)
            {
                if (m_InPlayer)
                {
                    PlayerController.GetPlayerController.PlayerStat.Stamina += 1;
                    PlayerController.GetPlayerController.PlayerStat.Health += 1;
                    yield return m_Time;
                }
                else
                {
                    yield return null;
                }
            }
        }
    }
}