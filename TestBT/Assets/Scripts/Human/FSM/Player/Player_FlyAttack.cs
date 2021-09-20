using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace FSM.Player
{
    public class Player_FlyAttack : State<PlayerController>
    {
        /*
         * 쿨타임
         * 날아가는 모션 구현하기위한 힘과 질량
         * 날아가는것 구현하기위한 캐릭터컨트롤러
         * 날아가는 방향
         * 정의
         */
        private readonly WaitForSeconds m_FlyAttackCoolTime = new WaitForSeconds(6.0f);
        private readonly int m_FlyAttack;

        // 가속도
        private const float JUMP_POWER = 10f;

        public Player_FlyAttack() : base("Base Layer.Skill.FlyAttack") =>
            m_FlyAttack = Animator.StringToHash("FlyAttack");

        // 이펙트 활성화 및 스킬 쿨다운
        public override void OnStateEnter()
        {
            owner.PlayerStat.Stamina -= 40f;
            owner.StartCoroutine(FlyAttackCoolDown());
            machine.animator.SetTrigger(m_FlyAttack);
            AddImpact(owner.transform.forward * JUMP_POWER);

            PlayerManager.Instance.TrailSwitch();
            PlayerManager.Instance.GetEffect(owner.transform.position, EPrefabsName.FlyAttackEffect, 4f, 2f,
                owner.gameObject);
        }

        public override void OnStateUpdate()
        {
            if (machine.IsEnd())
            {
                machine.ChangeState<Player_Idle>();
            }
        }

        public override void OnStateExit()
        {
            PlayerManager.Instance.GetEffect(owner.transform.position, EPrefabsName.FlyAttackArrow, 3f);
        }

        private IEnumerator FlyAttackCoolDown()
        {
            owner.activeFlyAttack = false;
            yield return m_FlyAttackCoolTime;
            owner.activeFlyAttack = true;
        }

        // 날아가는 함수
        private void AddImpact(Vector3 dir)
        {
            var _endValue = owner.transform.position + dir;
            owner.transform.DOJump(_endValue, 1f, 1,1).SetEase(Ease.OutQuad);
        }
    }
}