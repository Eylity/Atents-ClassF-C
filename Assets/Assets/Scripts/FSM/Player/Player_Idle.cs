using DG.Tweening;
using UnityEngine;

namespace FSM.Player
{
    public class Player_Idle : IState
    {
        private static readonly int IsMove = Animator.StringToHash("IsMove");
        private static readonly int IsRun = Animator.StringToHash("IsRun");
        private readonly PlayerController m_PLayer;
        private Animator m_Animator;
        private float m_MoveX;
        private float m_MoveZ;
        private float m_MoveSpeed;
        private float m_RotateSpeed;
        private Transform m_PlayerTransform;
        private Camera cam;
        private Vector3 m_MoveDir;
        private CharacterController m_CharacterController;

        public Player_Idle(PlayerController player)
        {
            m_PLayer = player;
        }

        public void OnStateEnter()
        {
            m_CharacterController = m_PLayer.GetComponent<CharacterController>();
            m_PlayerTransform = m_PLayer.transform;
            cam = Camera.main;
            m_Animator = m_PLayer.GetComponent<Animator>();
            m_PLayer.CollSwitch(false);
        }

        public void OnStateFixedUpdate()
        {
            if (m_PLayer.m_NowReady)
            {
                m_MoveX = Input.GetAxis("Horizontal");
                m_MoveZ = Input.GetAxis("Vertical");
                if (m_MoveX == 0 && m_MoveZ == 0)
                {
                    m_Animator.SetBool(IsMove, false);
                    m_Animator.SetBool(IsRun, false);
                    return;
                }

                if (Input.GetKey(KeyCode.LeftShift) && !m_PLayer.m_NowExhausted)
                {
                    m_MoveSpeed = 6f;
                    m_RotateSpeed = 8f;
                    m_PLayer.m_Anim.SetBool(IsRun, true);
                }
                else
                {
                    m_MoveSpeed = 2f;
                    m_RotateSpeed = 8f;
                    m_Animator.SetBool(IsRun, false);
                }

                m_Animator.SetBool(IsMove, true);

                var moveDir = new Vector3(m_MoveX, 0F, m_MoveZ).normalized;
                

                if (Input.GetMouseButton(1))
                {
                    var movePos = cam.transform.TransformDirection(moveDir).normalized;
                    m_PLayer.transform.rotation = cam.transform.rotation;
                    m_PLayer.transform.position += movePos * Time.deltaTime * m_MoveSpeed;
                }
                else
                {
                    moveDir = moveDir * Time.deltaTime * m_MoveSpeed;
                    m_CharacterController.Move(moveDir);
                    m_PlayerTransform.rotation = Quaternion.Slerp(m_PlayerTransform.rotation,
                        Quaternion.LookRotation(moveDir),
                        m_RotateSpeed * Time.deltaTime);
                }
            }
            else
            {
                m_Animator.SetBool(IsMove, false);
                m_Animator.SetBool(IsRun, false);
            }
        }

        public void OnStateUpdate()
        {
        }

        public void OnStateExit()
        {
            m_Animator.SetBool(IsMove, false);
            m_Animator.SetBool(IsRun, false);
        }
    }
}