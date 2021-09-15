using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace FSM.Player
{
    public class Player_Area : State<PlayerController>
    {
        private readonly WaitForSeconds m_SkillTimer = new WaitForSeconds(8.0f);
        private readonly int m_Skill;
        private PSMeshRendererUpdater m_PSUpdater;

        public Player_Area() : base("Base Layer.Skill.Skill") => m_Skill = Animator.StringToHash("Skill");
        
        public override void OnStateEnter()
        {
            m_Owner.m_ActiveArea = false;
            m_Machine.m_Animator.SetTrigger(m_Skill);
            m_Owner.StartCoroutine(AreaCoolDown());

            var player = m_Owner.gameObject;
            var playerPos = player.transform.position;
            PlayerManager.Instance.TrailSwitch();
            PlayerManager.Instance.GetEffect(player, EPrefabsName.Area,7f);
            PlayerManager.Instance.GetEffectObj(playerPos, EPrefabsName.AreaEffect, out var effect, 7f);
            effect.transform.DOMoveY(playerPos.y + 5.0f, 2.5f);
            m_PSUpdater = PlayerManager.Instance.GetEffect(player, EPrefabsName.HealWeapon, 10f, player.transform);
        }

        public override void OnStateUpdate()
        {
            if (m_Machine.IsEnd())
            {
                m_Machine.ChangeState<Player_Idle>();
            }
        }

        private IEnumerator AreaCoolDown()
        {
            yield return m_SkillTimer;
            m_PSUpdater.IsActive = false;
            m_Owner.m_ActiveArea = true;
        }
    }
}