using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public class Player_Attack : State<PlayerController>
    {
        private readonly int m_Attack;
        private readonly int m_AttackLAnimHash = Animator.StringToHash("Base Layer.Attack.AttackL");
        private readonly int m_AttackRAnimHash = Animator.StringToHash("Base Layer.Attack.AttackR");
        private readonly int m_LastAttackAnimHash = Animator.StringToHash("Base Layer.Attack.LastAttack");

        public Player_Attack() : base("Base Layer.Attack.AttackL") => m_Attack = m_Attack = Animator.StringToHash("Attack");

        public override void OnStateEnter()
        {
            PlayerManager.Instance.TrailSwitch();
            m_Machine.m_Animator.SetTrigger(m_Attack);
            m_Owner.StartCoroutine(WaitForAnim());
        }
        
        private IEnumerator WaitForAnim()
        {
            while (m_Machine.m_Animator.GetCurrentAnimatorStateInfo(0).fullPathHash != m_AttackLAnimHash)
                yield return null;  
            while (m_Machine.m_Animator.GetCurrentAnimatorStateInfo(0).fullPathHash == m_AttackLAnimHash)
                yield return null;            
            while (m_Machine.m_Animator.GetCurrentAnimatorStateInfo(0).fullPathHash == m_AttackRAnimHash)
                yield return null;        
            while (m_Machine.m_Animator.GetCurrentAnimatorStateInfo(0).fullPathHash == m_LastAttackAnimHash)
                yield return null;
            m_Machine.m_Animator.ResetTrigger(m_Attack);
            m_Machine.ChangeState<Player_Idle>();
        }

        public override void ChangePoint()
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_Machine.m_Animator.SetTrigger(m_Attack);
            }
        }
    }
}