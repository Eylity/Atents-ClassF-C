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
            // 애니메이션 트리거 취소
            PlayerManager.Instance.TrailSwitch(false);
            machine.animator.SetBool(m_IsMove, false);
            machine.animator.SetBool(m_IsRun, false);
            machine.animator.ResetTrigger(m_Attack);
            machine.animator.ResetTrigger(m_FlyAttack);
            machine.animator.ResetTrigger(m_FullSwing);
            machine.animator.SetTrigger(m_Exhausted);
            owner.StartCoroutine(ExhaustedTimer());
        }

        public override void OnStateUpdate()
        {
            if (machine.IsEnd())
            {
                machine.ChangeState<Player_Idle>();
            }
        }

        private IEnumerator ExhaustedTimer()
        {
            // 탈진 시간
            owner.nowExhausted = true;
            yield return m_ExhaustedTime;
            owner.nowExhausted = false;
        }
    }
}