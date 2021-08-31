﻿using System;
using UnityEngine;

namespace FSM.Player
{
    public class Player_FlyAttack : Istate<PlayerFSM>
    {
        private PlayerFSM m_Player;
        private const float speed = 8f;
        public Player_FlyAttack(PlayerFSM player)
        {
            m_Player = player;
        }
        public override void OnStateEnter()
        {
            m_Player.m_Anim.SetTrigger("FlyAttack");
            foreach (var collider in m_Player.m_AttackCollider)
            {
                collider.enabled = true;
            }

            m_Player.m_Rigidbody.velocity = m_Player.transform.forward * speed;
        }

        public override void OnStAteUpdate()
        {
            if (!m_Player.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("FlyAttack"))
            {
                return;
            }
            var animInfo = m_Player.m_Anim.GetCurrentAnimatorStateInfo(0);
            if (animInfo.normalizedTime < 0.9f)
            {
                return;
            }
            foreach (var collider in m_Player.m_AttackCollider)
            {
                collider.enabled = false;
            }
        }

        public override void OnStateExit()
        {
        }
    }
}