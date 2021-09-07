using System.Collections.Generic;
using UnityEngine;
using Human;


namespace Human
{
    public abstract class State<T>
    {
        internal int m_StateToHash;
        protected StateMachine<T> Machine;
        protected T Context;


        public State()
        {
        }
        
        public State(string mecanimStateName) : this(Animator.StringToHash(mecanimStateName))
        {
        }
        
        public State(int mecanimStateHash)
        {
            this.m_StateToHash = mecanimStateHash;
        }


        internal void SetMachineAndContext(StateMachine<T> machine, T context)
        {
            Machine = machine;
            Context = context;
            ONInitialized();
        }
        
        public virtual void ONInitialized()
        {
        }


        public virtual void Begin()
        {
        }


        public virtual void Reason()
        {
        }


        public abstract void Update(float deltaTime, AnimatorStateInfo stateInfo);


        public virtual void End()
        {
        }
    }
}