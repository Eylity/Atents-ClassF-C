using System.Collections;

namespace Human.FSM.Player
{
    public abstract class State
    {
        public virtual IEnumerator OnStateEnter()
        {
            yield return null;
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
        MOVE,
        RUN,
        ATTACK,
        FLY_ATTACK,
        FULL_SWING,
        SKILL,
        EXHAUSTED,
        DIE,
        LENGTH
    }
}