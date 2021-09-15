using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public sealed class Player_FullSwing : State<PlayerController>
    {
        private readonly WaitForSeconds m_FullSwingTimer = new WaitForSeconds(7.0f);
        private readonly int m_FullSwing;
        private PSMeshRendererUpdater m_PSUpdater;
        private GameObject m_RightCharge;
        private GameObject m_LeftCharge;

        public Player_FullSwing() : base("Base Layer.Skill.FullSwing") =>
            m_FullSwing = Animator.StringToHash("FullSwing");

        public override void OnStateEnter()
        {
            m_Machine.m_Animator.SetTrigger(m_FullSwing);
            m_Owner.m_PlayerDamage += 5;
            m_Owner.Stamina -= 40f;

            m_Owner.m_ActiveFullSwing = false;
            m_Owner.StartCoroutine(FullSwingCoolDown());

            var gameObject = m_Owner.gameObject;
            var playerPos = m_Owner.transform.position;
            PlayerManager.Instance.TrailSwitch();
            m_PSUpdater = PlayerManager.Instance.GetEffect(gameObject, EPrefabsName.FullSwingEffect, 8.0f, gameObject.transform);
            PlayerManager.Instance.GetEffectObj(playerPos, EPrefabsName.ChargingFullSwing, out m_LeftCharge,5f);
            PlayerManager.Instance.GetEffectObj(playerPos, EPrefabsName.ChargingFullSwing, out m_RightCharge,5f);
        }

        public override void OnStateUpdate()
        {
            var playerPos = m_Owner.transform.position;
            m_LeftCharge.transform.position = playerPos;
            m_RightCharge.transform.position = playerPos;

            if (m_Machine.IsEnd())
            {
                m_Machine.ChangeState<Player_Idle>();
            }
        }

        public override void OnStateExit()
        {
            m_Owner.m_PlayerDamage -= 5;
            m_PSUpdater.IsActive = false;
        }

        private IEnumerator FullSwingCoolDown()
        {
            yield return m_FullSwingTimer;
            m_Owner.m_ActiveFullSwing = true;
        }
    }
}