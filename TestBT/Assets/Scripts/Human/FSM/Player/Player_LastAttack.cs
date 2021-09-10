using UnityEngine;

namespace FSM.Player
{
    public class Player_LastAttack : State<PlayerController>
    {
        private readonly int m_LastAttack;

        public Player_LastAttack() : base("Base Layer.Attack.LastAttack") =>
            m_LastAttack = Animator.StringToHash("Attack");
        
        public override void OnStateEnter()
        {
            m_Owner.m_AttackLeftTrail.Activate();
            m_Owner.m_AttackRightTrail.Activate();
        }

        public override void OnStateUpdate()
        {
            m_Machine.m_Animator.ResetTrigger(m_LastAttack);

            if (m_Machine.IsEnd())
            {
                m_Machine.ChangeState<Player_Idle>();
            }
        }

        public override void OnStateExit()
        {
            m_Owner.m_AttackLeftTrail.Deactivate();
            m_Owner.m_AttackRightTrail.Deactivate();
        }
    }
}