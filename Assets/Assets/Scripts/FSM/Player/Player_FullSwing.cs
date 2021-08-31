using UnityEngine;

namespace FSM.Player
{
    public class Player_FullSwing : Istate<PlayerFSM>
    {
        private PlayerFSM m_Player;

        public Player_FullSwing(PlayerFSM player)
        {
            m_Player = player;
        }

        public override void OnStateEnter()
        {
            m_Player.m_Anim.SetTrigger("FullSwing");
            foreach (var collider in m_Player.m_AttackCollider)
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
            AnimatorStateInfo animInfo = m_Player.m_Anim.GetCurrentAnimatorStateInfo(0);

            if (animInfo.normalizedTime <= 0.8f)
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