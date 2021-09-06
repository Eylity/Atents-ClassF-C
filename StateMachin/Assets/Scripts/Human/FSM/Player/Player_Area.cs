using System.Collections;
using Human.PlayerScript;
using UnityEngine;

namespace Human.FSM.Player
{
    public class Player_Area : State
    {
        private static readonly int Skill = Animator.StringToHash("Skill");
        private readonly WaitForSeconds m_SkillTimer = new WaitForSeconds(8.0f);
        public override IEnumerator OnStateEnter()
        {
            PlayerController.GetPlayerController.m_Anim.SetTrigger(Skill);
            PlayerController.GetPlayerController.m_ActiveArea = false;
            PlayerController.GetPlayerController.m_CurState = EPlayerState.Area;

            while (!PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Skill"))
                yield return null;

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
            
            while (PlayerController.GetPlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Skill"))
                yield return null;
            
            if (PlayerController.GetPlayerController.m_CurState != EPlayerState.Die)
            {
                yield return PlayerController.GetPlayerController.ChangeState(EPlayerState.Idle);
            }
        }

        public override void OnStateExit()
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
}