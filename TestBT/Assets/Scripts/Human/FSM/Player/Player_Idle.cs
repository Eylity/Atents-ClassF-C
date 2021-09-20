using UnityEngine;

namespace FSM.Player
{
    public class Player_Idle : State<PlayerController>
    {
        public override void OnStateEnter() => PlayerManager.Instance.TrailSwitch(false);

        public override void ChangePoint()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) ||
                Input.GetKey(KeyCode.S))
            {
                machine.ChangeState<Player_Move>();
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                machine.ChangeState<Player_Attack>();
                return;
            }

            if (Input.GetKey(KeyCode.Q) && owner.PlayerStat.Stamina > 40f && owner.activeFlyAttack)
            {
                machine.ChangeState<Player_FlyAttack>();
                return;
            }

            if (Input.GetKey(KeyCode.E) && owner.PlayerStat.Stamina > 40f && owner.activeFullSwing)
            {
                machine.ChangeState<Player_FullSwing>();
                return;
            }

            if (Input.GetKey(KeyCode.Space) && owner.activeArea)
            {
                machine.ChangeState<Player_Area>();
                return;
            }
        }
    }
}