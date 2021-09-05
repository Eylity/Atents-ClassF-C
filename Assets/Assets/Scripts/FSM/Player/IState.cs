namespace FSM.Player
{
    public class IState
    {
        public virtual void OnStateEnter()
        {
            
        }

        public virtual void OnStateFixedUpdate()
        {
            
        }

        public virtual void OnStateUpdate()
        {
            
        }

        public virtual void OnStateExit()
        {
            
        }
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