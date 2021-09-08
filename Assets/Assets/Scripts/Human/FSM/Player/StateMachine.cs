using System.Collections.Generic;
using UnityEngine;

namespace FSM.Player
{
    public sealed class StateMachine<T>
    {
        private readonly T m_Context;

        private State<T> CurrentState { get; set; }

        private readonly Animator m_Animator;

        private readonly Dictionary<System.Type, State<T>> m_States = new Dictionary<System.Type, State<T>>();
        
        public StateMachine(Animator animator, T context, State<T> initialState)
        {
            this.m_Animator = animator;
            m_Context = context;
            AddState(initialState);
            CurrentState = initialState;
            CurrentState.OnStateEnter();
        }
        
        public void AddState(State<T> state)
        {
            state.SetMachineAndContext(this, m_Context);
            m_States[state.GetType()] = state;
        }
        
        public void Update(float deltaTime)
        {
            var currentStateInfo = m_Animator.GetCurrentAnimatorStateInfo(0);

            if (CurrentState.m_StateToHash == 0 || currentStateInfo.fullPathHash == CurrentState.m_StateToHash)
            {
                var tempState = CurrentState;
                CurrentState.ChangePoint();

                if (tempState == CurrentState)
                    CurrentState.OnStateUpdate(deltaTime, currentStateInfo);
            }
        }

        public void FixedUpdate(float deltaTime)
        {
            var currentStateInfo = m_Animator.GetCurrentAnimatorStateInfo(0);

            if (CurrentState.m_StateToHash == 0 || currentStateInfo.fullPathHash == CurrentState.m_StateToHash)
            {
                var tempState = CurrentState;
                CurrentState.ChangePoint();

                if (tempState == CurrentState)
                    CurrentState.OnFixedUpdate(deltaTime, currentStateInfo);
            }
        }
        
        public TR ChangeState<TR>() where TR : State<T>
        {
            var newType = typeof(TR);
            if (CurrentState.GetType() == newType)
                return CurrentState as TR;

            CurrentState.OnStateExit();

            CurrentState = m_States[newType];
            CurrentState.OnStateEnter();
            return CurrentState as TR;
        }
    }
}