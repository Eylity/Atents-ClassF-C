using System.Collections;
using Human.PlayerScript;
using UnityEngine;

namespace Human.FSM.Player
{
    public class Player_FlyAttack : State
    {
        private static readonly int FlyAttack = Animator.StringToHash("FlyAttack");
        private readonly WaitForSeconds m_FlyAttackTimer = new WaitForSeconds(6.0f);
        private const float FORCE = 100f;
        public override IEnumerator OnStateEnter()
        {
            var currentInstance = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.FlyAttackEffect);
            currentInstance.transform.SetParent(Human.FSM.Player.PlayerController.GetPlayerController.gameObject.transform);
            var psUpdater = currentInstance.GetComponent<PSMeshRendererUpdater>();
            psUpdater.UpdateMeshEffect(Human.FSM.Player.PlayerController.GetPlayerController.gameObject);
            Human.FSM.Player.PlayerController.GetPlayerController.m_CurState = EPlayerState.FLY_ATTACK;
            Human.FSM.Player.PlayerController.GetPlayerController.Stamina -= 40f;
            Human.FSM.Player.PlayerController.GetPlayerController.m_ActiveFlyAttack = false;
            Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.SetTrigger(FlyAttack);
            Human.FSM.Player.PlayerController.GetPlayerController.AddImpact((Human.FSM.Player.PlayerController.GetPlayerController.transform.forward), FORCE);

            while (!Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("FlyAttack"))
                yield return null;
  
            Human.FSM.Player.PlayerController.GetPlayerController.m_AttackLeftTrail.Activate();
            Human.FSM.Player.PlayerController.GetPlayerController. m_AttackRightTrail.Activate();
            Human.FSM.Player.PlayerController.GetPlayerController.StartCoroutine(FlyAttackCoolDown());
            
            var startDust = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.FlyAttackStartDust);
            startDust.transform.position = Human.FSM.Player.PlayerController.GetPlayerController.transform.position;
            ObjPool.ObjectPoolInstance.ReturnObject(startDust,EPrefabsName.FlyAttackStartDust,1f);
            
            while (Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).normalizedTime <0.9f)
                yield return null;

            psUpdater.IsActive = false;
            ObjPool.ObjectPoolInstance.ReturnObject(currentInstance,EPrefabsName.FlyAttackEffect,2.0f);
            
            
            if (Human.FSM.Player.PlayerController.GetPlayerController.m_CurState != EPlayerState.DIE)
            {
                Human.FSM.Player.PlayerController.GetPlayerController.ChangeState(EPlayerState.IDLE);
            }
        }

        public override void OnStateExit()
        {
            Human.FSM.Player.PlayerController.GetPlayerController.m_AttackLeftTrail.Deactivate();
            Human.FSM.Player.PlayerController.GetPlayerController. m_AttackRightTrail.Deactivate();
            
            var arrow = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.FlyAttackArrow);
            arrow.transform.position = Human.FSM.Player.PlayerController.GetPlayerController.transform.position;
            ObjPool.ObjectPoolInstance.ReturnObject(arrow, EPrefabsName.FlyAttackArrow, 3f);
        }

        private IEnumerator FlyAttackCoolDown()
        {
            yield return m_FlyAttackTimer;
            Human.FSM.Player.PlayerController.GetPlayerController.m_ActiveFlyAttack = true;
        }
    }
}