using System;
using System.Collections.Generic;
using Human;
using UnityEngine;

namespace FSM.Player
{
    public sealed class StateMachine<T>
    {
        private readonly T m_Context;
        public event Action ONStateChanged;


        public State<T> CurrentState { get; private set; }

        public readonly Animator Animator;

        private readonly Dictionary<System.Type, State<T>> m_States = new Dictionary<System.Type, State<T>>();
        
        public StateMachine(Animator animator, T context, State<T> initialState)
        {
            this.Animator = animator;
            m_Context = context;
            AddState(initialState);
            CurrentState = initialState;
            CurrentState.Begin();
            Debug.Log("State After Begin");
        }
        
        public void AddState(State<T> state)
        {
            state.SetMachineAndContext(this, m_Context);
            m_States[state.GetType()] = state;
        }
        
        public void Update(float deltaTime)
        {
            var currentStateInfo = Animator.GetCurrentAnimatorStateInfo(0);

            if (CurrentState.m_StateToHash == 0 || currentStateInfo.fullPathHash == CurrentState.m_StateToHash)
            {
                var tempState = CurrentState;
                CurrentState.Reason();

                if (tempState == CurrentState)
                    CurrentState.Update(deltaTime, currentStateInfo);
            }
        }
        
        public TR ChangeState<TR>() where TR : State<T>
        {
            var newType = typeof(TR);
            if (CurrentState.GetType() == newType)
                return CurrentState as TR;

            CurrentState.End();

            CurrentState = m_States[newType];
            CurrentState.Begin();

            ONStateChanged?.Invoke();

            return CurrentState as TR;
        }
    }
}