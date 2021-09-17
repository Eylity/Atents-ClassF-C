using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FSM.Player
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance { get; private set; }
        public Status PlayerStat { get; private set; }
        private StateMachine<PlayerController> m_StateMachine;
        
        // 스킬 쿨타임
        [HideInInspector] public bool m_ActiveFlyAttack = true;
        [HideInInspector] public bool m_ActiveFullSwing = true;
        [HideInInspector] public bool m_ActiveArea = true;
        
        // 현재상태 체크하는 변수
        [HideInInspector] public bool m_NowExhausted;
        [HideInInspector] public bool m_NowRun;
        [HideInInspector] public bool m_IsLive = true;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }

            PlayerStat = new Status();
            Instance = this;
        }

        private void Start()
        {
            var anim = GetComponent<Animator>();
            m_StateMachine = new StateMachine<PlayerController>(anim, this, new Player_Idle());
            m_StateMachine.AddState(new Player_Move());
            m_StateMachine.AddState(new Player_Attack());
            m_StateMachine.AddState(new Player_Area());
            m_StateMachine.AddState(new Player_FlyAttack());
            m_StateMachine.AddState(new Player_FullSwing());
            m_StateMachine.AddState(new Player_Exhausted());
            m_StateMachine.AddState(new Player_DIe());
        }

        private void Update()
        {
            m_StateMachine?.Update();
            StaminaChange();
        }

        private void FixedUpdate() => m_StateMachine?.FixedUpdate();

        public void TakeDamage(float damage)
        {
            if (!m_IsLive)
            {
                return;
            }

            PlayerStat.Health -= (int) Math.Round(damage);

            Debug.Log($"Current Player HP : {PlayerStat.Health}");
            if (PlayerStat.Health <= 0)
            {
                m_StateMachine.ChangeState<Player_DIe>();
            }
        }

        // m_NowRun 값에 따라 스태미너 회복 결정
        private void StaminaChange()
        {
            PlayerStat.Stamina = m_NowRun switch
            {
                true => PlayerStat.Stamina -= PlayerStat.m_RunStamina * Time.deltaTime,
                _ => PlayerStat.Stamina += PlayerStat.m_RunStamina * Time.deltaTime,
            };

            if (PlayerStat.Stamina <= 0 && !m_NowExhausted)
            {
                m_NowRun = false;
                m_StateMachine.ChangeState<Player_Exhausted>();
            }
        }

        [FoldoutGroup("Debug")][Button("Stamina")]
        private void DeBug_Stamina()
        {
            PlayerStat.Stamina -= 50f;
        }

        [FoldoutGroup("Debug")][Button("SkillCool")]
        private void Debug_Skill()
        {
            m_ActiveFlyAttack = true;
            m_ActiveFullSwing = true;
            m_ActiveArea = true;
        }
        [FoldoutGroup("Debug")][Button("TakeDamage")]
        private void Debug_TakeDamage()
        {
            TakeDamage(50f);
        }
    }
}