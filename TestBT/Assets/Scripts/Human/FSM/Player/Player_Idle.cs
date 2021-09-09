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
                PlayerController.GetPlayerController.m_CurState = EPlayerState.Move;
            }
            if (Input.GetMouseButtonDown(0))
            {
                PlayerController.GetPlayerController.m_CurState = EPlayerState.AttackL;
            }

            if (Input.GetKey(KeyCode.Q) && PlayerController.GetPlayerController.Stamina > 40f && PlayerController.GetPlayerController.m_ActiveFlyAttack)
            {
                PlayerController.GetPlayerController.m_CurState = EPlayerState.FlyAttack;
            }

            if (Input.GetKey(KeyCode.E) && PlayerController.GetPlayerController.Stamina > 40f && PlayerController.GetPlayerController.m_ActiveFullSwing)
            {
                PlayerController.GetPlayerController.m_CurState = EPlayerState.FullSwing;
            }

            if (Input.GetKey(KeyCode.Space) && PlayerController.GetPlayerController.m_ActiveArea)
            {
                PlayerController.GetPlayerController.m_CurState = EPlayerState.Area;
            }
        }
    }
}