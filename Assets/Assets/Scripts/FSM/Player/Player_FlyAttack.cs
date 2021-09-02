using UnityEngine;

namespace FSM.Player
{
    public class Player_FlyAttack : IState
    {
        private static readonly int FlyAttack = Animator.StringToHash("FlyAttack");
        private readonly PlayerController m_Player;
        private const float SPEED = 8f;
        private PSMeshRendererUpdater m_PsUpdater;
        private GameObject m_CurrentInstance;
        
        public Player_FlyAttack(PlayerController player)
        {
            m_Player = player;
        }
        public void OnStateEnter()
        {
            m_Player.m_Anim.SetTrigger(FlyAttack);
            m_Player.m_Rigidbody.AddForce(m_Player.transform.forward * SPEED,ForceMode.Impulse);
            m_CurrentInstance = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.FLYATTACKEFFECT);
            m_CurrentInstance.transform.SetParent(m_Player.transform);
            m_PsUpdater = m_CurrentInstance.GetComponent<PSMeshRendererUpdater>();
            m_PsUpdater.UpdateMeshEffect(m_Player.gameObject);
        }

        public void OnStateUpdate()
        {
            
        }

        public void OnStateFixedUpdate()
        {
        }
        public void OnStateExit()
        {
            var arrow = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.FLYATTACK);
            arrow.transform.position = m_Player.transform.position;
            m_PsUpdater.UpdateMeshEffect(null);
            ObjPool.ObjectPoolInstance.ReturnObject(m_CurrentInstance,EPrefabsName.FLYATTACKEFFECT,8.0f);
        }

    }
}