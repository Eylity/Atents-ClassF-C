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
            m_Anim =m_Owner.GetComponent<Animator>();
        }


        public override void OnStateEnter()
        {
            m_Anim.SetBool(IsMove,false);
            m_Anim.SetBool(IsRun,false);
            m_Anim.SetTrigger(m_Exhausted);
            m_Owner.StartCoroutine(ExhaustedTimer());
        }

        public override void OnStateUpdate(float deltaTime, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime < 0.9f)
            {
                return;
            }

            m_Owner.m_CurState = EPlayerState.Idle;
        }

        private IEnumerator ExhaustedTimer()
        {
            yield return m_ExhaustedTime;
            m_Owner.m_NowExhausted = false;
        }
    }
}