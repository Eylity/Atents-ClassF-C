using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public class Player_Exhausted : State<PlayerController>
    {
        private readonly int m_FlyAttack = Animator.StringToHash("FlyAttack");
        private readonly int m_FullSwing = Animator.StringToHash("FullSwing");
        private readonly int m_Attack = Animator.StringToHash("Attack");
        private readonly int m_IsMove = Animator.StringToHash("IsMove");
        private readonly int m_IsRun = Animator.StringToHash("IsRun");
        private readonly WaitForSeconds m_ExhaustedTime = new WaitForSeconds(8.0f);
        private readonly int m_Exhausted;

        public Player_Exhausted() : base("Base Layer.Exhausted") => m_Exhausted = Animator.StringToHash("Exhausted");


        public override void OnStateEnter()
        {
            PlayerManager.Instance.TrailSwitch(false);
            m_Machine.m_Animator.SetBool(m_IsMove, false);
            m_Machine.m_Animator.SetBool(m_IsRun, false);
            m_Machine.m_Animator.ResetTrigger(m_Attack);
            m_Machine.m_Animator.ResetTrigger(m_FlyAttack);
            m_Machine.m_Animator.ResetTrigger(m_FullSwing);
            m_Machine.m_Animator.SetTrigger(m_Exhausted);
            m_Owner.StartCoroutine(ExhaustedTimer());
        }

        public override void OnStateUpdate()
        {
            if (m_Machine.IsEnd())
            {
                m_Machine.ChangeState<Player_Idle>();
            }
        }

        private IEnumerator ExhaustedTimer()
        {
            m_Owner.m_NowExhausted = true;
            yield return m_ExhaustedTime;
            m_Owner.m_NowExhausted = false;
        }
    }
}