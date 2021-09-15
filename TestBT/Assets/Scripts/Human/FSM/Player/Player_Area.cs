using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace FSM.Player
{
    public class Player_Area : State<PlayerController>
    {
        private readonly WaitForSeconds m_SkillTimer = new WaitForSeconds(8.0f);
        private PSMeshRendererUpdater m_PSUpdater;
        private readonly int m_Skill;

        public Player_Area() : base("Base Layer.Skill.Skill") => m_Skill = Animator.StringToHash("Skill");
        
        public override void OnStateEnter()
        {
            m_Machine.m_Animator.SetTrigger(m_Skill);
            m_Owner.m_ActiveArea = false;
            m_Owner.m_AttackLeftTrail.Activate();
            m_Owner.m_AttackRightTrail.Activate();
            m_Owner.StartCoroutine(AreaCoolDown());
            var playerPos = m_Owner.transform.position;
            
            var currentEffect = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.HealWeapon);
            ObjPool.ObjectPoolInstance.ReturnObject(currentEffect, EPrefabsName.HealWeapon, 10.0f);
            currentEffect.transform.SetParent(m_Owner.gameObject.transform);
            m_PSUpdater = currentEffect.GetComponent<PSMeshRendererUpdater>();
            m_PSUpdater.UpdateMeshEffect(m_Owner.gameObject);
            m_Owner.m_PlayerDamage += 3;

            var area = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.Area);
            area.transform.position = playerPos;
            ObjPool.ObjectPoolInstance.ReturnObject(area, EPrefabsName.Area, 7f);

            var areaEffect = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.AreaEffect);
            areaEffect.transform.position = playerPos;
            areaEffect.transform.DOMoveY(playerPos.y +5.0f, 2.5f).SetEase(Ease.OutQuad);
            ObjPool.ObjectPoolInstance.ReturnObject(areaEffect, EPrefabsName.AreaEffect, 7f);
        }

        public override void OnStateUpdate()
        {
            if (m_Machine.IsEnd())
            {
                m_Machine.ChangeState<Player_Idle>();
            }
        }

        public override void OnStateExit()
        {
            m_Owner.m_AttackLeftTrail.Deactivate();
            m_Owner.m_AttackRightTrail.Deactivate();
        }

        private IEnumerator AreaCoolDown()
        {
            yield return m_SkillTimer;
            m_Owner.m_PlayerDamage -= 3;
            m_PSUpdater.IsActive = false;
            m_Owner.m_ActiveArea = true;
        }
    }
}