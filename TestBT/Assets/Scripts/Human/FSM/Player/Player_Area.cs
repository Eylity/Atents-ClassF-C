using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public class Player_Area : State<PlayerController>
    {
        private readonly WaitForSeconds m_SkillTimer = new WaitForSeconds(8.0f);
        private readonly int m_Skill;
        private Animator m_Anim;

        public Player_Area() : base("Base Layer.Skill.Skill") => m_Skill = Animator.StringToHash("Skill");

        protected override void ONInitialized()
        {
            m_Anim = m_Owner.GetComponent<Animator>();
        }

        public override void OnStateEnter()
        {
            m_Anim.SetTrigger(m_Skill);
            m_Owner.m_ActiveArea = false;
            m_Owner.m_AttackLeftTrail.Activate();
            m_Owner.m_AttackRightTrail.Activate();
            m_Owner.StartCoroutine(AreaCoolDown());

            var playerPos = m_Owner.transform.position;

            var area = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.Area);
            area.transform.position = playerPos;
            ObjPool.ObjectPoolInstance.ReturnObject(area, EPrefabsName.Area, 7f);

            var areaEffect = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.AreaEffect);
            areaEffect.transform.position = playerPos;
            m_Owner.StartCoroutine(EffectUp(areaEffect));
            ObjPool.ObjectPoolInstance.ReturnObject(areaEffect, EPrefabsName.AreaEffect, 7f);
        }

        public override void OnStateUpdate(AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime < 0.9f)
            {
                return;
            }

            m_Owner.m_CurState = EPlayerState.Idle;
        }


        public override void OnStateExit()
        {
            m_Owner.m_AttackLeftTrail.Deactivate();
            m_Owner.m_AttackRightTrail.Deactivate();
        }

        private IEnumerator AreaCoolDown()
        {
            yield return m_SkillTimer;
            m_Owner.m_ActiveArea = true;
        }

        private IEnumerator EffectUp(GameObject effect)
        {
            var timer = 0f;
            while (timer <= 5f)
            {
                effect.transform.position += Vector3.up * 2f * Time.deltaTime;
                yield return timer += Time.deltaTime;
            }
        }
    }
}