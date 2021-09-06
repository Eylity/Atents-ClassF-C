using System.Collections;
using UnityEngine;

namespace Human.FSM.Player
{
    public class Player_Attack : State
    {
        private static readonly int Attack = Animator.StringToHash("Attack");

        public override IEnumerator OnStateEnter()
        {
            PlayerController.GetPlayerController.m_Anim.SetTrigger(Attack);
            PlayerController.GetPlayerController.m_AttackLeftTrail.Activate();
            PlayerController.GetPlayerController.m_AttackRightTrail.Activate();
            PlayerController.GetPlayerController.m_CurState = EPlayerState.Attack;

            while (!PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("AttackL"))
                yield return null;


            while (PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("AttackL"))
                yield return null;
            while (PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("AttackR"))
                yield return null;
            while (PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("LastAttack"))
                yield return null;
            
            
            PlayerController.GetPlayerController.m_Anim.ResetTrigger(Attack);
            yield return PlayerController.GetPlayerController.ChangeState(EPlayerState.Idle);
        }

        public override void OnStateUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlayerController.GetPlayerController.m_Anim.SetTrigger(Attack);
            }
        }

        public override void OnStateExit()
        {
            PlayerController.GetPlayerController.m_AttackLeftTrail.Deactivate();
            PlayerController.GetPlayerController.m_AttackRightTrail.Deactivate();
        }
    }
}