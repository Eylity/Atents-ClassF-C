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
                m_Owner.m_CurState = EPlayerState.Move;
            }
            if (Input.GetMouseButtonDown(0))
            {
                m_Owner.m_CurState = EPlayerState.AttackL;
            }

            if (Input.GetKey(KeyCode.Q) && m_Owner.Stamina > 40f && m_Owner.m_ActiveFlyAttack)
            {
                m_Owner.m_CurState = EPlayerState.FlyAttack;
            }

            if (Input.GetKey(KeyCode.E) && m_Owner.Stamina > 40f && m_Owner.m_ActiveFullSwing)
            {
                m_Owner.m_CurState = EPlayerState.FullSwing;
            }

            if (Input.GetKey(KeyCode.Space) && m_Owner.m_ActiveArea)
            {
                m_Owner.m_CurState = EPlayerState.Area;
            }
        }
    }
}