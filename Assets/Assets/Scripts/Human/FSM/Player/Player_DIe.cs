using Human;
using UnityEngine;

namespace FSM.Player
{
    public sealed class Player_DIe : State<PlayerController>
    {
        private readonly int m_Die;
        private Animator m_Anim;
        
        public Player_DIe() : base("Base Layer.RunLeft") => m_Die = Animator.StringToHash("Die");

        public override void ONInitialized()
        {
            m_Anim = PlayerController.GetPlayerController.GetComponent<Animator>();
        }
        
        public override void Begin()
        {
            m_Anim.SetTrigger(m_Die);
            PlayerController.GetPlayerController.m_IsLive = false;
        }
        public override void Update(float deltaTime, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime <= 9.0f)
            {
                PlayerController.GetPlayerController.gameObject.SetActive(false);
            }
        }
    }
}
