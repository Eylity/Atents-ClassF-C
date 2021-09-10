using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public sealed class Player_FullSwing : State<PlayerController>
    {
        private readonly WaitForSeconds m_FullSwingTimer = new WaitForSeconds(7.0f);
        private readonly int m_FullSwing;
        private GameObject m_RightCharge;
        private GameObject m_LeftCharge;
        private Animator m_Anim;

        public Player_FullSwing() : base("Base Layer.Skill.FullSwing") =>
            m_FullSwing = Animator.StringToHash("FullSwing");

        protected override void ONInitialized()
        {
            m_Anim = m_Owner.GetComponent<Animator>();
        }

        public override void OnStateEnter()
        {
            m_Anim.SetTrigger(m_FullSwing);
            m_Owner.Stamina -= 40f;
            m_Owner.m_AttackLeftTrail.Activate();
            m_Owner.m_AttackRightTrail.Activate();
            m_Owner.m_ActiveFullSwing = false;
            m_Owner.StartCoroutine(FullSwingCoolDown());

            m_LeftCharge = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.ChargingFullAttack);
            m_RightCharge = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.ChargingFullAttack);
        }

        public override void OnStateUpdate(float deltaTime, AnimatorStateInfo stateInfo)
        {
            m_LeftCharge.transform.position =
                m_Owner.m_AttackLeftTrail.transform.position;
            m_RightCharge.transform.position =
                m_Owner.m_AttackRightTrail.transform.position;
            Debug.Log(stateInfo.fullPathHash);
            Debug.Log(m_StateToHash);
        }

        public override void OnStateExit()
        {
            ObjPool.ObjectPoolInstance.ReturnObject(m_LeftCharge, EPrefabsName.ChargingFullAttack);
            ObjPool.ObjectPoolInstance.ReturnObject(m_RightCharge, EPrefabsName.ChargingFullAttack);
            m_Owner.m_AttackRightTrail.Deactivate();
            m_Owner.m_AttackLeftTrail.Deactivate();
        }

        private IEnumerator FullSwingCoolDown()
        {
            yield return m_FullSwingTimer;
            m_Owner.m_ActiveFullSwing = true;
        }
    }
}