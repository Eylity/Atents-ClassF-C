using UnityEngine;

namespace FSM.Player
{
    public class Player_FullSwing : State
    {
        private static readonly int FullSwing = Animator.StringToHash("FullSwing");
        private readonly PlayerFsm m_Player;

        public Player_FullSwing(PlayerFsm player)
        {
            m_Player = player;
        }

        public override void OnStateEnter()
        {
            m_Player.m_Anim.SetTrigger(FullSwing);
            m_Player.CollSwitch(true);
        }

        public override void OnStateUpdate()
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

            m_Player.CollSwitch(false);
        }

        public override void OnStateExit()
        {
        }
    }
}