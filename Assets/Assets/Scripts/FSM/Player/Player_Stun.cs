using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public class Player_Stun : State
    {
        private static readonly int TakeDamage = Animator.StringToHash("TakeDamage");

        public override IEnumerator OnStateEnter()
        {
            PlayerController.GetPlayerController.m_CurState = EPlayerState.STUN;
            PlayerController.m_Anim.SetTrigger(TakeDamage);
            while (!PlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("TakeDamage"))
                yield return null;
            while (PlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("TakeDamage"))
                yield return null;
            PlayerController.GetPlayerController.ChangeState(EPlayerState.IDLE);
        }
    }
}