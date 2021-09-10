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
            m_CharacterController = m_Owner.GetComponent<CharacterController>();
            m_Anim = m_Owner.GetComponent<Animator>();
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
                m_Owner.m_CurState = EPlayerState.AttackL;
            }

            if (Input.GetKeyDown(KeyCode.Q) && m_Owner.Stamina > 40f && m_Owner.m_ActiveFlyAttack)
            {
                m_Owner.m_CurState = EPlayerState.FlyAttack;
            }

            if (Input.GetKeyDown(KeyCode.E) && m_Owner.Stamina > 40f && m_Owner.m_ActiveFullSwing)
            {
                m_Owner.m_CurState = EPlayerState.FullSwing;
            }

            if (Input.GetKeyDown(KeyCode.Space) && m_Owner.m_ActiveArea)
            {
                m_Owner.m_CurState = EPlayerState.Area;
            }

            if (m_IsNotInput)
            {
                m_Owner.m_CurState = EPlayerState.Idle;
            }
        }
        
        public override void OnFixedUpdate(float deltaTime, AnimatorStateInfo stateInfo)
        {
            if (!m_Owner.m_IsLive)
            {
                return;
            }

            m_MoveX = Input.GetAxis("Horizontal");
            m_MoveZ = Input.GetAxis("Vertical");

            m_Anim.SetBool(m_IsMove, true);

            if (Input.GetKey(KeyCode.LeftShift) && !m_Owner.m_NowExhausted)
            {
                m_MoveSpeed = 6f;
                m_RotateSpeed = 12f;
                m_Anim.SetBool(m_IsRun, true);
                m_Owner.m_CurState = EPlayerState.Run;
            }
            else
            {
                m_MoveSpeed = 4f;
                m_RotateSpeed = 8f;
                m_Anim.SetBool(m_IsRun, false);
                m_Owner.m_CurState = EPlayerState.Move;
            }

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
            m_Owner.transform.rotation = Quaternion.Slerp(m_Owner.transform.rotation,
                Quaternion.LookRotation(movePos),
                m_RotateSpeed * deltaTime);
        }

        public override void OnStateExit()
        {
            m_Anim.SetBool(m_IsMove, false);
            m_Anim.SetBool(m_IsRun, false);
        }
    }
}