﻿using UnityEngine;

namespace FSM.Player
{
    public class Player_FullSwing : IState
    {
        private static readonly int FullSwing = Animator.StringToHash("FullSwing");
        private readonly PlayerController m_Player;

        public Player_FullSwing(PlayerController player)
        {
            m_Player = player;
        }

        public void OnStateEnter()
        {
            m_Player.m_Anim.SetTrigger(FullSwing);
        }

        public void OnStateFixedUpdate()
        {
        }

        public void OnStateUpdate()
        {
        }

        public void OnStateExit()
        {
        }
    }
}