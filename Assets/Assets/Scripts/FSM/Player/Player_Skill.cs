using UnityEngine;

namespace FSM.Player
{
    public class Player_Skill : Istate<PlayerFSM>
    {
        private PlayerFSM m_Player;
        private static readonly int Skill = Animator.StringToHash("Skill");

        public Player_Skill(PlayerFSM player)
        {
            m_Player = player;
        }
        public override void OnStateEnter()
        {
            m_Player.m_Anim.SetTrigger(Skill);
            m_Player.Test();
        }

        public override void OnStAteUpdate()
        {
            
        }

        public override void OnStateExit()
        {
        }
    }
}