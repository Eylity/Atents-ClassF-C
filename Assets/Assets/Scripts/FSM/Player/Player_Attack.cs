using UnityEngine;

namespace FSM.Player
{
    public class Player_Attack : State
    {
        private static readonly int Attack = Animator.StringToHash("Attack");
        private readonly PlayerFsm m_Player;

        public Player_Attack(PlayerFsm player)
        {
            m_Player = player;
        }

        public override void OnStateEnter()
        {
            m_Player.m_Anim.SetTrigger(Attack);
        }

        public override void OnStateUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_Player.m_Anim.SetTrigger(Attack);
            }

            if (m_Player.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("LastAttack"))
            {
                m_Player.m_Anim.ResetTrigger(Attack);
            }
        }

        public override void OnStateExit()
        {
        }
    }
}