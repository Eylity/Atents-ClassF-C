using System.Collections;
using FSM.Player;
using UnityEngine;

namespace Skill
{
    public class Healing : MonoBehaviour
    {
        // 플레이어 회복 주기
        private readonly WaitForSeconds m_HealTime = new WaitForSeconds(0.1f);
        private bool m_InPlayer;

        private void OnEnable()
        {
            StartCoroutine(nameof(Heal));
        }

        private void OnDisable()
        {
            StopCoroutine(nameof(Heal));
        }

        // 소환시 플레이어 밑에 바로 생성되어 활성화
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
                    PlayerController.Instance.PlayerStat.Stamina += 1;
                    PlayerController.Instance.PlayerStat.Health += 1;
                    // 초당 10씩 회복
                    yield return m_HealTime;
                }
                else
                {
                    yield return null;
                }
            }
        }
    }
}