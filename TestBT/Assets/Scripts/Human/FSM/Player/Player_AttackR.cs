using UnityEngine;

namespace FSM.Player
{
    public class Player_AttackR : State<PlayerController>
    {
        private readonly int m_Attack;

        public Player_AttackR() : base("Base Layer.Attack.AttackR") => m_Attack = Animator.StringToHash("Attack");

        public override void OnStateEnter()
        {
            m_Machine.m_Animator.SetTrigger(m_Attack);
        }

        public override void ChangePoint()
        {
            if (Input.GetMouseButtonDown(0) && m_Machine.m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.8)
            {
                m_Machine.ChangeState<Player_LastAttack>();
            }
        }

        public override void OnStateUpdate()
        {
            if (m_Machine.IsEnd())
            {
                m_Machine.ChangeState<Player_Idle>();
            }
        }

        public override void OnStateExit()
        {
            m_Machine.m_Animator.ResetTrigger(m_Attack);
        }
    }
}