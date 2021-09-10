using UnityEngine;

namespace FSM.Player
{
    public class Player_LastAttack : State<PlayerController>
    {
        private readonly int m_LastAttack;
        private Animator m_Anim;

        public Player_LastAttack() : base("Base Layer.Attack.LastAttack") =>
            m_LastAttack = Animator.StringToHash("Attack");

        protected override void ONInitialized()
        {
            m_Anim = m_Owner.GetComponent<Animator>();
        }

        public override void OnStateEnter()
        {
            m_Owner.m_AttackLeftTrail.Activate();
            m_Owner.m_AttackRightTrail.Activate();
            m_Anim.SetTrigger(m_LastAttack);
        }

        public override void OnStateUpdate(AnimatorStateInfo stateInfo)
        {
            m_Anim.ResetTrigger(m_LastAttack);

            if (stateInfo.normalizedTime >= 0.9f)
            {
                m_Owner.m_CurState = EPlayerState.Idle;
            }
        }

        public override void OnStateExit()
        {
            m_Owner.m_AttackLeftTrail.Deactivate();
            m_Owner.m_AttackRightTrail.Deactivate();
        }
    }
}