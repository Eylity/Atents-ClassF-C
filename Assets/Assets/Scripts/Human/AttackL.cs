using UnityEngine;

namespace Human
{
    public class AttackL : State<PlayerController>
    {
        private static int _attack;
        private bool m_HasTrigger;

        public AttackL() : base("Base Layer.Attack.AttackL") => _attack = Animator.StringToHash("Attack");

        public override void Begin()
        {
            m_HasTrigger = false;
            PlayerController.GetPlayerController.m_Anim.SetTrigger(_attack);
            PlayerController.GetPlayerController.m_AttackLeftTrail.Activate();
            PlayerController.GetPlayerController.m_AttackRightTrail.Activate();
            PlayerController.GetPlayerController.m_CurState = EPlayerState.ATTACK;
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
            Debug.Log("ALLOG");

            if (stateInfo.normalizedTime >= 0.8f)
            {
                if (m_HasTrigger)
                {
                    Machine.ChangeState<AttackR>();
                }
                else
                {
                    Machine.ChangeState<Idle>();
                }
            }
        }
    }
}