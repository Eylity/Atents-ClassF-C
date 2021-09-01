using UnityEngine;

namespace FSM.Player
{
    public class Player_Attack : Istate<PlayerFSM>
    {
        private readonly PlayerFSM m_Player;
        private static readonly int Attack = Animator.StringToHash("Attack");

        public Player_Attack(PlayerFSM player)
        {
            m_Player = player;
        }

        public override void OnStateEnter()
        {
            m_Player.m_Anim.SetTrigger(Attack);
            CollSwitch(true);
        }

        public override void OnStAteUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_Player.ChangeState(EPlayerState.Attack);
            }


            if (m_Player.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("AttackL"))
            {
                var animInfo = m_Player.m_Anim.GetCurrentAnimatorStateInfo(0);
                if (animInfo.normalizedTime >= 0.8f)
                {
                    CollSwitch(false);
                }
            }
            else if (m_Player.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("AttackR"))
            {
                var animInfo = m_Player.m_Anim.GetCurrentAnimatorStateInfo(0);

                if (animInfo.normalizedTime >= 0.8f)
                {
                    CollSwitch(false);
                }
            }
            else if (m_Player.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("LastAttack"))
            {
                var animInfo = m_Player.m_Anim.GetCurrentAnimatorStateInfo(0);

                if (animInfo.normalizedTime >= 0.8f)
                {
                    CollSwitch(false);
                }
                m_Player.m_Anim.ResetTrigger(Attack);
            }
        }

        public override void OnStateExit()
        {
            CollSwitch(true);
        }

        private void CollSwitch(bool isEnabled)
        {
            foreach (var collider in m_Player.m_AttackColliders)
            {
                collider.enabled = isEnabled;
            }
        }
    }
}