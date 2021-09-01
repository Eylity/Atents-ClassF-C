namespace FSM
{
    public class StateMachine
    {

        private State m_CurState;

        public void StateEnter()
        {
            m_CurState?.OnStateEnter();
        }

        public void StateUpdate()
        {
            m_CurState?.OnStateUpdate();
        }

        private void StateExit()
        {
            m_CurState.OnStateExit();
        }

        public void StateChange(State state)
        {
            if (m_CurState != state)
            {
                StateExit();
            }

            m_CurState = state;
            m_CurState?.OnStateEnter();
        }

        public void SetState(State state)
        {
            m_CurState = state;
        }

    }
}
