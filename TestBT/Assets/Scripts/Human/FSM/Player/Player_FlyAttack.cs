using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public class Player_FlyAttack : State<PlayerController>
    {
        private readonly WaitForSeconds m_FlyAttackTimer = new WaitForSeconds(6.0f);
        private readonly int m_FlyAttack;
        private const float FORCE = 100f;
        private const float MASS = 3f;
        private CharacterController m_CharacterController;
        private Vector3 m_Impact = Vector3.zero;

        public Player_FlyAttack() : base("Base Layer.Skill.FlyAttack") =>
            m_FlyAttack = Animator.StringToHash("FlyAttack");

        protected override void ONInitialized() => m_CharacterController = m_Owner.GetComponent<CharacterController>();

        public override void OnStateEnter()
        {
            m_Owner.PlayerStat.Stamina -= 40f;
            m_Owner.StartCoroutine(FlyAttackCoolDown());
            m_Machine.m_Animator.SetTrigger(m_FlyAttack);
            AddImpact(m_Owner.transform.forward, FORCE);

            var player = m_Owner.transform.position;
            PlayerManager.Instance.TrailSwitch();
            PlayerManager.Instance.GetEffect(player,EPrefabsName.FlyAttackEffect,4f, 2f,m_Owner.gameObject);
        }

        public override void OnStateUpdate()
        {
            if (m_Machine.IsEnd())
            {
                m_Machine.ChangeState<Player_Idle>();
            }
        }

        public override void OnFixedUpdate(float deltaTime)
        {
            if (m_Impact.magnitude > 0.2)
            {
                m_CharacterController.SimpleMove(m_Impact);
            }

            m_Impact = Vector3.Lerp(m_Impact, Vector3.zero, 5 * deltaTime);
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

        private void AddImpact(Vector3 dir, float force)
        {
            dir.Normalize();
            if (dir.y < 0)
            {
                dir.y = -dir.y;
            }

            m_Impact += dir.normalized * force / MASS;
        }
    }
}