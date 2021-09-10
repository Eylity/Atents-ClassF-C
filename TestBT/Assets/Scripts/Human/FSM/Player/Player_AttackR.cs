using UnityEngine;

namespace FSM.Player
{
    public class Player_AttackR : State<PlayerController>
    {
        private readonly int m_Attack;
        private Animator m_Anim;
        private bool m_HasTrigger;

        public Player_AttackR() : base("Base Layer.Attack.AttackR") => m_Attack = Animator.StringToHash("Attack");

        protected override void ONInitialized()
        {
            m_Anim = m_Owner.GetComponent<Animator>();
        }

        public override void OnStateEnter()
        {
            m_HasTrigger = false;
            m_Owner.m_AttackLeftTrail.Activate();
            m_Owner.m_AttackRightTrail.Activate();
        }

        public override void ChangePoint()
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_Anim.SetTrigger(m_Attack);
                m_HasTrigger = true;
            }
        }

        public override void OnStateUpdate(AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime >= 0.9f)
            {
                m_Owner.m_CurState = m_HasTrigger ? EPlayerState.LastAttack : EPlayerState.Idle;
            }
        }

        public override void OnStateExit()
        {
            m_Owner.m_AttackLeftTrail.Deactivate();
            m_Owner.m_AttackRightTrail.Deactivate();
        }
    }
}