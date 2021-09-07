using System.Collections;
using UnityEngine;

namespace Human
{
    public class FlyAttack : State<PlayerController>
    {
        private readonly WaitForSeconds m_FlyAttackTimer = new WaitForSeconds(6.0f);
        private PSMeshRendererUpdater m_PSUpdater;
        private const float FORCE = 100f;
        private readonly int m_FlyAttack;
        private bool m_IsGround = false;

        public FlyAttack() : base("Base Layer.Skill.FlyAttack")
        {
            m_FlyAttack = Animator.StringToHash("FlyAttack");
        }

        public override void Begin()
        {
            var currentInstance = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.FlyAttackEffect);
            ObjPool.ObjectPoolInstance.ReturnObject(currentInstance, EPrefabsName.FlyAttackEffect, 4.0f);
            currentInstance.transform.SetParent(PlayerController.GetPlayerController.gameObject
                .transform);
            m_PSUpdater = currentInstance.GetComponent<PSMeshRendererUpdater>();
            m_PSUpdater.UpdateMeshEffect(PlayerController.GetPlayerController.gameObject);
            PlayerController.GetPlayerController.m_CurState = EPlayerState.FLY_ATTACK;
            PlayerController.GetPlayerController.Stamina -= 40f;
            PlayerController.GetPlayerController.m_ActiveFlyAttack = false;
            PlayerController.GetPlayerController.m_Anim.SetTrigger(m_FlyAttack);
            PlayerController.GetPlayerController.AddImpact((PlayerController.GetPlayerController.transform.forward),
                FORCE);
            PlayerController.GetPlayerController.m_AttackLeftTrail.Activate();
            PlayerController.GetPlayerController.m_AttackRightTrail.Activate();
            PlayerController.GetPlayerController.StartCoroutine(FlyAttackCoolDown());

            var startDust = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.FlyAttackStartDust);
            startDust.transform.position = PlayerController.GetPlayerController.transform.position;
            ObjPool.ObjectPoolInstance.ReturnObject(startDust, EPrefabsName.FlyAttackStartDust, 1f);
        }

        public override void Update(float deltaTime, AnimatorStateInfo stateInfo)
        {
            if (!(stateInfo.normalizedTime > 0.9f) || m_IsGround) return;

            m_IsGround = true;
            m_PSUpdater.IsActive = false;
            var arrow = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.FlyAttackArrow);
            ObjPool.ObjectPoolInstance.ReturnObject(arrow, EPrefabsName.FlyAttackArrow, 3f);
            arrow.transform.position = PlayerController.GetPlayerController.transform.position;
            PlayerController.GetPlayerController.m_StateMachine.ChangeState<Idle>();
        }

        public override void End()
        {
            PlayerController.GetPlayerController.m_AttackRightTrail.Deactivate();
            PlayerController.GetPlayerController.m_AttackLeftTrail.Deactivate();
            m_IsGround = false;
        }

        private IEnumerator FlyAttackCoolDown()
        {
            yield return m_FlyAttackTimer;
            PlayerController.GetPlayerController.m_ActiveFlyAttack = true;
        }
    }
}
