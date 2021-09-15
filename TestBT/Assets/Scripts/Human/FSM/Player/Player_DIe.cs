using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public sealed class Player_DIe : State<PlayerController>
    {
        private static readonly int FlyAttack = Animator.StringToHash("FlyAttack");
        private static readonly int FullSwing = Animator.StringToHash("FullSwing");
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int IsMove = Animator.StringToHash("IsMove");
        private static readonly int IsRun = Animator.StringToHash("IsRun");
        private readonly WaitForSeconds m_Timer = new WaitForSeconds(2.2f);
        private readonly int m_Die;

        public Player_DIe() : base("Base Layer.Die") => m_Die = Animator.StringToHash("Die");

        public override void OnStateEnter()
        {
            PlayerManager.Instance.TrailSwitch(false);
            m_Machine.m_Animator.SetBool(IsMove, false);
            m_Machine.m_Animator.SetBool(IsRun, false);
            m_Machine.m_Animator.ResetTrigger(Attack);
            m_Machine.m_Animator.ResetTrigger(FlyAttack);
            m_Machine.m_Animator.ResetTrigger(FullSwing);
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