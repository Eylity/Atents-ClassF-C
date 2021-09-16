﻿using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public sealed class Player_FullSwing : State<PlayerController>
    {
        private readonly WaitForSeconds m_FullSwingTimer = new WaitForSeconds(7.0f);
        private readonly int m_FullSwing;
        private GameObject m_RightCharge;
        private GameObject m_LeftCharge;

        public Player_FullSwing() : base("Base Layer.Skill.FullSwing") =>
            m_FullSwing = Animator.StringToHash("FullSwing");

        public override void OnStateEnter()
        {
            m_Owner.PlayerStat.Stamina -= 40f;
            m_Owner.StartCoroutine(FullSwingCoolDown());
            m_Machine.m_Animator.SetTrigger(m_FullSwing);
            m_Owner.PlayerStat.m_Damage += 5;

            var player = m_Owner.transform.position;
            PlayerManager.Instance.TrailSwitch();
            PlayerManager.Instance.GetEffect(player, EPrefabsName.FullSwingEffect, 8.0f, 3f, m_Owner.gameObject);
            m_LeftCharge = PlayerManager.Instance.GetEffect(player, EPrefabsName.ChargingFullSwing,5f);
            m_RightCharge = PlayerManager.Instance.GetEffect(player, EPrefabsName.ChargingFullSwing,5f);
        }

        public override void OnStateUpdate()
        {
            m_LeftCharge.transform.position = PlayerManager.Instance.m_AttackLeftTrail.transform.position;
            m_RightCharge.transform.position = PlayerManager.Instance.m_AttackRightTrail.transform.position;

            if (m_Machine.IsEnd())
            {
                m_Machine.ChangeState<Player_Idle>();
            }
        }

        public override void OnStateExit() => m_Owner.PlayerStat.m_Damage -= 5;

        private IEnumerator FullSwingCoolDown()
        {
            m_Owner.m_ActiveFullSwing = false;
            yield return m_FullSwingTimer;
            m_Owner.m_ActiveFullSwing = true;
        }
    }
}