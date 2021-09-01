using UnityEngine;

namespace FSM.Player
{
    public class Player_FullSwing : Istate<PlayerFSM>
    {
        private PlayerFSM m_Player;
        private static readonly int FullSwing = Animator.StringToHash("FullSwing");

        public Player_FullSwing(PlayerFSM player)
        {
            m_Player = player;
        }

        public override void OnStateEnter()
        {
            m_Player.m_Anim.SetTrigger(FullSwing);
            foreach (var collider in m_Player.m_AttackColliders)
            {
                collider.enabled = true;
            }
        }

        public override void OnStAteUpdate()
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

            foreach (var collider in m_Player.m_AttackColliders)
            {
                collider.enabled = false;
            }
        }

        public override void OnStateExit()
        {
        }
    }
}