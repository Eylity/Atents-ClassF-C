using System;
using System.Collections.Generic;
using UnityEngine;

namespace FSM.Player
{
    public sealed class StateMachine<T>
    {

        private State<T> CurrentState { get; set; }

        internal readonly Animator m_Animator;
        private readonly T m_Owner;
        private readonly Dictionary<Type, State<T>> m_States = new Dictionary<Type, State<T>>();



        public StateMachine(Animator animator, T owner, State<T> initialState)
        {
            this.m_Animator = animator;
            m_Owner = owner;
            AddState(initialState);
            CurrentState = initialState;
            CurrentState?.OnStateEnter();
        }

        public bool IsEnd()
        {
            var nowAnim = m_Animator.GetCurrentAnimatorStateInfo(0);
            return nowAnim.normalizedTime >= 1f && CurrentState.m_StateToHash == nowAnim.fullPathHash;
        }

        public void AddState(State<T> state)
        {
            state.SetMachineAndContext(this, m_Owner);
            m_States[state.GetType()] = state;
        }

        public void Update()
        {
            var currentStateInfo = m_Animator.GetCurrentAnimatorStateInfo(0);

            if (CurrentState.m_StateToHash == 0 || currentStateInfo.fullPathHash == CurrentState.m_StateToHash)
            {
                var tempState = CurrentState;
                CurrentState?.ChangePoint();
                if (tempState == CurrentState)
                    CurrentState?.OnStateUpdate();
            }
        }

        public void FixedUpdate(float deltaTime)
        {
            var currentStateInfo = m_Animator.GetCurrentAnimatorStateInfo(0);

            if (CurrentState.m_StateToHash == 0 || currentStateInfo.fullPathHash == CurrentState.m_StateToHash)
            {
                var tempState = CurrentState;
                CurrentState?.ChangePoint();
                if (tempState == CurrentState)
                    CurrentState?.OnFixedUpdate(deltaTime);
            }
        }

        public TR ChangeState<TR>() where TR : State<T>
        {
            var newType = typeof(TR);
            if (CurrentState.GetType() == newType)
            {
                return CurrentState as TR;
            }

            CurrentState?.OnStateExit();

            CurrentState = m_States[newType];
            CurrentState?.OnStateEnter();
            return CurrentState as TR;
        }
    }
}