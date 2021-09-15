using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace FSM.Player
{
    public class Player_Move : State<PlayerController>
    {
        private readonly int m_IsMove = Animator.StringToHash("IsMove");
        private readonly int m_IsRun = Animator.StringToHash("IsRun");
        private const float GRAVITY = 9.81f;
        private CharacterController m_CharacterController;
        private Transform m_CamPos;
        private Vector3 m_GravityVec = Vector3.zero;
        private float m_RotateSpeed;
        private float m_MoveSpeed;

        protected override void ONInitialized()
        {
            Debug.Assert(Camera.main != null, $"{ToString()}\nCamera.main Is null");
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

            if (Input.GetKeyDown(KeyCode.Q) && m_Owner.Stamina > 40f && m_Owner.m_ActiveFlyAttack)
            {
                m_Machine.ChangeState<Player_FlyAttack>();
            }

            if (Input.GetKeyDown(KeyCode.E) && m_Owner.Stamina > 40f && m_Owner.m_ActiveFullSwing)
            {
                m_Machine.ChangeState<Player_FullSwing>();
            }

            if (Input.GetKeyDown(KeyCode.Space) && m_Owner.m_ActiveArea)
            {
                m_Machine.ChangeState<Player_Area>();
            }
        }

        public override void OnFixedUpdate(float deltaTime)
        {
            var moveX = Input.GetAxis("Horizontal");
            var moveZ = Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.LeftShift) && !m_Owner.m_NowExhausted)
            {
                m_MoveSpeed = 6f;
                m_RotateSpeed = 12f;
                m_Machine.m_Animator.SetBool(m_IsRun, true);
                m_Owner.m_NowRun = true;
            }
            else
            {
                m_MoveSpeed = 4f;
                m_RotateSpeed = 8f;
                m_Machine.m_Animator.SetBool(m_IsRun, false);
                m_Owner.m_NowRun = false;
            }

            var movePos = (m_CamPos.right * moveX + m_CamPos.forward * moveZ);
            movePos.y = 0f;
            movePos.Normalize();
            if (movePos == Vector3.zero)
            {
                m_Machine.ChangeState<Player_Idle>();
                return;
            }

            m_Owner.transform.rotation = Quaternion.Slerp(m_Owner.transform.rotation,
                Quaternion.LookRotation(movePos),
                m_RotateSpeed * deltaTime);

            if (!m_CharacterController.isGrounded)
            {
                m_GravityVec.y -= GRAVITY * Time.deltaTime;
            }

            m_CharacterController.Move((movePos + m_GravityVec) * (m_MoveSpeed * Time.deltaTime));
        }

        public override void OnStateExit()
        {
            m_Owner.m_NowRun = false;
            m_Machine.m_Animator.SetBool(m_IsMove, false);
            m_Machine.m_Animator.SetBool(m_IsRun, false);
        }
    }
}