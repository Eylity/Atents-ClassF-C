using UnityEngine;

namespace FSM.Player
{
    public class Player_Idle : State<PlayerController>
    {

        public override void ChangePoint()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                Machine.ChangeState<Player_Move>();
            }
            if (Input.GetMouseButtonDown(0))
            {
                Machine.ChangeState<Player_AttackL>();
            }

            if (Input.GetKey(KeyCode.Q) && PlayerController.GetPlayerController.Stamina > 40f && PlayerController.GetPlayerController.m_ActiveFlyAttack)
            {
                Machine.ChangeState<Player_FlyAttack>();
            }

            if (Input.GetKey(KeyCode.E) && PlayerController.GetPlayerController.Stamina > 40f && PlayerController.GetPlayerController.m_ActiveFullSwing)
            {
                Machine.ChangeState<Player_FullSwing>();
            }

            if (Input.GetKey(KeyCode.Space) && PlayerController.GetPlayerController.m_ActiveArea)
            {
                Machine.ChangeState<Player_Area>();
            }
        }

        public override void OnStateUpdate(float deltaTime, AnimatorStateInfo stateInfo)
        {
            PlayerController.GetPlayerController.StaminaChange(true);
        }
    }
}