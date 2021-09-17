using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public class Player_Attack : State<PlayerController>
    {
        private WaitUntil m_CurrentStateIsIdle;
        private WaitUntil m_CurrentStateIsAttackL;
        private readonly int m_IdleAnimHash = Animator.StringToHash("Base Layer.Idle");
        private readonly int m_AttackLAnimHash = Animator.StringToHash("Base Layer.Attack.AttackL");
        private readonly int m_Attack = Animator.StringToHash("Attack");

        protected override void ONInitialized()
        {
            // Until 값 초기화
            m_CurrentStateIsAttackL = new WaitUntil(() =>
                m_Machine.m_Animator.GetCurrentAnimatorStateInfo(0).fullPathHash == m_AttackLAnimHash);
            
            m_CurrentStateIsIdle = new WaitUntil(() =>
                m_Machine.m_Animator.GetCurrentAnimatorStateInfo(0).fullPathHash == m_IdleAnimHash);
        }

        public override void OnStateEnter()
        {
            PlayerManager.Instance.TrailSwitch();
            m_Machine.m_Animator.SetTrigger(m_Attack);
            m_Owner.StartCoroutine(WaitForAnim());
        }


        private IEnumerator WaitForAnim()
        {
            // 애니메이션 전환 딜레이 값
            yield return m_CurrentStateIsAttackL;
            
            // 현재 공격중인지 판단
            yield return m_CurrentStateIsIdle;
            
            // 공격이 끝나도 선입력에 의해 공격하는거 방지용
            m_Machine.m_Animator.ResetTrigger(m_Attack);
            m_Machine.ChangeState<Player_Idle>();
        }

        public override void ChangePoint()
        {
            // 연속공격
            if (Input.GetMouseButtonDown(0))
            {
                m_Machine.m_Animator.SetTrigger(m_Attack);
            }
        }
    }
}