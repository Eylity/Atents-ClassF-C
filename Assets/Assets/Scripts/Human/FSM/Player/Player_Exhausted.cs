﻿using System.Collections;
using Human;
using UnityEngine;

namespace FSM.Player
{
    public class Player_Exhausted : State<PlayerController>
    {
        private Animator m_Anim;
        private readonly int m_Exhausted;
        private readonly WaitForSeconds m_ExhaustedTime = new WaitForSeconds(8.0f);

        public Player_Exhausted() : base("Base Layer.Exhausted") => m_Exhausted = Animator.StringToHash("Exhausted");
        public override void ONInitialized()
        {
            m_Anim = PlayerController.GetPlayerController.GetComponent<Animator>();
        }
        

        public override void Begin()
        {
            m_Anim.SetTrigger(m_Exhausted);
            PlayerController.GetPlayerController.StartCoroutine(ExhaustedTimer());
        }

        public override void Update(float deltaTime, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime >= 0.9f)
            {
                Machine.ChangeState<Player_Idle>();
            }
        }

        private IEnumerator ExhaustedTimer()
        {
            yield return m_ExhaustedTime;
            PlayerController.GetPlayerController.m_NowExhausted = false;
        }
    }
}