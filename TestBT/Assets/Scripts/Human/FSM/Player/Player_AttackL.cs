using UnityEngine;

namespace FSM.Player
{
    public class Player_AttackL : State<PlayerController>
    {
        private readonly int m_Attack;
        private Animator m_Anim;
        private bool m_HasTrigger;

        public Player_AttackL() : base("Base Layer.Attack.AttackL") => m_Attack = Animator.StringToHash("Attack");

        protected override void ONInitialized()
        {
            m_Anim = m_Owner.GetComponent<Animator>();
        }

        public override void OnStateEnter()
        {
            m_HasTrigger = false;
            m_Anim.SetTrigger(m_Attack);
            m_Owner.m_AttackLeftTrail.Activate();
            m_Owner.m_AttackRightTrail.Activate();
        }

        public override void ChangePoint()
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_HasTrigger = true;
            }
        }

        public override void OnFixedUpdate(float deltaTime, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime < 0.8f)
            {
                return;
            }

            m_Owner.m_CurState =
                m_HasTrigger ? EPlayerState.AttackR : EPlayerState.Idle;
        }

        public override void OnStateExit()
        {
            m_Owner.m_AttackLeftTrail.Deactivate();
            m_Owner.m_AttackRightTrail.Deactivate();
        }
    }
}