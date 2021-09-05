using UnityEngine;

namespace FSM.Player
{
    public class StateMachine
    {
        private PlayerController m_PlayerController;
        private State m_CurState;

        public void StateEnter()
        {
            if (m_CurState == null)
            {
                return;
            }

            m_PlayerController.StartCoroutine(m_CurState.OnStateEnter());
        }

        public void StateFixedUpdate()
        {
            m_CurState?.OnStateFixedUpdate();
        }

        public void StateUpdate()
        {
            m_CurState.OnStateUpdate();
        }

        private void StateExit()
        {
            m_CurState?.OnStateExit();
        }

        public void StateChange(State state)
        {
            if (m_CurState != state)
            {
                StateExit();
            }

            if (m_CurState == state)
            {
                return;
            }

            m_CurState = state;
            StateEnter();
        }

        public void SetState(State state, PlayerController player)
        {
            m_PlayerController = player;
            m_CurState = state;
        }
    }
}