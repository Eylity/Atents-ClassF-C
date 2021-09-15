using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public class Player_Attack : State<PlayerController>
    {
        private int m_Attack;

        protected override void ONInitialized() => m_Attack = Animator.StringToHash("Attack");
        public override void OnStateEnter()
        {
            PlayerManager.Instance.TrailSwitch();
            m_Machine.m_Animator.SetTrigger(m_Attack);
            m_Owner.StartCoroutine(WaitForAnim());
        }
        private IEnumerator WaitForAnim()
        {
            while (!m_Machine.m_Animator.GetCurrentAnimatorStateInfo(0).IsName("AttackL")) yield return null;
            while (m_Machine.m_Animator.GetCurrentAnimatorStateInfo(0).IsName("AttackL")) yield return null;
            while (m_Machine.m_Animator.GetCurrentAnimatorStateInfo(0).IsName("AttackR")) yield return null;
            while (m_Machine.m_Animator.GetCurrentAnimatorStateInfo(0).IsName("LastAttack")) yield return null;
            m_Machine.m_Animator.ResetTrigger(m_Attack);
            m_Machine.ChangeState<Player_Idle>();
        }
        
        public override void OnStateUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_Machine.m_Animator.SetTrigger(m_Attack);
            }
        }
    }
}