using UnityEngine;

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
            m_Player.m_PlayerDamage = 50f;
            m_Player.m_Anim.SetTrigger(FullSwing);
            m_Player.CollSwitch(true);
        }

        public void OnStateFixedUpdate()
        {
        }

        public void OnStateUpdate()
        {
            if (!m_Player.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("FullSwing"))
            {
                return;
            }

            var animInfo = m_Player.m_Anim.GetCurrentAnimatorStateInfo(0);

            if (animInfo.normalizedTime <= 0.9f)
            {
                return;
            }

            m_Player.m_PlayerDamage = 20f;
            m_Player.CollSwitch(false);
        }

        public void OnStateExit()
        {

        }
    }
}