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
            var obj = Object.Instantiate(m_Player.m_Skill, m_Player.transform.position, Quaternion.identity);
        }

        public override void OnStateUpdate()
        {
        }

        public override void OnStateExit()
        {
        }
    }
}