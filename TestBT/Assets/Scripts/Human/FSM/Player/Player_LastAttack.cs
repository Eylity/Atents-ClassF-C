using UnityEngine;

namespace FSM.Player
{
    public class Player_LastAttack : State<PlayerController>
    {
        private readonly int m_Attack;

        public Player_LastAttack() : base("Base Layer.Attack.LastAttack") =>
            m_Attack = Animator.StringToHash("Attack");
        
        public override void OnStateEnter()
        {
            m_Machine.m_Animator.SetTrigger(m_Attack);
            m_Owner.m_AttackLeftTrail.Activate();
            m_Owner.m_AttackRightTrail.Activate();
        }

        public override void OnStateUpdate()
        {
            m_Machine.m_Animator.ResetTrigger(m_Attack);

            if (m_Machine.IsEnd())
            {
                m_Machine.ChangeState<Player_Idle>();
            }
        }
    }
}