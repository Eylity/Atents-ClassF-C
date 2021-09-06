using System.Collections;
using UnityEngine;

namespace Human.FSM.Player
{
    public class Player_Exhausted : State
    {
        private readonly WaitForSeconds m_ExhaustedTime = new WaitForSeconds(5.0f);
        private static readonly int Exhausted = Animator.StringToHash("Exhausted");

        public override IEnumerator OnStateEnter()
        {
            PlayerController.GetPlayerController.m_Anim.SetTrigger(Exhausted);
            PlayerController.GetPlayerController.m_CurState = EPlayerState.Exhausted;
            while (!PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Exhausted"))
                yield return null;
            while (PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Exhausted"))
                yield return null;
            
            PlayerController.GetPlayerController.StartCoroutine(ExhaustedTimer());
            yield return PlayerController.GetPlayerController.ChangeState(EPlayerState.Idle);
        }

        private IEnumerator ExhaustedTimer()
        {
            yield return m_ExhaustedTime;
           PlayerController.GetPlayerController.m_NowExhausted = false;
        }
    }
}