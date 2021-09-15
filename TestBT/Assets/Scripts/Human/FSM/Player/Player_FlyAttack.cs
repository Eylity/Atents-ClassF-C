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
        private PSMeshRendererUpdater m_PSUpdater;
        private Vector3 m_Impact = Vector3.zero;

        public Player_FlyAttack() : base("Base Layer.Skill.FlyAttack") =>
            m_FlyAttack = Animator.StringToHash("FlyAttack");

        protected override void ONInitialized()
        {
            m_CharacterController = m_Owner.GetComponent<CharacterController>();
        }


        public override void OnStateEnter()
        {
            m_Owner.Stamina -= 40f;
            m_Owner.m_ActiveFlyAttack = false;
            m_Machine.m_Animator.SetTrigger(m_FlyAttack);
            AddImpact((m_Owner.transform.forward), FORCE);
            
            var currentEffect = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.FlyAttackEffect);
            ObjPool.ObjectPoolInstance.ReturnObject(currentEffect, EPrefabsName.FlyAttackEffect, 4.0f);
            currentEffect.transform.SetParent(m_Owner.gameObject.transform);
            m_PSUpdater = currentEffect.GetComponent<PSMeshRendererUpdater>();
            m_PSUpdater.UpdateMeshEffect(m_Owner.gameObject);

            m_Owner.m_AttackLeftTrail.Activate();
            m_Owner.m_AttackRightTrail.Activate();
            m_Owner.StartCoroutine(FlyAttackCoolDown());
        }

        public override void OnStateUpdate()
        {
            if (m_Machine.IsEnd())
            {
                var arrow = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.FlyAttackArrow);
                ObjPool.ObjectPoolInstance.ReturnObject(arrow, EPrefabsName.FlyAttackArrow, 3f);
                arrow.transform.position = m_Owner.transform.position;
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
            m_PSUpdater.IsActive = false;
        }

        private IEnumerator FlyAttackCoolDown()
        {
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