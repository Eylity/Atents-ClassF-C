using UnityEngine;

namespace FSM.Player
{
    public class Player_LastAttack : State<PlayerController>
    {
        private readonly int m_LastAttack;
        private Animator m_Anim;
        public Player_LastAttack() : base("Base Layer.Attack.LastAttack") => m_LastAttack = Animator.StringToHash("Attack");
        
        public override void ONInitialized()
        {
            m_Anim = PlayerController.GetPlayerController.GetComponent<Animator>();
        }

        public override void Begin()
        {
            PlayerController.GetPlayerController.m_AttackLeftTrail.Deactivate();
            PlayerController.GetPlayerController.m_AttackRightTrail.Deactivate();
            Debug.Log("LastAttack Begin");
            m_Anim.SetTrigger(m_LastAttack);
        }

        public override void Update(float deltaTime, AnimatorStateInfo stateInfo)
        {
            m_Anim.ResetTrigger(m_LastAttack);
            
            Debug.Log("LALOG");

            if (stateInfo.normalizedTime >= 0.9f)
            {
                Machine.ChangeState<Player_Idle>();
            }
        }

        public override void End()
        {
            PlayerController.GetPlayerController.m_AttackLeftTrail.Deactivate();
            PlayerController.GetPlayerController.m_AttackRightTrail.Deactivate();
        }
    }
}