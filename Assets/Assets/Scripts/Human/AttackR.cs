using System.Collections.Generic;
using UnityEngine;

namespace Human
{
    public class AttackR : State<PlayerController>
    {
        private static int _attack;
        private bool m_HasTrigger;

        public AttackR() : base("Base Layer.Attack.AttackR") => _attack = Animator.StringToHash("Attack");
        public override void Begin()
        {
            m_HasTrigger = false;
            Debug.Log("AttackR Begin");
            PlayerController.GetPlayerController.m_Anim.SetTrigger(_attack);
            PlayerController.GetPlayerController.m_CurState = EPlayerState.ATTACKR;
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
                    Machine.ChangeState<LastAttack>();
                }
                else
                {
                    Machine.ChangeState<Idle>();
                }
            }
        }
    }
}