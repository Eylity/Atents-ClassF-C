using UnityEngine;

namespace Human
{
    public class LastAttack : State<PlayerController>
    {
        private readonly int m_LastAttack;

        public LastAttack() : base("Base Layer.Attack.LastAttack") => m_LastAttack = Animator.StringToHash("Attack");

        public override void Begin()
        {
            Debug.Log("LastAttack Begin");
            PlayerController.GetPlayerController.m_Anim.SetTrigger(m_LastAttack);
        }

        public override void Update(float deltaTime, AnimatorStateInfo stateInfo)
        {
            PlayerController.GetPlayerController.m_Anim.ResetTrigger(m_LastAttack);
            
            Debug.Log("LALOG");

            if (stateInfo.normalizedTime >= 0.9f)
            {
                Machine.ChangeState<Idle>();
            }
        }
    }
}