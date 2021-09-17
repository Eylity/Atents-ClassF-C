using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public sealed class Player_DIe : State<PlayerController>
    {
        private readonly int m_FlyAttack = Animator.StringToHash("FlyAttack");
        private readonly int m_FullSwing = Animator.StringToHash("FullSwing");
        private readonly int m_Attack = Animator.StringToHash("Attack");
        private readonly int m_IsMove = Animator.StringToHash("IsMove");
        private readonly int m_IsRun = Animator.StringToHash("IsRun");
        private readonly WaitForSeconds m_Timer = new WaitForSeconds(2.2f);
        private readonly int m_Die;

        public Player_DIe() : base("Base Layer.Die") => m_Die = Animator.StringToHash("Die");

        public override void OnStateEnter()
        {
            // 모든 애니메이션 트리거 삭제
            PlayerManager.Instance.TrailSwitch(false);
            m_Machine.m_Animator.SetBool(m_IsMove, false);
            m_Machine.m_Animator.SetBool(m_IsRun, false);
            m_Machine.m_Animator.ResetTrigger(m_Attack);
            m_Machine.m_Animator.ResetTrigger(m_FlyAttack);
            m_Machine.m_Animator.ResetTrigger(m_FullSwing);
            m_Machine.m_Animator.SetTrigger(m_Die);
            m_Owner.StartCoroutine(Die());
        }

        private IEnumerator Die()
        {
            // 사망처리
            m_Owner.m_IsLive = false;
            yield return m_Timer;
            m_Owner.gameObject.SetActive(false);
        }
    }
}