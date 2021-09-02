namespace FSM
{
    public interface IState
    {
        void OnStateEnter();
        void OnStateFixedUpdate();
        void OnStateUpdate();
        void OnStateExit();
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