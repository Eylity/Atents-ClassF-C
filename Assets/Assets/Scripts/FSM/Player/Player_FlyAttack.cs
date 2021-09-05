using System.Collections;
using PlayerScript;
using UnityEngine;

namespace FSM.Player
{
    public class Player_FlyAttack : State
    {
        private static readonly int FlyAttack = Animator.StringToHash("FlyAttack");
        private readonly WaitForSeconds m_FlyAttackTimer = new WaitForSeconds(6.0f);
        private const float FORCE = 100f;
        public override IEnumerator OnStateEnter()
        {
            PlayerController.GetPlayerController.m_CurState = EPlayerState.FLY_ATTACK;
            PlayerController.GetPlayerController.Stamina -= 40f;
            PlayerController.GetPlayerController.m_ActiveFlyAttack = false;
            PlayerController.m_Anim.SetTrigger(FlyAttack);

            while (!PlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("FlyAttack"))
                yield return null;
  
            PlayerController.GetPlayerController.TrailSwitch(true);
            PlayerController.GetPlayerController.StartCoroutine(FlyAttackCoolDown());
            PlayerController.GetPlayerController.AddImpact((PlayerController.GetPlayerController.transform.forward), FORCE);
            
            var startDust = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.FlyAttackStartDust);
            startDust.transform.position = PlayerController.GetPlayerController.transform.position;
            ObjPool.ObjectPoolInstance.ReturnObject(startDust,EPrefabsName.FlyAttackStartDust,1f);
            
            while (PlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("FlyAttack"))
                yield return null;

            PlayerController.GetPlayerController.ChangeState(EPlayerState.IDLE);
        }

        public override void OnStateExit()
        {
            PlayerController.GetPlayerController.TrailSwitch(false);
            
            var arrow = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.FlyAttackArrow);
            arrow.transform.position = PlayerController.GetPlayerController.transform.position;
            ObjPool.ObjectPoolInstance.ReturnObject(arrow, EPrefabsName.FlyAttackArrow, 3f);
        }

        private IEnumerator FlyAttackCoolDown()
        {
            yield return m_FlyAttackTimer;
            PlayerController.GetPlayerController.m_ActiveFlyAttack = true;
        }
    }
}