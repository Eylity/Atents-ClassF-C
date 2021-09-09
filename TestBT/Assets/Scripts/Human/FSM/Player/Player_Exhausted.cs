using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public class Player_Exhausted : State<PlayerController>
    {
        private readonly WaitForSeconds m_ExhaustedTime = new WaitForSeconds(8.0f);
        private readonly int m_Exhausted;
        private Animator m_Anim;
        private static readonly int IsMove = Animator.StringToHash("IsMove");
        private static readonly int IsRun = Animator.StringToHash("IsRun");

        public Player_Exhausted() : base("Base Layer.Exhausted") => m_Exhausted = Animator.StringToHash("Exhausted");

        protected override void ONInitialized()
        {
            m_Anim = PlayerController.GetPlayerController.GetComponent<Animator>();
        }


        public override void OnStateEnter()
        {
            m_Anim.SetBool(IsMove,false);
            m_Anim.SetBool(IsRun,false);
            m_Anim.SetTrigger(m_Exhausted);
            PlayerController.GetPlayerController.StartCoroutine(ExhaustedTimer());
        }

        public override void OnStateUpdate(float deltaTime, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime < 0.9f)
            {
                return;
            }

            PlayerController.GetPlayerController.m_CurState = EPlayerState.Idle;
        }

        private IEnumerator ExhaustedTimer()
        {
            yield return m_ExhaustedTime;
            PlayerController.GetPlayerController.m_NowExhausted = false;
        }
    }
}