using UnityEngine;

namespace FSM.Player
{
    public class Player_Skill : Istate<PlayerFSM>
    {
        private PlayerFSM m_Player;

        public Player_Skill(PlayerFSM player)
        {
            m_Player = player;
        }
        public override void OnStateEnter()
        {
            m_Player.m_Anim.SetTrigger("Skill");
            m_Player.test();
        }

        public override void OnStAteUpdate()
        {
        }

        public override void OnStateExit()
        {
        }
    }
}