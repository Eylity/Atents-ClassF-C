using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public class Player_Attack : IState
    {
        private static readonly int Attack = Animator.StringToHash("Attack");

        public override void OnStateEnter()
        {
            PlayerController.GetPlayerController.m_Anim.SetTrigger(Attack);
            PlayerController.GetPlayerController.TrailSwitch(true);
            PlayerController.GetPlayerController.m_NowReady = false;
        }

        public override void OnStateFixedUpdate()
        {
        }

        public override void OnStateUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlayerController.GetPlayerController.m_Anim.SetTrigger(Attack);
            }

            if (PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("LastAttack"))
            {
                PlayerController.GetPlayerController.m_Anim.ResetTrigger(Attack);
            }
        }

        public override void OnStateExit()
        {
            PlayerController.GetPlayerController.TrailSwitch(false);

        }
    }
}