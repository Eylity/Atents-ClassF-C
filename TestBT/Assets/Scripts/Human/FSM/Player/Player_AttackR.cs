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
            m_Anim = PlayerController.GetPlayerController.GetComponent<Animator>();
        }

        public override void OnStateEnter()
        {
            m_HasTrigger = false;
            PlayerController.GetPlayerController.m_AttackLeftTrail.Activate();
            PlayerController.GetPlayerController.m_AttackRightTrail.Activate();
            m_Anim.SetTrigger(m_Attack);
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

            PlayerController.GetPlayerController.m_CurState = m_HasTrigger ? EPlayerState.LastAttack : EPlayerState.Idle;
        }

        public override void OnStateExit()
        {
            PlayerController.GetPlayerController.m_AttackLeftTrail.Deactivate();
            PlayerController.GetPlayerController.m_AttackRightTrail.Deactivate();
        }
    }
}