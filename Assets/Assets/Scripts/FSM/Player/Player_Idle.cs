using DG.Tweening;
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
            PlayerController.GetPlayerController.CollSwitch(false);
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

                var moveDir = new Vector3(m_MoveX, 0F, m_MoveZ).normalized;
                

                if (Input.GetMouseButton(1))
                {
                    var movePos = cam.transform.TransformDirection(moveDir).normalized;
                    PlayerController.GetPlayerController.transform.rotation = cam.transform.rotation;
                    PlayerController.GetPlayerController.transform.position += movePos * Time.deltaTime * m_MoveSpeed;
                }
                else
                {
                    moveDir = moveDir * Time.deltaTime * m_MoveSpeed;
                    PlayerController.GetPlayerController.m_CharacterController.Move(moveDir);
                    m_PlayerTransform.rotation = Quaternion.Slerp(m_PlayerTransform.rotation,
                        Quaternion.LookRotation(moveDir),
                        m_RotateSpeed * Time.deltaTime);
                }
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