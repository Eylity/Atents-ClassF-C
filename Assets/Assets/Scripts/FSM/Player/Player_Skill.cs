using UnityEngine;

namespace FSM.Player
{
    public class Player_Skill : IState
    {
        private static readonly int Skill = Animator.StringToHash("Skill");
        private readonly PlayerController m_Player;

        public Player_Skill(PlayerController player)
        {
            m_Player = player;
        }

        public void OnStateEnter()
        {
            m_Player.m_Anim.SetTrigger(Skill);
            Object.Instantiate(m_Player.m_Skill, m_Player.transform.position, Quaternion.identity);
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