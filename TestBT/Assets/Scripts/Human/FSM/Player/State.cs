using UnityEngine;

namespace FSM.Player
{
    public abstract class State<T>
    {
        internal readonly int m_StateToHash;
        protected StateMachine<T> m_Machine;
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

        internal void SetMachineAndContext(StateMachine<T> machine ,T owner)
        {
            m_Machine = machine;
            m_Owner = owner;
            ONInitialized();
        }

        protected virtual void ONInitialized()
        {}


        public virtual void OnStateEnter()
        {}


        public virtual void ChangePoint()
        {}


        public virtual void OnStateUpdate()
        {}
        
        public virtual void OnFixedUpdate(float deltaTime)
        {}


        public virtual void OnStateExit()
        {}
    }
}