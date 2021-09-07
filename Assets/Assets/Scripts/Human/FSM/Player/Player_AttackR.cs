using Human;
using UnityEngine;

namespace FSM.Player
{
    public class Player_AttackR : State<PlayerController>
    {
        private Animator m_Anim;
        private static int _attack;
        private bool m_HasTrigger;

        public Player_AttackR() : base("Base Layer.Attack.AttackR") => _attack = Animator.StringToHash("Attack");

        public override void ONInitialized()
        {
            m_Anim = PlayerController.GetPlayerController.GetComponent<Animator>();
        }

        public override void Begin()
        {
            PlayerController.GetPlayerController.m_AttackLeftTrail.Activate();
            PlayerController.GetPlayerController.m_AttackRightTrail.Activate();
            m_HasTrigger = false;
            Debug.Log("AttackR Begin");
            m_Anim.SetTrigger(_attack);
        }

        public override void Reason()
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_HasTrigger = true;
            }
        }

        public override void Update(float deltaTime, AnimatorStateInfo stateInfo)
        {
            Debug.Log("ARLOG");

            if (stateInfo.normalizedTime >= 0.8f)
            {
                if (m_HasTrigger)
                {
                    Machine.ChangeState<Player_LastAttack>();
                }
                else
                {
                    Machine.ChangeState<Player_Idle>();
                }
            }
        }

        public override void End()
        {
            PlayerController.GetPlayerController.m_AttackLeftTrail.Deactivate();
            PlayerController.GetPlayerController.m_AttackRightTrail.Deactivate();
        }
    }
}