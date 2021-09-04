using DG.Tweening;
using FSM;
using FSM.Player;
using UnityEngine;

namespace Skill
{
    public class Player_Area : IState
    {
        private static readonly int Skill = Animator.StringToHash("Skill");
        private readonly PlayerController m_Player;

        public Player_Area(PlayerController player)
        {
            m_Player = player;
        }

        public void OnStateEnter()
        {
            m_Player.m_AttackLeftTrail.Activate();
            m_Player.m_AttackRightTrail.Activate();
            m_Player.m_Anim.SetTrigger(Skill);
            
            var area = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.Area);
            area.transform.position = m_Player.transform.position;
            ObjPool.ObjectPoolInstance.ReturnObject(area, EPrefabsName.Area, 7f);
            var areaEffect = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.AreaEffect);
            areaEffect.transform.position = m_Player.transform.position;
            areaEffect.transform.DOLocalMoveY(5f, 2f).SetEase(Ease.InQuad);
            ObjPool.ObjectPoolInstance.ReturnObject(areaEffect,EPrefabsName.AreaEffect,7f);
        }

        public void OnStateFixedUpdate()
        {
        }

        public void OnStateUpdate()
        {
        }

        public void OnStateExit()
        {
            m_Player.m_AttackLeftTrail.Deactivate();
            m_Player.m_AttackRightTrail.Deactivate();
        }
    }
}