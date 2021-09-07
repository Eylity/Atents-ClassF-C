using System.Collections;
using Human;
using UnityEngine;

namespace FSM.Player
{
    public class Player_FlyAttack : State<PlayerController>
    {
        private readonly WaitForSeconds m_FlyAttackTimer = new WaitForSeconds(6.0f);
        private PSMeshRendererUpdater m_PSUpdater;
        private Vector3 m_Impact = Vector3.zero;
        private const float FORCE = 100f;
        private readonly int m_FlyAttack;
        private bool m_IsGround = false;
        private const float MASS = 3f;
        private Animator m_Anim;

        public Player_FlyAttack() : base("Base Layer.Skill.FlyAttack") => m_FlyAttack = Animator.StringToHash("FlyAttack");
        public override void ONInitialized()
        {
            m_Anim = PlayerController.GetPlayerController.GetComponent<Animator>();
        }

        private void AddImpact(Vector3 dir, float force)
        {
            dir.Normalize();
            if (dir.y < 0) dir.y = -dir.y;
            m_Impact += dir.normalized * force / MASS;
        }
        
        public override void Begin()
        {
            var currentInstance = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.FlyAttackEffect);
            ObjPool.ObjectPoolInstance.ReturnObject(currentInstance, EPrefabsName.FlyAttackEffect, 4.0f);
            currentInstance.transform.SetParent(PlayerController.GetPlayerController.gameObject
                .transform);
            m_PSUpdater = currentInstance.GetComponent<PSMeshRendererUpdater>();
            m_PSUpdater.UpdateMeshEffect(PlayerController.GetPlayerController.gameObject);
            
            PlayerController.GetPlayerController.Stamina -= 40f;
            PlayerController.GetPlayerController.m_ActiveFlyAttack = false;
            m_Anim.SetTrigger(m_FlyAttack);
            AddImpact((PlayerController.GetPlayerController.transform.forward),
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
            if (m_Impact.magnitude > 0.2)
            {
                PlayerController.GetPlayerController.m_CharacterController.Move(m_Impact * Time.deltaTime);
            }

            m_Impact = Vector3.Lerp(m_Impact, Vector3.zero, 5 * Time.deltaTime);
            
            if (!(stateInfo.normalizedTime > 0.8f) || m_IsGround) 
                return;

            m_IsGround = true;
            m_PSUpdater.IsActive = false;
            var arrow = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.FlyAttackArrow);
            ObjPool.ObjectPoolInstance.ReturnObject(arrow, EPrefabsName.FlyAttackArrow, 3f);
            arrow.transform.position = PlayerController.GetPlayerController.transform.position;
            Machine.ChangeState<Player_Idle>();
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
