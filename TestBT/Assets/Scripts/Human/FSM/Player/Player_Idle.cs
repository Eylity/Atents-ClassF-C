using UnityEngine;
using XftWeapon;

namespace FSM.Player
{
    public class Player_Idle : State<PlayerController>
    {

        public override void ChangePoint()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                m_Machine.ChangeState<Player_Move>();
            }
            if (Input.GetMouseButtonDown(0))
            {
                m_Machine.ChangeState<Player_AttackL>();
            }

            if (Input.GetKey(KeyCode.Q) && m_Owner.Stamina > 40f && m_Owner.m_ActiveFlyAttack)
            {
                m_Machine.ChangeState<Player_FlyAttack>();
            }

            if (Input.GetKey(KeyCode.E) && m_Owner.Stamina > 40f && m_Owner.m_ActiveFullSwing)
            {
                m_Machine.ChangeState<Player_FullSwing>();
            }

            if (Input.GetKey(KeyCode.Space) && m_Owner.m_ActiveArea)
            {
                m_Machine.ChangeState<Player_Area>();
            }
        }
    }
}