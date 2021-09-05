using System.Collections;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace FSM.Player
{
    public class Player_Idle : State
    {
        private static readonly int IsMove = Animator.StringToHash("IsMove");
        private static readonly int IsRun = Animator.StringToHash("IsRun");
        private float m_MoveX;
        private float m_MoveZ;
        private float m_MoveSpeed;
        private float m_RotateSpeed;

        public override IEnumerator OnStateEnter()
        {
            PlayerController.GetPlayerController.m_CurState = EPlayerState.IDLE;
            yield return null;
        }

        public override void OnStateFixedUpdate()
        {
            m_MoveX = Input.GetAxis("Horizontal");
            m_MoveZ = Input.GetAxis("Vertical");
            if (m_MoveX == 0 && m_MoveZ == 0)
            {
                PlayerController.m_Anim.SetBool(IsMove, false);
                PlayerController.m_Anim.SetBool(IsRun, false);
                PlayerController.GetPlayerController.m_CurState = EPlayerState.IDLE;
                return;
            }

            if (Input.GetKey(KeyCode.LeftShift) && !PlayerController.GetPlayerController.m_NowExhausted)
            {
                m_MoveSpeed = 6f;
                m_RotateSpeed = 8f;
                PlayerController.GetPlayerController.m_CurState = EPlayerState.RUN;
                PlayerController.m_Anim.SetBool(IsRun, true);
            }
            else
            {
                m_MoveSpeed = 2f;
                m_RotateSpeed = 8f;
                PlayerController.GetPlayerController.m_CurState = EPlayerState.MOVE;
                PlayerController.m_Anim.SetBool(IsRun, false);
            }

            PlayerController.m_Anim.SetBool(IsMove, true);


            Debug.Assert(Camera.main != null, "Camera.main != null");
            var camPos = Camera.main.transform;
            var movePos = camPos.right * m_MoveX + camPos.forward * m_MoveZ;
            movePos.y = 0f;
            movePos.Normalize();

            PlayerController.m_CharacterController.Move(movePos * (m_MoveSpeed * Time.deltaTime));
            PlayerController.GetPlayerController.transform.rotation = Quaternion.Slerp(PlayerController.GetPlayerController.transform.rotation,
                Quaternion.LookRotation(movePos),
                m_RotateSpeed * Time.deltaTime);
        }
        
        public override void OnStateExit()
        {
            PlayerController.m_Anim.SetBool(IsMove, false);
            PlayerController.m_Anim.SetBool(IsRun, false);
        }
    }
}