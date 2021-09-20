using System.Collections.Generic;
using UnityEngine;

namespace FSM.Player
{
    public abstract class State<T>
    {
        // 해니메이션 해쉬값
        internal readonly int stateToHash;
        protected List<State<T>> nextState = new List<State<T>>(); 

        // 스테이트머신
        protected StateMachine<T> machine;
        
        // 사용하는 오브젝트
        protected T owner;

        // 해쉬값이 필요없을시 오버로딩
        protected State()
        {
        }
        // 생성과 동시에 해쉬값 적용
        protected State(string animStateName) : this(Animator.StringToHash(animStateName))
        {
        }

        private State(int animStateHash) => this.stateToHash = animStateHash;
        
        // 초기화시 한번만 호출
        internal void SetMachineAndContext(StateMachine<T> machine, T owner)
        {
            this.machine = machine;
            this.owner = owner;
            ONInitialized();
        }

        // 초기화시 한번만 호출
        protected virtual void ONInitialized()
        {
        }
        public virtual void OnStateEnter()
        {
        }
        public virtual void ChangePoint()
        {
        }
        public virtual void OnStateUpdate()
        {
        }
        public virtual void OnFixedUpdate()
        {
        }
        public virtual void OnStateExit()
        {
        }
    }
}