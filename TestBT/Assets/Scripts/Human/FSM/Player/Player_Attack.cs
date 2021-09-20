using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public class Player_Attack : State<PlayerController>
    {
        private WaitUntil m_WaitForCurrentAnimIdle;
        private WaitUntil m_WaitForCurrentAnimAttackL;
        private readonly int m_IdleAnimHash = Animator.StringToHash("Base Layer.Idle");
        private readonly int m_AttackLAnimHash = Animator.StringToHash("Base Layer.Attack.AttackL");
        private readonly int m_Attack = Animator.StringToHash("Attack");

        protected override void ONInitialized()
        {
            // Until 값 초기화
            m_WaitForCurrentAnimAttackL = new WaitUntil(() =>
                machine.animator.GetCurrentAnimatorStateInfo(0).fullPathHash == m_AttackLAnimHash);
            
            m_WaitForCurrentAnimIdle = new WaitUntil(() =>
                machine.animator.GetCurrentAnimatorStateInfo(0).fullPathHash == m_IdleAnimHash);
        }

        public override void OnStateEnter()
        {
            PlayerManager.Instance.TrailSwitch();
            machine.animator.SetTrigger(m_Attack);
            owner.StartCoroutine(WaitForAnim());
        }


        private IEnumerator WaitForAnim()
        {
            // 애니메이션 전환 딜레이 값
            yield return m_WaitForCurrentAnimAttackL;
            
            // 현재 공격중인지 판단
            yield return m_WaitForCurrentAnimIdle;
            
            // 공격이 끝나도 선입력에 의해 공격하는거 방지용
            machine.animator.ResetTrigger(m_Attack);
            machine.ChangeState<Player_Idle>();
        }

        public override void ChangePoint()
        {
            // 연속공격
            if (Input.GetMouseButtonDown(0))
            {
                machine.animator.SetTrigger(m_Attack);
            }
        }
    }
}