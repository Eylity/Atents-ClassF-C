using UnityEngine;

namespace FSM.Player
{
    public sealed class Player_DIe : State<PlayerController>
    {
        private Animator m_Anim;
        private readonly int m_Die;
        
        public Player_DIe() : base("Base Layer.RunLeft") => m_Die = Animator.StringToHash("Die");

        protected override void ONInitialized()
        {
            m_Anim = PlayerController.GetPlayerController.GetComponent<Animator>();
        }
        
        public override void OnStateEnter()
        {
            m_Anim.SetTrigger(m_Die);
            PlayerController.GetPlayerController.m_IsLive = false;
        }
        public override void OnStateUpdate(float deltaTime, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime < 0.9f)
                return;
             
            PlayerController.GetPlayerController.gameObject.SetActive(false);
        }
    }
}
