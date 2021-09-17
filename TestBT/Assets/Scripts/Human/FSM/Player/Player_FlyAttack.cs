using System.Collections;
using UnityEngine;

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
        private readonly WaitForSeconds m_FlyAttackTimer = new WaitForSeconds(6.0f);
        private readonly int m_FlyAttack;

        // 가속도
        private const float ACCELERATION = 40f;

        private CharacterController m_CharacterController;
        private Vector3 m_Impact = Vector3.zero;

        public Player_FlyAttack() : base("Base Layer.Skill.FlyAttack") =>
            m_FlyAttack = Animator.StringToHash("FlyAttack");

        // 초기화시 캐릭터 컨트롤러 캐싱 및 가속도 구함
        protected override void ONInitialized() =>
            m_CharacterController =
                m_Owner.GetComponent<CharacterController>();

        // 이펙트 활성화 및 스킬 쿨다운
        public override void OnStateEnter()
        {
            m_Owner.PlayerStat.Stamina -= 40f;
            m_Owner.StartCoroutine(FlyAttackCoolDown());
            m_Machine.m_Animator.SetTrigger(m_FlyAttack);
            AddImpact(m_Owner.transform.forward);

            PlayerManager.Instance.TrailSwitch();
            PlayerManager.Instance.GetEffect(m_Owner.transform.position, EPrefabsName.FlyAttackEffect, 4f, 2f,
                m_Owner.gameObject);
        }

        public override void OnStateUpdate()
        {
            if (m_Machine.IsEnd())
            {
                m_Machine.ChangeState<Player_Idle>();
            }
        }

        // AddForce 함수로 받은 m_Impact 값으로 이동
        public override void OnFixedUpdate()
        {
            if (m_Impact.magnitude > 0.2)
            {
                m_CharacterController.SimpleMove(m_Impact);
            }

            m_Impact = Vector3.Lerp(m_Impact, Vector3.zero, 5 * Time.deltaTime);
        }

        public override void OnStateExit()
        {
            PlayerManager.Instance.GetEffect(m_Owner.transform.position, EPrefabsName.FlyAttackArrow, 3f);
        }

        private IEnumerator FlyAttackCoolDown()
        {
            m_Owner.m_ActiveFlyAttack = false;
            yield return m_FlyAttackTimer;
            m_Owner.m_ActiveFlyAttack = true;
        }

        // 날아가는 함수
        private void AddImpact(Vector3 dir)
        {
            dir.Normalize();
            if (dir.y < 0)
            {
                dir.y = -dir.y;
            }

            m_Impact += dir.normalized * ACCELERATION;
        }
    }
}