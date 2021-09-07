using UnityEngine;

namespace Human
{
    public sealed class DIe : State<PlayerController>
    {
        private readonly int m_Die;

        public DIe() : base("Base Layer.RunLeft")
        {
            m_Die = Animator.StringToHash("Die");
        }
        public override void Begin()
        {
            PlayerController.GetPlayerController.m_Anim.SetTrigger(m_Die);
            PlayerController.GetPlayerController.m_IsLive = false;
            PlayerController.GetPlayerController.m_CurState = EPlayerState.DIE;
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
