namespace FSM
{
    public class StateMachine
    {

        private IState m_CurState;

        public void StateEnter()
        {
            m_CurState?.OnStateEnter();
        }

        public void StateFixedUpdate()
        {
            m_CurState?.OnStateFixedUpdate();
        }

        public void StateUpdate()
        {
            m_CurState?.OnStateUpdate();
        }

        private void StateExit()
        {
            m_CurState?.OnStateExit();
        }

        public void StateChange(IState state)
        {
            if (m_CurState != state)
            {
                StateExit();
            }

            m_CurState = state;
            m_CurState?.OnStateEnter();
        }

        public void SetState(IState state)
        {
            m_CurState = state;
        }

    }
}
