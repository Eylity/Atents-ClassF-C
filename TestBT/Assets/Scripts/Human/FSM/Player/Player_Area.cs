using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace FSM.Player
{
    public class Player_Area : State<PlayerController>
    {
        private readonly WaitForSeconds m_SkillTimer = new WaitForSeconds(8.0f);
        private readonly int m_Skill;

        public Player_Area() : base("Base Layer.Skill.Skill") => m_Skill = Animator.StringToHash("Skill");
        
        public override void OnStateEnter()
        {
            m_Machine.m_Animator.SetTrigger(m_Skill);
            m_Owner.StartCoroutine(AreaCoolDown());

            var playerPos = m_Owner.transform.position;
            PlayerManager.Instance.TrailSwitch();
            PlayerManager.Instance.GetEffect(playerPos, EPrefabsName.Area,7f);
            PlayerManager.Instance.GetEffect(playerPos, EPrefabsName.HealWeapon, 10f, 8f,m_Owner.gameObject);
            PlayerManager.Instance.GetEffect(playerPos, EPrefabsName.AreaEffect, 7f).transform.DOMoveY(playerPos.y + 5.0f,2.5f);
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
            m_Owner.m_ActiveArea = false;
            yield return m_SkillTimer;
            m_Owner.m_ActiveArea = true;
        }
    }
}