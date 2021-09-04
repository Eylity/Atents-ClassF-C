using System.Collections;
using UnityEngine;
using XftWeapon;

namespace FSM.Player
{
    public class Player_Attack : IState
    {
        private static readonly int Attack = Animator.StringToHash("Attack");
 

        public void OnStateEnter()
        {
            PlayerController.GetPlayerController.m_Anim.SetTrigger(Attack);
            PlayerController.GetPlayerController.m_AttackLeftTrail.Activate();
            PlayerController.GetPlayerController.m_AttackRightTrail.Activate();
        }

        public void OnStateFixedUpdate()
        {
        }

        public void OnStateUpdate()
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

        public void OnStateExit()
        {
            PlayerController.GetPlayerController.m_AttackLeftTrail.Deactivate();
            PlayerController.GetPlayerController.m_AttackRightTrail.Deactivate();
        }
    }
}