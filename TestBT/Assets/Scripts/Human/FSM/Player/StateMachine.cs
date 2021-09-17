using System;
using System.Collections.Generic;
using UnityEngine;

namespace FSM.Player
{
    public class StateMachine<T>
    {
        private State<T> CurrentState { get; set; }
        private readonly Dictionary<Type, State<T>> m_States = new Dictionary<Type, State<T>>();
        private readonly T m_Owner;

        public readonly Animator m_Animator;

        public StateMachine(Animator animator, T owner, State<T> state)
        {
            this.m_Animator = animator;
            m_Owner = owner;
            AddState(state);
            CurrentState = state;
            CurrentState?.OnStateEnter();
        }

        // CurrentState 와 애니메이터의 애니메이션이 같고 애니메이션이 끝난지 확인하는 함수
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
            var currentStateInfo = m_Animator.GetCurrentAnimatorStateInfo(0).fullPathHash;

            // 현재 애니메이션과 애니메이터의 애니메이션이 같거나 상태에 따로 해쉬값을 정해주지 않았다면 ChangeState 호출 
            if (CurrentState.m_StateToHash == 0 || currentStateInfo == CurrentState.m_StateToHash)
            {
                // 현재상태를 담아둠
                var tempState = CurrentState;
                
                // 상태 변환조건 입력
                CurrentState?.ChangePoint();
                
                // 담아둔 상태와 현재의 상태를 비교
                if (tempState == CurrentState)
                    CurrentState?.OnStateUpdate();
            }
        }
        public void FixedUpdate()
        {
            var currentStateInfo = m_Animator.GetCurrentAnimatorStateInfo(0);

            if (CurrentState.m_StateToHash == 0 || currentStateInfo.fullPathHash == CurrentState.m_StateToHash)
            {
                var tempState = CurrentState;
                CurrentState?.ChangePoint();
                if (tempState == CurrentState)
                    CurrentState?.OnFixedUpdate();
            }
        }

        // 상태를 변환하되 제약을 걸어서 State만 올수있게 정의
        public TR ChangeState<TR>() where TR : State<T>
        {
            // 배열의 키값을 type 으로 선언하여서 확인
            var newType = typeof(TR);
            if (CurrentState.GetType() == newType)
            {
                // 상태가 같다면 제네릭 TR 로 형변환 하여 리턴
                return CurrentState as TR;
            }

            // 다르다면 Exit함수 호출후 변경 그후 Enter함수 호출
            CurrentState?.OnStateExit();

            CurrentState = m_States[newType];
            CurrentState?.OnStateEnter();
            return CurrentState as TR;
        }
    }
}