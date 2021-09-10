using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public sealed class Player_FullSwing : State<PlayerController>
    {
        private readonly WaitForSeconds m_FullSwingTimer = new WaitForSeconds(7.0f);
        private readonly int m_FullSwing;
        private GameObject m_RightCharge;
        private GameObject m_LeftCharge;
        private PSMeshRendererUpdater m_PSUpdater;

        public Player_FullSwing() : base("Base Layer.Skill.FullSwing") =>
            m_FullSwing = Animator.StringToHash("FullSwing");

        public override void OnStateEnter()
        {
            m_Machine.m_Animator.SetTrigger(m_FullSwing);
            m_Owner.Stamina -= 40f;
            m_Owner.m_AttackLeftTrail.Activate();
            m_Owner.m_AttackRightTrail.Activate();
            m_Owner.m_ActiveFullSwing = false;
            m_Owner.StartCoroutine(FullSwingCoolDown());
            
            var currentEffect = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.FullSwingEffect);
            ObjPool.ObjectPoolInstance.ReturnObject(currentEffect, EPrefabsName.FullSwingEffect, 8.0f);
            currentEffect.transform.SetParent(m_Owner.gameObject.transform);
            m_PSUpdater = currentEffect.GetComponent<PSMeshRendererUpdater>();
            m_PSUpdater.UpdateMeshEffect(m_Owner.gameObject);

            m_LeftCharge = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.ChargingFullSwing);
            m_RightCharge = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.ChargingFullSwing);
        }

        public override void OnStateUpdate()
        {
            m_LeftCharge.transform.position =
                m_Owner.m_AttackLeftTrail.transform.position;
            m_RightCharge.transform.position =
                m_Owner.m_AttackRightTrail.transform.position;

            if (m_Machine.IsEnd())
            {
                m_Machine.ChangeState<Player_Idle>();
            }
        }

        public override void OnStateExit()
        {
            m_PSUpdater.IsActive = false;
            ObjPool.ObjectPoolInstance.ReturnObject(m_LeftCharge, EPrefabsName.ChargingFullSwing);
            ObjPool.ObjectPoolInstance.ReturnObject(m_RightCharge, EPrefabsName.ChargingFullSwing);
            m_Owner.m_AttackRightTrail.Deactivate();
            m_Owner.m_AttackLeftTrail.Deactivate();
        }

        private IEnumerator FullSwingCoolDown()
        {
            yield return m_FullSwingTimer;
            m_Owner.m_ActiveFullSwing = true;
        }
    }
}