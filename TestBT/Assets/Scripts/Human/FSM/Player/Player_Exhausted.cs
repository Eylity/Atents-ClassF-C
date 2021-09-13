using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public class Player_Exhausted : State<PlayerController>
    {
        private static readonly int IsMove = Animator.StringToHash("IsMove");
        private static readonly int IsRun = Animator.StringToHash("IsRun");
        private readonly WaitForSeconds m_ExhaustedTime = new WaitForSeconds(8.0f);
        private readonly int m_Exhausted;

        public Player_Exhausted() : base("Base Layer.Exhausted") => m_Exhausted = Animator.StringToHash("Exhausted");


        public override void OnStateEnter()
        {
            Debug.Log($"StateEnter {ToString()}");
            m_Machine.m_Animator.SetBool(IsMove, false);
            m_Machine.m_Animator.SetBool(IsRun, false);
            m_Machine.m_Animator.SetTrigger(m_Exhausted);
            m_Owner.StartCoroutine(ExhaustedTimer());
        }

        public override void OnStateUpdate()
        {
            Debug.Log("!");
            if (m_Machine.IsEnd())
            {
                Debug.Log("!In");
                m_Machine.ChangeState<Player_Idle>();
            }
        }

        private IEnumerator ExhaustedTimer()
        {
            yield return m_ExhaustedTime;
            m_Owner.m_NowExhausted = false;
        }
    }
}