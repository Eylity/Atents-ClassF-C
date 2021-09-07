using System.Collections;
using UnityEngine;
using Human;



    public class Area : State<PlayerController>
    {
        private readonly WaitForSeconds m_SkillTimer = new WaitForSeconds(8.0f);
        private readonly int m_Skill;

        public Area() : base( "Base Layer.Skill.Skill" )
        {
            m_Skill = Animator.StringToHash( "Skill" );
        }
        
        public override void Update(float deltaTime, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime >= 0.9f)
            {
                Machine.ChangeState<Idle>();
            }
        }
        
        public override void Begin()
        {
            PlayerController.GetPlayerController.m_Anim.SetTrigger(m_Skill);
            PlayerController.GetPlayerController.m_ActiveArea = false;
            PlayerController.GetPlayerController.m_CurState = EPlayerState.SKILL;
            PlayerController.GetPlayerController.m_AttackLeftTrail.Activate();
            PlayerController.GetPlayerController. m_AttackRightTrail.Activate();
            PlayerController.GetPlayerController.StartCoroutine(AreaCoolDown());
            
            var playerPos = PlayerController.GetPlayerController.transform.position;
            
            var area = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.Area);
            area.transform.position = playerPos;
            ObjPool.ObjectPoolInstance.ReturnObject(area, EPrefabsName.Area, 7f);
            
            var areaEffect = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.AreaEffect);
            areaEffect.transform.position = playerPos;
            PlayerController.GetPlayerController.StartCoroutine(EffectUp(areaEffect));
            ObjPool.ObjectPoolInstance.ReturnObject(areaEffect,EPrefabsName.AreaEffect,7f);
        }

        public override void End()
        {
            PlayerController.GetPlayerController.m_AttackLeftTrail.Deactivate();
            PlayerController.GetPlayerController. m_AttackRightTrail.Deactivate();
        }

        private IEnumerator AreaCoolDown()
        {
            yield return m_SkillTimer;
            PlayerController.GetPlayerController.m_ActiveArea = true;
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

