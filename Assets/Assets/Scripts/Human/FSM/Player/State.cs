using System.Collections;
using System.Collections.Generic;

namespace Human.FSM.Player
{
    public abstract class State
    {
        public List<State> Next = new List<State>();

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