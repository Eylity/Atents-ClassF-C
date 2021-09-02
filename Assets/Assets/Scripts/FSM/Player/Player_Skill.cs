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
            var obj = ObjPool.GetObject(EPrefabsName.PLAYERSKILL);
            obj.transform.position = m_Player.transform.position;
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