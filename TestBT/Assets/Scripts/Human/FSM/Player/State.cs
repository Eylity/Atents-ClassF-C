using UnityEngine;

namespace FSM.Player
{
    public abstract class State<T>
    {
        internal readonly int m_StateToHash;
        private T m_Context;


        protected State()
        {
        }

        protected State(string animStateName) : this(Animator.StringToHash(animStateName))
        {
        }

        private State(int animStateHash)
        {
            this.m_StateToHash = animStateHash;
        }


        internal void SetMachineAndContext(T context)
        {
            m_Context = context;
            ONInitialized();
        }

        protected virtual void ONInitialized()
        {}


        public virtual void OnStateEnter()
        {}


        public virtual void ChangePoint()
        {}


        public virtual void OnStateUpdate(float deltaTime, AnimatorStateInfo stateInfo)
        {}
        
        public virtual void OnFixedUpdate(float deltaTime, AnimatorStateInfo stateInfo)
        {}


        public virtual void OnStateExit()
        {}
    }
}