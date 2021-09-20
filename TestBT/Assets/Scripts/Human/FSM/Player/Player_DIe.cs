using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public sealed class Player_DIe : State<PlayerController>
    {
        private readonly int m_FlyAttack = Animator.StringToHash("FlyAttack");
        private readonly int m_FullSwing = Animator.StringToHash("FullSwing");
        private readonly int m_Attack = Animator.StringToHash("Attack");
        private readonly int m_IsMove = Animator.StringToHash("IsMove");
        private readonly int m_IsRun = Animator.StringToHash("IsRun");
        private readonly WaitForSeconds m_DieTimer = new WaitForSeconds(2.2f);
        private readonly int m_Die;

        public Player_DIe() : base("Base Layer.Die") => m_Die = Animator.StringToHash("Die");

        public override void OnStateEnter()
        {
            // 모든 애니메이션 트리거 삭제
            PlayerManager.Instance.TrailSwitch(false);
            machine.animator.SetBool(m_IsMove, false);
            machine.animator.SetBool(m_IsRun, false);
            machine.animator.ResetTrigger(m_Attack);
            machine.animator.ResetTrigger(m_FlyAttack);
            machine.animator.ResetTrigger(m_FullSwing);
            machine.animator.SetTrigger(m_Die);
            owner.StartCoroutine(Die());
        }

        private IEnumerator Die()
        {
            // 사망처리
            owner.isLive = false;
            yield return m_DieTimer;
            owner.gameObject.SetActive(false);
        }
    }
}