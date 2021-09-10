using UnityEngine;

namespace FSM.Player
{
    public abstract class State<T>
    {
        internal readonly int m_StateToHash;
        protected T m_Owner;


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
            m_Owner = context;
            ONInitialized();
        }

        protected virtual void ONInitialized()
        {}


        public virtual void OnStateEnter()
        {}


        public virtual void ChangePoint()
        {}


        public virtual void OnStateUpdate(AnimatorStateInfo stateInfo)
        {}
        
        public virtual void OnFixedUpdate(float deltaTime, AnimatorStateInfo stateInfo)
        {}


        public virtual void OnStateExit()
        {}
    }
}