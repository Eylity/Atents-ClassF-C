using PlayerScript;
using UnityEngine;

namespace FSM.Player
{
    public class Player_FlyAttack : IState
    {
        private static readonly int FlyAttack = Animator.StringToHash("FlyAttack");
        private const float FORCE = 100f;
        private bool m_IsTime;
        private float m_Timer;
        public override void OnStateEnter()
        {
            PlayerController.GetPlayerController.m_NowReady = false;
            PlayerController.GetPlayerController.Stamina -= 40f;
            PlayerController.GetPlayerController.m_ActiveFlyAttack = false;
            PlayerController.GetPlayerController.StartCoroutine(PlayerController.GetPlayerController.CoolDown(ECoolDownSystem.FLY_ATTACK));
            
            var startDust = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.FlyAttackStartDust);
            startDust.transform.position = PlayerController.GetPlayerController.transform.position;
            ObjPool.ObjectPoolInstance.ReturnObject(startDust,EPrefabsName.FlyAttackStartDust,1f);
            
            PlayerController.GetPlayerController.TrailSwitch(true);

            
            PlayerController.GetPlayerController.m_Anim.SetTrigger(FlyAttack);
            m_IsTime = false;
            m_Timer = 0f;
        }

        public override void OnStateUpdate()
        {
            m_Timer += Time.deltaTime;
            if (!m_IsTime && m_Timer >= 0.1f)
            {
                m_IsTime = true;
                Debug.Log("FlyAttack AddForce");
                PlayerController.GetPlayerController.AddImpact((PlayerController.GetPlayerController.transform.forward), FORCE);
            }
        }

        public override void OnStateFixedUpdate()
        {
        }

        public override void OnStateExit()
        {
            PlayerController.GetPlayerController.TrailSwitch(false);

            var arrow = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.FlyAttackArrow);
            arrow.transform.position = PlayerController.GetPlayerController.transform.position;
            ObjPool.ObjectPoolInstance.ReturnObject(arrow, EPrefabsName.FlyAttackArrow, 3f);
        }
    }
}