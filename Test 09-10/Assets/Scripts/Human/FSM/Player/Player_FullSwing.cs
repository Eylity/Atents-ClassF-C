using System.Collections;
using Human.PlayerScript;
using UnityEngine;

namespace Human.FSM.Player
{
    public class Player_FullSwing : State
    {
        private static readonly int FullSwing = Animator.StringToHash("FullSwing");
        private readonly WaitForSeconds m_FullSwingTimer = new WaitForSeconds(7.0f);
        private GameObject m_LeftCharge;
        private GameObject m_RightCharge;


        public override IEnumerator OnStateEnter()
        {
            Human.FSM.Player.PlayerController.GetPlayerController.m_CurState = EPlayerState.FULL_SWING;
            Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.SetTrigger(FullSwing);

            while (!Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("FullSwing"))
                yield return null;

            Human.FSM.Player.PlayerController.GetPlayerController.Stamina -= 40f;
            Human.FSM.Player.PlayerController.GetPlayerController.m_AttackLeftTrail.Activate();
            Human.FSM.Player.PlayerController.GetPlayerController. m_AttackRightTrail.Activate();
            Human.FSM.Player.PlayerController.GetPlayerController.m_ActiveFullSwing = false;
            Human.FSM.Player.PlayerController.GetPlayerController.StartCoroutine(FullSwingCoolDown());

            m_LeftCharge = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.ChargingFullAttack);
            m_RightCharge = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.ChargingFullAttack);
            while (Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("FullSwing"))
            {
                m_LeftCharge.transform.position =
                    Human.FSM.Player.PlayerController.GetPlayerController.m_AttackLeftTrail.transform.position;
                m_RightCharge.transform.position =
                    Human.FSM.Player.PlayerController.GetPlayerController.m_AttackRightTrail.transform.position;
                yield return null;
            }

            Human.FSM.Player.PlayerController.GetPlayerController.ChangeState(EPlayerState.IDLE);
        }

        public override void OnStateExit()
        {
            ObjPool.ObjectPoolInstance.ReturnObject(m_LeftCharge, EPrefabsName.ChargingFullAttack);
            ObjPool.ObjectPoolInstance.ReturnObject(m_RightCharge, EPrefabsName.ChargingFullAttack);
            Human.FSM.Player.PlayerController.GetPlayerController.m_AttackLeftTrail.Deactivate();
            Human.FSM.Player.PlayerController.GetPlayerController. m_AttackRightTrail.Deactivate();
        }

        private IEnumerator FullSwingCoolDown()
        {
            yield return m_FullSwingTimer;
            Human.FSM.Player.PlayerController.GetPlayerController.m_ActiveFullSwing = true;
        }
    }
}