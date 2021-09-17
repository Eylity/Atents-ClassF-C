using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace FSM.Player
{
    public class Player_Move : State<PlayerController>
    {
        private readonly int m_IsMove = Animator.StringToHash("IsMove");
        private readonly int m_IsRun = Animator.StringToHash("IsRun");
        
        // 중력
        private const float GRAVITY = 9.81f;
        private CharacterController m_CharacterController;
        private Transform m_CamPos;
        private Vector3 m_GravityVec = Vector3.zero;


        protected override void ONInitialized()
        {
            Debug.Assert(Camera.main != null, $"Script Name : {ToString()}\nCamera.main Is null");
            m_CamPos = Camera.main.transform;
            m_CharacterController = m_Owner.GetComponent<CharacterController>();
        }

        public override void OnStateEnter() => m_Machine.m_Animator.SetBool(m_IsMove, true);

        public override void ChangePoint()
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_Machine.ChangeState<Player_Attack>();
            }

            if (Input.GetKeyDown(KeyCode.Q) && m_Owner.PlayerStat.Stamina > 40f && m_Owner.m_ActiveFlyAttack)
            {
                m_Machine.ChangeState<Player_FlyAttack>();
            }

            if (Input.GetKeyDown(KeyCode.E) && m_Owner.PlayerStat.Stamina > 40f && m_Owner.m_ActiveFullSwing)
            {
                m_Machine.ChangeState<Player_FullSwing>();
            }

            if (Input.GetKeyDown(KeyCode.Space) && m_Owner.m_ActiveArea)
            {
                m_Machine.ChangeState<Player_Area>();
            }
        }
        
        // 뛰는 트리거 설정
        public override void OnStateUpdate()
        {
            if (Input.GetKey(KeyCode.LeftShift) && !m_Owner.m_NowExhausted)
            {
                m_Owner.PlayerStat.m_MoveSpeed = 7f;
                m_Owner.PlayerStat.m_RotateSpeed = 12f;
                m_Machine.m_Animator.SetBool(m_IsRun, true);
                m_Owner.m_NowRun = true;
            }
            else
            {
                m_Owner.PlayerStat.m_MoveSpeed = 4f;
                m_Owner.PlayerStat.m_RotateSpeed = 8f;
                m_Machine.m_Animator.SetBool(m_IsRun, false);
                m_Owner.m_NowRun = false;
            }
        }
        
        public override void OnFixedUpdate()
        {
            var moveX = Input.GetAxis("Horizontal");
            var moveZ = Input.GetAxis("Vertical");

            var movePos = (m_CamPos.right * moveX) + (m_CamPos.forward * moveZ);
            movePos.y = 0f;
            movePos.Normalize();
            
            // 입력값이 없을시 대기상태 전환
            if (movePos == Vector3.zero)
            {
                m_Machine.ChangeState<Player_Idle>();
                return;
            }
            
            // 자연스럽게 회전하기위함
            m_Owner.transform.rotation = Quaternion.Slerp(m_Owner.transform.rotation,
                Quaternion.LookRotation(movePos),
                m_Owner.PlayerStat.m_RotateSpeed * Time.deltaTime);
            
            // 중력적용
            if (!m_CharacterController.isGrounded)
            {
                m_GravityVec.y -= GRAVITY * Time.deltaTime;
            }

            m_CharacterController.Move((movePos + m_GravityVec) * (m_Owner.PlayerStat.m_MoveSpeed * Time.deltaTime));
        }

        public override void OnStateExit()
        {
            m_Owner.m_NowRun = false;
            m_Machine.m_Animator.SetBool(m_IsMove, false);
            m_Machine.m_Animator.SetBool(m_IsRun, false);
        }
    }
}