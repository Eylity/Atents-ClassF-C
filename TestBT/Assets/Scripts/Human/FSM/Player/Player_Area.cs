using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace FSM.Player
{
    public class Player_Area : State<PlayerController>
    {
        // 스킬 쿨타임 및 스킬트리거 해쉬값
        private readonly WaitForSeconds m_AreaCoolTime = new WaitForSeconds(8.0f);
        private readonly int m_AreaTriggerHash;

        public Player_Area() : base("Base Layer.Skill.Skill") => m_AreaTriggerHash = Animator.StringToHash("Skill");
        
        // 이펙트 생성 및 스킬 쿨타임 체크
        public override void OnStateEnter()
        {
            machine.animator.SetTrigger(m_AreaTriggerHash);
            owner.StartCoroutine(AreaCoolDown());
            
            var _playerPos = owner.transform.position;
            
            PlayerManager.Instance.GetEffect(_playerPos, EPrefabsName.AreaEffect, 7f).transform.DOMoveY(_playerPos.y + 5.0f,2.5f);
            PlayerManager.Instance.GetEffect(_playerPos, EPrefabsName.HealWeapon, 10f, 8f,owner.gameObject);
            PlayerManager.Instance.GetEffect(_playerPos, EPrefabsName.Area,7f);
            PlayerManager.Instance.TrailSwitch();
        }

        public override void OnStateUpdate()
        {
            if (machine.IsEnd())
            {
                machine.ChangeState<Player_Idle>();
                Debug.Log("Move To Idle");
            }
        }

        private IEnumerator AreaCoolDown()
        {
            owner.activeArea = false;
            yield return m_AreaCoolTime;
            owner.activeArea = true;
        }
    }
}