using System.Collections;
using UnityEngine;

namespace Human
{
    public class Exhausted : State<PlayerController>
    {
        private readonly int m_Exhausted;
        private readonly WaitForSeconds m_ExhaustedTime = new WaitForSeconds(8.0f);

        public Exhausted() : base("Base Layer.Exhausted")
        {
            m_Exhausted = Animator.StringToHash("Exhausted");
        }

        public override void Begin()
        {
            PlayerController.GetPlayerController.m_Anim.SetTrigger(m_Exhausted);
            PlayerController.GetPlayerController.m_CurState = EPlayerState.EXHAUSTED;
            PlayerController.GetPlayerController.StartCoroutine(ExhaustedTimer());
        }

        public override void Update(float deltaTime, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime >= 0.9f)
            {
                PlayerController.GetPlayerController.m_StateMachine.ChangeState<Idle>();
            }
        }

        private IEnumerator ExhaustedTimer()
        {
            yield return m_ExhaustedTime;
            PlayerController.GetPlayerController.m_NowExhausted = false;
        }
    }
}
