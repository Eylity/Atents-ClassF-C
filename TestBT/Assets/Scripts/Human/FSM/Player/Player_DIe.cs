using UnityEngine;

namespace FSM.Player
{
    public sealed class Player_DIe : State<PlayerController>
    {
        private Animator m_Anim;
        private readonly int m_Die;
        private static readonly int IsMove = Animator.StringToHash("IsMove");
        private static readonly int IsRun = Animator.StringToHash("IsRun");

        public Player_DIe() : base("Base Layer.RunLeft") => m_Die = Animator.StringToHash("Die");

        protected override void ONInitialized()
        {
            m_Anim = m_Owner.GetComponent<Animator>();
        }

        public override void OnStateEnter()
        {
            m_Anim.SetBool(IsMove,false);
            m_Anim.SetBool(IsRun,false);
            m_Anim.SetTrigger(m_Die);
            m_Owner.m_IsLive = false;
        }

        public override void OnStateUpdate(float deltaTime, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime < 9.0f)
            {
                return;
            }

            m_Owner.gameObject.SetActive(false);
        }
    }
}