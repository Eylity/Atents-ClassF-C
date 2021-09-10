using System.Collections;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace Human.FSM.Player
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
            
            if (Human.FSM.Player.PlayerController.GetPlayerController.m_CurState == EPlayerState.DIE)
            {
             yield break;;
            }
            Human.FSM.Player.PlayerController.GetPlayerController.m_CurState = EPlayerState.IDLE;
            yield return null;
        }

        public override void OnStateFixedUpdate()
        {
            if (!Human.FSM.Player.PlayerController.GetPlayerController.m_IsLive) return;
            
            m_MoveX = Input.GetAxis("Horizontal");
            m_MoveZ = Input.GetAxis("Vertical");
            if (m_MoveX == 0 && m_MoveZ == 0)
            {
                Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.SetBool(IsMove, false);
                Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.SetBool(IsRun, false);
                Human.FSM.Player.PlayerController.GetPlayerController.m_CurState = EPlayerState.IDLE;
                return;
            }

            if (Input.GetKey(KeyCode.LeftShift) && !Human.FSM.Player.PlayerController.GetPlayerController.m_NowExhausted)
            {
                m_MoveSpeed = 6f;
                m_RotateSpeed = 8f;
                Human.FSM.Player.PlayerController.GetPlayerController.m_CurState = EPlayerState.RUN;
                Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.SetBool(IsRun, true);
            }
            else
            {
                m_MoveSpeed = 2f;
                m_RotateSpeed = 8f;
                Human.FSM.Player.PlayerController.GetPlayerController.m_CurState = EPlayerState.MOVE;
                Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.SetBool(IsRun, false);
            }

            Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.SetBool(IsMove, true);


            Debug.Assert(Camera.main != null, "Camera.main != null");
            var camPos = Camera.main.transform;
            var movePos = camPos.right * m_MoveX + camPos.forward * m_MoveZ;
            movePos.y = 0f;
            movePos.Normalize();

            Human.FSM.Player.PlayerController.GetPlayerController.m_CharacterController.Move(movePos * (m_MoveSpeed * Time.deltaTime));
            Human.FSM.Player.PlayerController.GetPlayerController.transform.rotation = Quaternion.Slerp(Human.FSM.Player.PlayerController.GetPlayerController.transform.rotation,
                Quaternion.LookRotation(movePos),
                m_RotateSpeed * Time.deltaTime);
        }
        
        public override void OnStateExit()
        {
            Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.SetBool(IsMove, false);
            Human.FSM.Player.PlayerController.GetPlayerController.m_Anim.SetBool(IsRun, false);
        }
    }
}