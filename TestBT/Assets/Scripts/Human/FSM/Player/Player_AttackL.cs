using UnityEngine;

namespace FSM.Player
{
    public class Player_AttackL : State<PlayerController>
    {
        private readonly int m_Attack;

        public Player_AttackL() : base("Base Layer.Attack.AttackL") => m_Attack = Animator.StringToHash("Attack");

        public override void OnStateEnter()
        {
            Debug.Log($"StateEnter {ToString()}");
            m_Machine.m_Animator.SetTrigger(m_Attack);
            m_Owner.m_AttackLeftTrail.Activate();
            m_Owner.m_AttackRightTrail.Activate();
        }

        public override void ChangePoint()
        {
            if (Input.GetMouseButtonDown(0) && m_Machine.m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime <0.8f)
            {
                m_Machine.ChangeState<Player_AttackR>();
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
            m_Owner.m_AttackLeftTrail.Deactivate();
            m_Owner.m_AttackRightTrail.Deactivate();
        }
    }
}