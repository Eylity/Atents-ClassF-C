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
            m_Anim = PlayerController.GetPlayerController.GetComponent<Animator>();
        }

        public override void OnStateEnter()
        {
            m_HasTrigger = false;
            m_Anim.SetTrigger(m_Attack);
            PlayerController.GetPlayerController.m_AttackLeftTrail.Activate();
            PlayerController.GetPlayerController.m_AttackRightTrail.Activate();
        }

        public override void ChangePoint()
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_HasTrigger = true;
            }
        }

        public override void OnStateUpdate(float deltaTime, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime >= 0.8f)
            {
                if (m_HasTrigger)
                {
                    Machine.ChangeState<Player_AttackR>();
                }
                else
                {
                    Machine.ChangeState<Player_Idle>();
                }
            }
        }

        public override void OnStateExit()
        {
            PlayerController.GetPlayerController.m_AttackLeftTrail.Deactivate();
            PlayerController.GetPlayerController.m_AttackRightTrail.Deactivate();
        }
    }
}