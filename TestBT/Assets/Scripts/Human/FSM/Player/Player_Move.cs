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
        private Transform m_CamTransform;
        private Vector3 m_GravityVec = Vector3.zero;


        protected override void ONInitialized()
        {
            Debug.Assert(Camera.main != null, $"Script Name : {ToString()}\nCamera.main Is null");
            m_CamTransform = Camera.main.transform;
            m_CharacterController = owner.GetComponent<CharacterController>();
        }

        public override void OnStateEnter() => machine.animator.SetBool(m_IsMove, true);

        public override void ChangePoint()
        {
            if (Input.GetMouseButtonDown(0))
            {
                machine.ChangeState<Player_Attack>();
            }

            if (Input.GetKeyDown(KeyCode.Q) && owner.PlayerStat.Stamina > 40f && owner.activeFlyAttack)
            {
                machine.ChangeState<Player_FlyAttack>();
            }

            if (Input.GetKeyDown(KeyCode.E) && owner.PlayerStat.Stamina > 40f && owner.activeFullSwing)
            {
                machine.ChangeState<Player_FullSwing>();
            }

            if (Input.GetKeyDown(KeyCode.Space) && owner.activeArea)
            {
                machine.ChangeState<Player_Area>();
            }
        }
        
        // 뛰는 트리거 설정
        public override void OnStateUpdate()
        {
            if (Input.GetKey(KeyCode.LeftShift) && !owner.nowExhausted)
            {
                owner.PlayerStat.moveSpeed = 7f;
                owner.PlayerStat.rotateSpeed = 12f;
                machine.animator.SetBool(m_IsRun, true);
                owner.nowRun = true;
            }
            else
            {
                owner.PlayerStat.moveSpeed = 4f;
                owner.PlayerStat.rotateSpeed = 8f;
                machine.animator.SetBool(m_IsRun, false);
                owner.nowRun = false;
            }
        }
        
        public override void OnFixedUpdate()
        {
            var _moveX = Input.GetAxis("Horizontal");
            var _moveZ = Input.GetAxis("Vertical");

            var _movePos = (m_CamTransform.right * _moveX) + (m_CamTransform.forward * _moveZ);
            _movePos.y = 0f;
            _movePos.Normalize();
            
            // 입력값이 없을시 대기상태 전환
            if (_movePos == Vector3.zero)
            {
                machine.ChangeState<Player_Idle>();
                return;
            }
            
            // 자연스럽게 회전하기위함
            owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation,
                Quaternion.LookRotation(_movePos),
                owner.PlayerStat.rotateSpeed * Time.deltaTime);
            
            // 중력적용
            if (!m_CharacterController.isGrounded)
            {
                m_GravityVec.y -= GRAVITY * Time.deltaTime;
            }

            m_CharacterController.Move((_movePos + m_GravityVec) * (owner.PlayerStat.moveSpeed * Time.deltaTime));
        }

        public override void OnStateExit()
        {
            owner.nowRun = false;
            machine.animator.SetBool(m_IsMove, false);
            machine.animator.SetBool(m_IsRun, false);
        }
    }
}