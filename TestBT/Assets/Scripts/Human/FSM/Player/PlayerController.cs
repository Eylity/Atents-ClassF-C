using System;
using UnityEngine;

namespace FSM.Player
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController GetPlayerController { get; private set; }
        private StateMachine<PlayerController> m_StateMachine;
        public Status PlayerStat { get; private set; }
        
        [HideInInspector] public bool m_ActiveFlyAttack = true;
        [HideInInspector] public bool m_ActiveFullSwing = true;
        [HideInInspector] public bool m_ActiveArea = true;
        [HideInInspector] public bool m_NowExhausted;
        [HideInInspector] public bool m_NowRun;
        [HideInInspector] public bool m_IsLive = true;

        [SerializeField] private float m_MaxHp = 100f;
        [SerializeField] private float m_MaxStamina = 200f;
        private const float RUN_STAMINA = 10f;
        private const float DEFAULT_DAMAGE = 5f;
        [SerializeField] private bool m_Debug;

 
        private void Awake()
        {
            if (GetPlayerController != null && GetPlayerController != this)
            {
                Destroy(this);
            }

            PlayerStat = new Status(m_MaxHp, m_MaxStamina, RUN_STAMINA, DEFAULT_DAMAGE);
            GetPlayerController = this;
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

            if (m_Debug)
            {
                if (Input.GetKeyDown(KeyCode.CapsLock))
                {
                    PlayerStat.Stamina -= 50f;
                }

                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    TakeDamage(50f);
                }

                m_ActiveFlyAttack = true;
                m_ActiveFullSwing = true;
                m_ActiveArea = true;
            }
        }

        private void FixedUpdate() => m_StateMachine?.FixedUpdate(Time.deltaTime);

        public void TakeDamage(float damage)
        {
            if (!m_IsLive)
            {
                return;
            }

            PlayerStat.Health -= (int) Math.Round(damage);

            Debug.Log(PlayerStat.Health);
            if (PlayerStat.Health <= 0)
            {
                m_StateMachine.ChangeState<Player_DIe>();
            }
        }

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
    }
}