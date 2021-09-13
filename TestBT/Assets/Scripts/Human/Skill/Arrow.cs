using System;
using System.Collections;
using FSM.Player;
using UnityEngine;

namespace Skill
{
    public class Arrow : MonoBehaviour
    {
        private Collider m_Box;

        private void Awake()
        {
            m_Box = GetComponent<BoxCollider>();
        }

        private void OnEnable()
        {
            m_Box.enabled = true;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Dragon"))
            {
                DragonController.instance.hp -= 5;
                m_Box.enabled = false;
                Debug.Log($"Dragon Arrow Hit\n{DragonController.instance.hp}");
            }
        }
    }
}