using DG.Tweening;
using PlayerScript;
using UnityEngine;

namespace FSM.Player
{
    public class Player_Area : IState
    {
        private static readonly int Skill = Animator.StringToHash("Skill");
        private float m_Timer;
        public override void OnStateEnter()
        {
            m_Timer = 0f;
            
            PlayerController.GetPlayerController.m_NowReady = false;
            PlayerController.GetPlayerController.m_ActiveArea = false;
            PlayerController.GetPlayerController.StartCoroutine(PlayerController.GetPlayerController.CoolDown(ECoolDownSystem.AREA));
            PlayerController.GetPlayerController.TrailSwitch(true);

            PlayerController.GetPlayerController.m_Anim.SetTrigger(Skill);
            
            var position = PlayerController.GetPlayerController.transform.position;
            
            var area = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.Area);
            area.transform.position = position;
            ObjPool.ObjectPoolInstance.ReturnObject(area, EPrefabsName.Area, 7f);
            
            var areaEffect = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.AreaEffect);
            areaEffect.transform.position = position;
            areaEffect.transform.DOLocalMoveY(5f, 2f).SetEase(Ease.InQuad);
            ObjPool.ObjectPoolInstance.ReturnObject(areaEffect,EPrefabsName.AreaEffect,7f);
        }

        public override void OnStateExit()
        {
            PlayerController.GetPlayerController.TrailSwitch(false);
        }
    }
}