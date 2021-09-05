using System.Collections;
using UnityEngine;

namespace Human.FSM.Player
{
    public class Player_DIe : State
    {
        private static readonly int Die = Animator.StringToHash("Die");

        public override IEnumerator OnStateEnter()
        {
            Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.SetTrigger(Die);
            Human.FSM.Player.PlayerController.GetPlayerController.m_IsLive = false;
            Human.FSM.Player.PlayerController.GetPlayerController.m_CurState = EPlayerState.DIE;
            Human.FSM.Player.PlayerController.GetPlayerController.StopCoroutine("State");

            while (!Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Die"))
                yield return null;
            while (Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.8f)
                yield return null;
            Human.FSM.Player.PlayerController.GetPlayerController.gameObject.SetActive(false);
        }
    }
}