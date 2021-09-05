using PlayerScript;
using UnityEngine;

namespace FSM.Player
{
    public class Player_FullSwing : IState
    {
        private static readonly int FullSwing = Animator.StringToHash("FullSwing");
        private GameObject m_LeftCharge;
        private GameObject m_RightCharge;


        public override void OnStateEnter()
        {
            PlayerController.GetPlayerController.m_NowReady = false;
            PlayerController.GetPlayerController.Stamina -= 40f;
            PlayerController.GetPlayerController.m_ActiveFullSwing = false;
            PlayerController.GetPlayerController.StartCoroutine(PlayerController.GetPlayerController.CoolDown(ECoolDownSystem.FULL_SWING));
            
            PlayerController.GetPlayerController.TrailSwitch(true);

            PlayerController.GetPlayerController.m_Anim.SetTrigger(FullSwing);
            
            m_LeftCharge = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.ChargingFullAttack);
            m_RightCharge = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.ChargingFullAttack);

        }

        public override void OnStateUpdate()
        {
            m_LeftCharge.transform.position = PlayerController.GetPlayerController.m_AttackLeftTrail.transform.position;
            m_RightCharge.transform.position = PlayerController.GetPlayerController.m_AttackRightTrail.transform.position;
        }

        public override void OnStateExit()
        {
            ObjPool.ObjectPoolInstance.ReturnObject(m_LeftCharge,EPrefabsName.ChargingFullAttack);
            ObjPool.ObjectPoolInstance.ReturnObject(m_RightCharge,EPrefabsName.ChargingFullAttack);
            PlayerController.GetPlayerController.TrailSwitch(false);

        }
    }
}