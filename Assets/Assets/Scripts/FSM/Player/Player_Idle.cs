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

        public Player_Idle(PlayerController player)
        {
            m_PLayer = player;
        }

        public void OnStateEnter()
        {
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

                var movePos = new Vector3(m_MoveX, m_PLayer.transform.localPosition.y, m_MoveZ) *
                              (m_MoveSpeed * Time.deltaTime);

                if (Input.GetMouseButton(1))
                {
                    Vector3 dir = cam.transform.localRotation * Vector3.forward;
                    //카메라가 바라보는 방향으로 팩맨도 바라보게 합니다.
                    m_PlayerTransform.localRotation = cam.transform.localRotation;
                    //팩맨의 Rotation.x값을 freeze해놓았지만 움직여서 따로 Rotation값을 0으로 세팅해주었습니다.
                    m_PlayerTransform.localRotation = new Quaternion(0, m_PlayerTransform.localRotation.y, 0,
                        m_PLayer.transform.localRotation.w);
                    //바라보는 시점 방향으로 이동합니다.
                    m_PLayer.transform.transform.Translate(movePos * 0.1f * Time.deltaTime);
                }
                else
                {
                    var position = m_PlayerTransform.localPosition;
                    position += movePos;
                    m_PlayerTransform.localPosition = position;

                    m_PlayerTransform.rotation = Quaternion.Slerp(m_PlayerTransform.rotation,
                        Quaternion.LookRotation(movePos),
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