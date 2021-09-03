using FSM;
using FSM.Player;
using UnityEngine;

namespace Skill
{
    public class Player_FullSwing : IState
    {
        private static readonly int FullSwing = Animator.StringToHash("FullSwing");
        private readonly PlayerController m_Player;
        private GameObject m_LeftCharge;
        private GameObject m_RightCharge;

        public Player_FullSwing(PlayerController player)
        {
            m_Player = player;
        }

        public void OnStateEnter()
        {
            m_Player.m_AttackLeftTrail.Activate();
            m_Player.m_AttackRightTrail.Activate();
            m_Player.m_Anim.SetTrigger(FullSwing);
            
            m_LeftCharge = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.ChargingFullAttack);
            m_RightCharge = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.ChargingFullAttack);

        }

        public void OnStateFixedUpdate()
        {
        }

        public void OnStateUpdate()
        {
            m_LeftCharge.transform.position = m_Player.m_AttackLeftTrail.transform.position;
            m_RightCharge.transform.position = m_Player.m_AttackRightTrail.transform.position;
        }

        public void OnStateExit()
        {
            ObjPool.ObjectPoolInstance.ReturnObject(m_LeftCharge,EPrefabsName.ChargingFullAttack);
            ObjPool.ObjectPoolInstance.ReturnObject(m_RightCharge,EPrefabsName.ChargingFullAttack);
            m_Player.m_AttackLeftTrail.Deactivate();
            m_Player.m_AttackRightTrail.Deactivate();
        }
    }
}