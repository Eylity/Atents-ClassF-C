using UnityEngine;

namespace FSM.Player
{
    public class Player_LastAttack : State<PlayerController>
    {
        private readonly int m_LastAttack;
        private Animator m_Anim;
        public Player_LastAttack() : base("Base Layer.Attack.LastAttack") => m_LastAttack = Animator.StringToHash("Attack");

        protected override void ONInitialized()
        {
            m_Anim = PlayerController.GetPlayerController.GetComponent<Animator>();
        }

        public override void OnStateEnter()
        {
            PlayerController.GetPlayerController.m_AttackLeftTrail.Deactivate();
            PlayerController.GetPlayerController.m_AttackRightTrail.Deactivate();
            m_Anim.SetTrigger(m_LastAttack);
        }

        public override void OnStateUpdate(float deltaTime, AnimatorStateInfo stateInfo)
        {
            m_Anim.ResetTrigger(m_LastAttack);
            
            if (stateInfo.normalizedTime >= 0.9f)
            {
                Machine.ChangeState<Player_Idle>();
            }
        }

        public override void OnStateExit()
        {
            PlayerController.GetPlayerController.m_AttackLeftTrail.Deactivate();
            PlayerController.GetPlayerController.m_AttackRightTrail.Deactivate();
        }
    }
}