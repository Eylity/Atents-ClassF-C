using UnityEngine;

namespace FSM.Player
{
    public class Player_Idle : IState
    {
        private static readonly int IsMove = Animator.StringToHash("IsMove");
        private static readonly int IsRun = Animator.StringToHash("IsRun");
        private float m_MoveX;
        private float m_MoveZ;
        private float m_MoveSpeed;
        private float m_RotateSpeed;
        private Transform m_PlayerTransform;
        private Camera cam;
        private Vector3 m_MoveDir;

        public void OnStateEnter()
        {
            m_PlayerTransform = PlayerController.GetPlayerController.transform;
            cam = Camera.main;
        }

        public void OnStateFixedUpdate()
        {
            if (PlayerController.GetPlayerController.m_NowReady)
            {
                m_MoveX = Input.GetAxis("Horizontal");
                m_MoveZ = Input.GetAxis("Vertical");
                if (m_MoveX == 0 && m_MoveZ == 0)
                {
                    PlayerController.GetPlayerController.m_Anim.SetBool(IsMove, false);
                    PlayerController.GetPlayerController.m_Anim.SetBool(IsRun, false);
                    return;
                }

                if (Input.GetKey(KeyCode.LeftShift) && !PlayerController.GetPlayerController.m_NowExhausted)
                {
                    m_MoveSpeed = 6f;
                    m_RotateSpeed = 8f;
                    PlayerController.GetPlayerController.m_Anim.SetBool(IsRun, true);
                }
                else
                {
                    m_MoveSpeed = 2f;
                    m_RotateSpeed = 8f;
                    PlayerController.GetPlayerController.m_Anim.SetBool(IsRun, false);
                }

                PlayerController.GetPlayerController.m_Anim.SetBool(IsMove, true);


                var movePos = cam.transform.right * m_MoveX + cam.transform.forward * m_MoveZ;
                movePos.y = 0f;
                movePos.Normalize();  
 
                PlayerController.GetPlayerController.m_CharacterController.Move(movePos * m_MoveSpeed * Time.deltaTime);
                PlayerController.GetPlayerController.transform.rotation = Quaternion.Slerp(m_PlayerTransform.rotation,
                    Quaternion.LookRotation(movePos),
                    m_RotateSpeed * Time.deltaTime);
            }
            else
            {
                PlayerController.GetPlayerController.m_Anim.SetBool(IsMove, false);
                PlayerController.GetPlayerController.m_Anim.SetBool(IsRun, false);
            }
        }

        public void OnStateUpdate()
        {
        }

        public void OnStateExit()
        {
            PlayerController.GetPlayerController.m_Anim.SetBool(IsMove, false);
            PlayerController.GetPlayerController.m_Anim.SetBool(IsRun, false);
        }
    }
}