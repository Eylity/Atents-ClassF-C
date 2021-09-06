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
            PlayerController.GetPlayerController.m_CurState = EPlayerState.FullSwing;
            PlayerController.GetPlayerController.m_Anim.SetTrigger(FullSwing);

            while (!PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("FullSwing"))
                yield return null;

            PlayerController.GetPlayerController.Stamina -= 40f;
            PlayerController.GetPlayerController.m_AttackLeftTrail.Activate();
            PlayerController.GetPlayerController. m_AttackRightTrail.Activate();
            PlayerController.GetPlayerController.m_ActiveFullSwing = false;
            PlayerController.GetPlayerController.StartCoroutine(FullSwingCoolDown());

            m_LeftCharge = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.ChargingFullAttack);
            m_RightCharge = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.ChargingFullAttack);
            while (PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("FullSwing"))
            {
                m_LeftCharge.transform.position =
                    PlayerController.GetPlayerController.m_AttackLeftTrail.transform.position;
                m_RightCharge.transform.position =
                    PlayerController.GetPlayerController.m_AttackRightTrail.transform.position;
                yield return null;
            }

            yield return PlayerController.GetPlayerController.ChangeState(EPlayerState.Idle);
        }

        public override void OnStateExit()
        {
            ObjPool.ObjectPoolInstance.ReturnObject(m_LeftCharge, EPrefabsName.ChargingFullAttack);
            ObjPool.ObjectPoolInstance.ReturnObject(m_RightCharge, EPrefabsName.ChargingFullAttack);
            PlayerController.GetPlayerController.m_AttackLeftTrail.Deactivate();
            PlayerController.GetPlayerController. m_AttackRightTrail.Deactivate();
        }

        private IEnumerator FullSwingCoolDown()
        {
            yield return m_FullSwingTimer;
            PlayerController.GetPlayerController.m_ActiveFullSwing = true;
        }
    }
}