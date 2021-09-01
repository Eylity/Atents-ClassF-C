namespace FSM
{
    public abstract class State
    {
        public abstract void OnStateEnter();
        public abstract void OnStateUpdate();
        public abstract void OnStateExit();

    }

    public enum EPlayerState
    {
        IDLE,
        ATTACK,
        FLY_ATTACK,
        FULL_SWING,
        SKILL,
        LENGTH
    }
}