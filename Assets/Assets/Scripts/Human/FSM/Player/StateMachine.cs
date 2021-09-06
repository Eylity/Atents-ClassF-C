namespace Human.FSM.Player
{
    public class StateMachine
    {
        private Human.FSM.Player.PlayerController m_PlayerController;
        private State m_CurState;
        private State m_PrevState;

        public void StateEnter()
        {
            if (m_CurState == null)
            {
                return;
            }

            m_PlayerController.StartCoroutine(m_CurState.OnStateEnter());
        }

        public void ReVert()
        {
            m_PrevState = m_CurState;
            m_CurState = null;
            StateChange(m_PrevState);
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

            m_PrevState = m_CurState;

            m_CurState = state;
            StateEnter();
        }

        public void SetState(State state, Human.FSM.Player.PlayerController player)
        {
            m_PlayerController = player;
            m_CurState = state;
        }
    }
}