using System;
using UnityEngine;
using XftWeapon;

namespace FSM.Player
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController GetPlayerController { get; private set; }
        private StateMachine<PlayerController> m_StateMachine;

        [HideInInspector] public bool m_ActiveFlyAttack = true;
        [HideInInspector] public bool m_ActiveFullSwing = true;
        [HideInInspector] public bool m_ActiveArea = true;
        [HideInInspector] public bool m_IsLive = true;
        [HideInInspector] public bool m_NowExhausted;
        [HideInInspector] public bool m_NowRun;

        public bool m_Debug = false;

        [Space] [Header("----- Player Attack Trail -----")]
        [SerializeField] internal XWeaponTrail m_AttackLeftTrail;
        [SerializeField] internal XWeaponTrail m_AttackRightTrail;

        [Space] [Header("----- Player Status -----")] [SerializeField]
        private float m_HealthPoint;

        [SerializeField] private float m_MaxHealthPoint = 100;
        [SerializeField] private float m_StaminaPoint;
        [SerializeField] private float m_MaxStaminaPoint = 200;
        [SerializeField] private float m_SubOrPlusStamina = 10f;


        public float Health
        {
            
            get => m_HealthPoint;
            set
            {
                if (!m_IsLive) return;

                m_HealthPoint = value;
                if (m_HealthPoint > m_MaxHealthPoint)
                {
                    m_HealthPoint = m_MaxHealthPoint;
                }
            }
        }

        public float Stamina
        {
            get => m_StaminaPoint;
            set
            {
                if (!m_IsLive) return;

                m_StaminaPoint = value;
                if (m_StaminaPoint >= m_MaxStaminaPoint)
                {
                    m_StaminaPoint = m_MaxStaminaPoint;
                }
            }
        }

        private void Awake()
        {
            if (GetPlayerController != null && GetPlayerController != this)
            {
                Destroy(this);
            }

            GetPlayerController = this;
            Stamina = m_MaxStaminaPoint;
            Health = m_MaxHealthPoint;
        }

        private void Start()
        {
            var anim = GetComponent<Animator>();
            m_StateMachine = new StateMachine<PlayerController>(anim, this, new Player_Idle());
            m_StateMachine.AddState(new Player_Move());
            m_StateMachine.AddState(new Player_AttackL());
            m_StateMachine.AddState(new Player_AttackR());
            m_StateMachine.AddState(new Player_LastAttack());
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
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    TakeDamage(35f);
                }

                if (Input.GetKeyDown(KeyCode.CapsLock))
                {
                    Stamina -= 50f;
                }

                m_ActiveFlyAttack = true;
                m_ActiveFullSwing = true;
                m_ActiveArea = true;
            }
        }

        private void FixedUpdate()
        {
            m_StateMachine?.FixedUpdate(Time.deltaTime);
        }

        public void TakeDamage(float damage)
        {
            if (!m_IsLive)
            {
                return;
            }

            Health -= (int) Math.Round(damage);

            if (Health <= 0)
            {
                m_StateMachine.ChangeState<Player_DIe>();
            }
        }

        private void StaminaChange()
        {
            Stamina = m_NowRun switch
            {
                true => Stamina -= m_SubOrPlusStamina * Time.deltaTime,
                _ => Stamina += m_SubOrPlusStamina * Time.deltaTime,
            };

            if (m_StaminaPoint <= 0 && !m_NowExhausted)
            {
                m_NowExhausted = true;
                m_NowRun = false;
                m_StateMachine.ChangeState<Player_Exhausted>();
            }
        }
    }
}