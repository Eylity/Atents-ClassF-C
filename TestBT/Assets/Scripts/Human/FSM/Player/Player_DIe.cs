using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public sealed class Player_DIe : State<PlayerController>
    {
        private readonly int m_Die;
        private readonly WaitForSeconds m_Timer = new WaitForSeconds(2.2f);
        private static readonly int IsMove = Animator.StringToHash("IsMove");
        private static readonly int IsRun = Animator.StringToHash("IsRun");

        public Player_DIe() : base("Base Layer.Die") => m_Die = Animator.StringToHash("Die");

        public override void OnStateEnter()
        {
            m_Machine.m_Animator.SetBool(IsMove, false);
            m_Machine.m_Animator.SetBool(IsRun, false);
            m_Machine.m_Animator.SetTrigger(m_Die);
            m_Owner.m_IsLive = false;
            m_Owner.StartCoroutine(Die());
        }

        private IEnumerator Die()
        {
            yield return m_Timer;
            m_Owner.gameObject.SetActive(false);
        }
    }
}