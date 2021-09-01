using UnityEngine;

namespace FSM.Player
{
    public class Player_Skill : State
    {
        private static readonly int Skill = Animator.StringToHash("Skill");
        private readonly PlayerFsm m_Player;

        public Player_Skill(PlayerFsm player)
        {
            m_Player = player;
        }

        public override void OnStateEnter()
        {
            m_Player.m_Anim.SetTrigger(Skill);
            Object.Instantiate(m_Player.m_Skill, m_Player.transform.position, Quaternion.identity);
        }

        public override void OnStateUpdate()
        {
        }

        public override void OnStateExit()
        {
        }
    }
}