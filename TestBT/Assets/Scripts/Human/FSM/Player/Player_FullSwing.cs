using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public sealed class Player_FullSwing : State<PlayerController>
    {
        private readonly WaitForSeconds m_FullSwingCoolTime = new WaitForSeconds(7.0f);
        private readonly int m_FullSwing;
        private GameObject m_RightChargeEffect;
        private GameObject m_LeftChargeEffect;

        public Player_FullSwing() : base("Base Layer.Skill.FullSwing") =>
            m_FullSwing = Animator.StringToHash("FullSwing");

        // 이펙트 활성화 및 스킬 쿨다운
        public override void OnStateEnter()
        {
            owner.PlayerStat.Stamina -= 40f;
            owner.StartCoroutine(FullSwingCoolDown());
            machine.animator.SetTrigger(m_FullSwing);
            owner.PlayerStat.damage += 5;

            var _player = owner.transform.position;
            PlayerManager.Instance.TrailSwitch();
            PlayerManager.Instance.GetEffect(_player, EPrefabsName.FullSwingEffect, 8.0f, 3f, owner.gameObject);
            m_LeftChargeEffect = PlayerManager.Instance.GetEffect(_player, EPrefabsName.ChargingFullSwing,5f);
            m_RightChargeEffect = PlayerManager.Instance.GetEffect(_player, EPrefabsName.ChargingFullSwing,5f);
        }

        public override void OnStateUpdate()
        {
            m_LeftChargeEffect.transform.position = PlayerManager.Instance.m_AttackLeftTrail.transform.position;
            m_RightChargeEffect.transform.position = PlayerManager.Instance.m_AttackRightTrail.transform.position;

            if (machine.IsEnd())
            {
                machine.ChangeState<Player_Idle>();
            }
        }

        public override void OnStateExit() => owner.PlayerStat.damage -= 5;

        private IEnumerator FullSwingCoolDown()
        {
            owner.activeFullSwing = false;
            yield return m_FullSwingCoolTime;
            owner.activeFullSwing = true;
        }
    }
}