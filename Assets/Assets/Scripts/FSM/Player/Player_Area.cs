using System.Collections;
using DG.Tweening;
using PlayerScript;
using UnityEngine;

namespace FSM.Player
{
    public class Player_Area : State
    {
        private static readonly int Skill = Animator.StringToHash("Skill");
        private readonly WaitForSeconds m_SkillTimer = new WaitForSeconds(8.0f);
        public override IEnumerator OnStateEnter()
        {
            PlayerController.m_Anim.SetTrigger(Skill);
            PlayerController.GetPlayerController.m_ActiveArea = false;
            PlayerController.GetPlayerController.m_CurState = EPlayerState.SKILL;

            while (!PlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Skill"))
                yield return null;

            PlayerController.GetPlayerController.TrailSwitch(true);
            PlayerController.GetPlayerController.StartCoroutine(AreaCoolDown());

            var playerPos = PlayerController.GetPlayerController.transform.position;
            
            var area = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.Area);
            area.transform.position = playerPos;
            ObjPool.ObjectPoolInstance.ReturnObject(area, EPrefabsName.Area, 7f);
            
            var areaEffect = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.AreaEffect);
            areaEffect.transform.position = playerPos;
            areaEffect.transform.DOLocalMoveY(5f, 2f).SetEase(Ease.InQuad);
            ObjPool.ObjectPoolInstance.ReturnObject(areaEffect,EPrefabsName.AreaEffect,7f);
            
            while (PlayerController.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Skill"))
                yield return null;
            
            PlayerController.GetPlayerController.ChangeState(EPlayerState.IDLE);
        }

        public override void OnStateExit()
        {
            PlayerController.GetPlayerController.TrailSwitch(false);
        }

        private IEnumerator AreaCoolDown()
        {
            yield return m_SkillTimer;
            PlayerController.GetPlayerController.m_ActiveArea = true;
        }
    }
}