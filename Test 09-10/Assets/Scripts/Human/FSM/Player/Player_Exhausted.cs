using System.Collections;
using UnityEngine;

namespace Human.FSM.Player
{
    public class Player_Exhausted : State
    {
        private static readonly int Exhausted = Animator.StringToHash("Exhausted");
        private readonly WaitForSeconds m_ExhaustedTime = new WaitForSeconds(5.0f);

        public override IEnumerator OnStateEnter()
        {
            Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.SetTrigger(Exhausted);
            Human.FSM.Player.PlayerController.GetPlayerController.m_CurState = EPlayerState.EXHAUSTED;
            while (!Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Exhausted"))
                yield return null;
            while (Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Exhausted"))
                yield return null;
            Human.FSM.Player.PlayerController.GetPlayerController.ChangeState(EPlayerState.IDLE);
            Human.FSM.Player.PlayerController.GetPlayerController.StartCoroutine(ExhaustedTimer());
        }

        private IEnumerator ExhaustedTimer()
        {
            yield return m_ExhaustedTime;
            Human.FSM.Player.PlayerController.GetPlayerController.m_NowExhausted = false;
        }
    }
}