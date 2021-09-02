using UnityEngine;

namespace FSM.Player
{
    public class Player_FlyAttack : IState
    {
        private static readonly int FlyAttack = Animator.StringToHash("FlyAttack");
        private readonly PlayerController m_Player;
        private const float SPEED = 8f;
        public Player_FlyAttack(PlayerController player)
        {
            m_Player = player;
        }
        public void OnStateEnter()
        {
            m_Player.m_PlayerDamage = 40f;
            m_Player.m_Anim.SetTrigger(FlyAttack);
            m_Player.m_Rigidbody.AddForce(m_Player.transform.forward * SPEED,ForceMode.Impulse);
        }

        public void OnStateUpdate()
        {
            
        }

        public void OnStateFixedUpdate()
        {
        }
        public void OnStateExit()
        {
            m_Player.m_PlayerDamage = 20f;
        }

    }
}