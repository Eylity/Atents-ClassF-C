using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public class Player_FlyAttack : IState
    {
        private static readonly int FlyAttack = Animator.StringToHash("FlyAttack");
        private readonly PlayerController m_Player;
        private const float SPEED = 15f;
        private bool m_IsTime;
        private float m_Timer;

        public Player_FlyAttack(PlayerController player)
        {
            m_Player = player;
        }

        public void OnStateEnter()
        {
            var startDust = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.FlyAttackStartDust);
            startDust.transform.position = m_Player.transform.position;
            ObjPool.ObjectPoolInstance.ReturnObject(startDust,EPrefabsName.FlyAttackStartDust,1f);
            
            m_Player.m_AttackLeftTrail.Activate();
            m_Player.m_AttackRightTrail.Activate();
            
            m_Player.m_Anim.SetTrigger(FlyAttack);
            m_IsTime = false;
            m_Timer = 0f;
        }

        public void OnStateUpdate()
        {
            m_Timer += Time.deltaTime;
            if (!m_IsTime && m_Timer >= 0.1f)
            {
                m_IsTime = true;
                Debug.Log("FlyAttack AddForce");
                m_Player.AddImpact((m_Player.transform.forward), 100f);
            }
        }

        public void OnStateFixedUpdate()
        {
        }

        public void OnStateExit()
        {
            m_Player.m_AttackLeftTrail.Deactivate();
            m_Player.m_AttackRightTrail.Deactivate();
            var arrow = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.FlyAttackArrow);
            arrow.transform.position = m_Player.transform.position;
            ObjPool.ObjectPoolInstance.ReturnObject(arrow, EPrefabsName.FlyAttackArrow, 2.5f);
        }
    }
}