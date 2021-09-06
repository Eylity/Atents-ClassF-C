using System.Collections;
using UnityEngine;

namespace Human.FSM.Player
{
    public class Player_DIe : State
    {
        private static readonly int Die = Animator.StringToHash("Die");

        public override IEnumerator OnStateEnter()
        {
            PlayerController.GetPlayerController.m_IsLive = false;
            PlayerController.GetPlayerController.m_Anim.SetTrigger(Die);
            PlayerController.GetPlayerController.m_CurState = EPlayerState.Die;
            PlayerController.GetPlayerController.StopCoroutine("State");

            while (!PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Die"))
                yield return null;
            while (PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.8f)
                yield return null;
            PlayerController.GetPlayerController.gameObject.SetActive(false);
        }
    }
}