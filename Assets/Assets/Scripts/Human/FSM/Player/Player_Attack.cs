using System.Collections;
using UnityEngine;

namespace Human.FSM.Player
{
    public class Player_Attack : State
    {
        private static readonly int Attack = Animator.StringToHash("Attack");
        
        
        
        public override IEnumerator OnStateEnter()
        {
            Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.SetTrigger(Attack);
            Human.FSM.Player.PlayerController.GetPlayerController.m_CurState = EPlayerState.ATTACK;
            Human.FSM.Player.PlayerController.GetPlayerController.m_AttackLeftTrail.Activate();
            Human.FSM.Player.PlayerController.GetPlayerController.m_AttackRightTrail.Activate();

            while (!Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("AttackL"))
                yield return null;


            while (Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("AttackL"))
                yield return null;
            while (Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("AttackR"))
                yield return null;
            while (Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("LastAttack"))
                yield return null;
            
            
            Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.ResetTrigger(Attack);
            Human.FSM.Player.PlayerController.GetPlayerController.ChangeState(EPlayerState.IDLE);
        }

        public override void OnStateUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.SetTrigger(Attack);
            }
        }

        public override void OnStateExit()
        {
            Human.FSM.Player.PlayerController.GetPlayerController.m_AttackLeftTrail.Deactivate();
            Human.FSM.Player.PlayerController.GetPlayerController.m_AttackRightTrail.Deactivate();
        }
    }
}