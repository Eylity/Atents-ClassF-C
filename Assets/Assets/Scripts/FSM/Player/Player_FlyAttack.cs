using UnityEngine;

namespace FSM.Player
{
    public class Player_FlyAttack : State
    {
        private static readonly int FlyAttack = Animator.StringToHash("FlyAttack");
        private readonly PlayerFsm m_Player;
        private const float SPEED = 8f;
        public Player_FlyAttack(PlayerFsm player)
        {
            m_Player = player;
        }
        public override void OnStateEnter()
        {
            m_Player.m_Anim.SetTrigger(FlyAttack);
            m_Player.CollSwitch(true);

            m_Player.m_Rigidbody.AddForce(m_Player.transform.forward * SPEED,ForceMode.Impulse);
        }

        public override void OnStateUpdate()
        {
            if (!m_Player.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("FlyAttack"))
            {
                return;
            }

            var animInfo = m_Player.m_Anim.GetCurrentAnimatorStateInfo(0);
            if (animInfo.normalizedTime < 0.9f)
            {
                return;
            }
            m_Player.CollSwitch(false);
        }

        public override void OnStateExit()
        {
        }
    }
}