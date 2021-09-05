using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public class Player_Exhausted : State
    {
        private static readonly int Exhausted = Animator.StringToHash("Exhausted");
        private readonly WaitForSeconds m_ExhaustedTime = new WaitForSeconds(5.0f);

        public override IEnumerator OnStateEnter()
        {
            PlayerController.GetPlayerController.m_Anim.SetTrigger(Exhausted);
            PlayerController.GetPlayerController.m_CurState = EPlayerState.EXHAUSTED;
            while (!PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Exhausted"))
                yield return null;
            while (PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Exhausted"))
                yield return null;
            PlayerController.GetPlayerController.ChangeState(EPlayerState.IDLE);
            PlayerController.GetPlayerController.StartCoroutine(ExhaustedTimer());
        }

        private IEnumerator ExhaustedTimer()
        {
            yield return m_ExhaustedTime;
            PlayerController.GetPlayerController.m_NowExhausted = false;
        }
    }
}