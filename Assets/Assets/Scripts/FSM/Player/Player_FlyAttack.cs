using UnityEngine;

namespace FSM.Player
{
    public class Player_FlyAttack : IState
    {
        private static readonly int FlyAttack = Animator.StringToHash("FlyAttack");
        private readonly PlayerController m_Player;
        private const float SPEED = 8f;
        private Animator m_Anim;
        public Player_FlyAttack(PlayerController player)
        {
            m_Player = player;
        }
        public void OnStateEnter()
        {
            m_Anim = m_Player.GetComponent<Animator>();
            m_Player.m_PlayerDamage = 40f;
            m_Player.m_Anim.SetTrigger(FlyAttack);
            m_Player.CollSwitch(true);

            m_Player.m_Rigidbody.AddForce(m_Player.transform.forward * SPEED,ForceMode.Impulse);
        }

        public void OnStateUpdate()
        {
            if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("FlyAttack"))
            {
                return;
            }

            var animInfo = m_Anim.GetCurrentAnimatorStateInfo(0);
            if (animInfo.normalizedTime < 0.9f)
            {
                return;
            }
            m_Player.m_PlayerDamage = 20f;

            m_Player.CollSwitch(false);
        }

        public void OnStateFixedUpdate()
        {
        }
        public void OnStateExit()
        {
        }

    }
}