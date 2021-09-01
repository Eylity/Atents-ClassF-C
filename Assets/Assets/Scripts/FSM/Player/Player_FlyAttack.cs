using System.Text;
using UnityEngine;

namespace FSM.Player
{
    public class Player_FlyAttack : Istate<PlayerFSM>
    {
        private static readonly int FlyAttack = Animator.StringToHash("FlyAttack");
        private readonly PlayerFSM m_Player;
        private const float SPEED = 8f;
        public Player_FlyAttack(PlayerFSM player)
        {
            m_Player = player;
        }
        public override void OnStateEnter()
        {
            m_Player.m_Anim.SetTrigger(FlyAttack);
            foreach (var collider in m_Player.m_AttackCollider)
            {
                collider.enabled = true;
            }

            m_Player.m_Rigidbody.AddForce(m_Player.transform.forward * SPEED,ForceMode.Impulse);
        }

        public override void OnStAteUpdate()
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