using System;
using UnityEngine;

namespace FSM.Player
{
    public class Player_Move : State<PlayerController>
    {
        private readonly int m_IsRun = Animator.StringToHash("IsRun");
        private readonly int m_IsMove = Animator.StringToHash("IsMove");
        private CharacterController m_CharacterController;
        private Animator m_Anim;
        private float m_RotateSpeed;
        private float m_MoveSpeed;
        private float m_MoveX;
        private float m_MoveZ;
        private bool m_IsNotInput;

        protected override void ONInitialized()
        {
            m_CharacterController = PlayerController.GetPlayerController.GetComponent<CharacterController>();
            m_Anim = PlayerController.GetPlayerController.GetComponent<Animator>();
        }

        public override void OnStateEnter()
        {
            m_IsNotInput = false;
            m_Anim.SetBool(m_IsMove, true);
        }

        public override void ChangePoint()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Machine.ChangeState<Player_AttackL>();
            }

            if (Input.GetKeyDown(KeyCode.Q) && PlayerController.GetPlayerController.Stamina > 40f &&
                PlayerController.GetPlayerController.m_ActiveFlyAttack)
            {
                Machine.ChangeState<Player_FlyAttack>();
            }

            if (Input.GetKeyDown(KeyCode.E) && PlayerController.GetPlayerController.Stamina > 40f &&
                PlayerController.GetPlayerController.m_ActiveFullSwing)
            {
                Machine.ChangeState<Player_FullSwing>();
            }

            if (Input.GetKeyDown(KeyCode.Space) && PlayerController.GetPlayerController.m_ActiveArea)
            {
                Machine.ChangeState<Player_Area>();
            }

            if (m_IsNotInput)
            {
                Machine.ChangeState<Player_Idle>();
            }
        }

        public override void OnStateUpdate(float deltaTime, AnimatorStateInfo stateInfo)
        {
        }

        public override void OnFixedUpdate(float deltaTime, AnimatorStateInfo stateInfo)
        {
            if (!PlayerController.GetPlayerController.m_IsLive) return;


            m_MoveX = Input.GetAxis("Horizontal");
            m_MoveZ = Input.GetAxis("Vertical");

            m_Anim.SetBool(m_IsMove, true);

            if (Input.GetKey(KeyCode.LeftShift) && !PlayerController.GetPlayerController.m_NowExhausted)
            {
                m_MoveSpeed = 6f;
                m_RotateSpeed = 12f;
                m_Anim.SetBool(m_IsRun, true);
                PlayerController.GetPlayerController.StaminaChange(false);
            }
            else
            {
                m_MoveSpeed = 4f;
                m_RotateSpeed = 8f;
                m_Anim.SetBool(m_IsRun, false);
                PlayerController.GetPlayerController.StaminaChange(true);
            }

            try
            {
                var camPos = Camera.main.transform;
                var movePos = camPos.right * m_MoveX + camPos.forward * m_MoveZ;
                movePos.y = 0f;
                movePos.Normalize();
                if (movePos == Vector3.zero)
                {
                    m_IsNotInput = true;
                    return;
                }

                m_CharacterController.Move(movePos * (m_MoveSpeed * deltaTime));
                PlayerController.GetPlayerController.transform.rotation = Quaternion.Slerp(
                    PlayerController.GetPlayerController.transform.rotation,
                    Quaternion.LookRotation(movePos),
                    m_RotateSpeed * deltaTime);
            }
            catch (NullReferenceException Error)
            {
                Debug.LogError($"Player Camera Is Null\n{Error}");
                throw;
            }
        }
    

    public override void OnStateExit()
    {
    m_Anim.SetBool(m_IsMove, false);
    m_Anim.SetBool(m_IsRun, false);
    }
}

}