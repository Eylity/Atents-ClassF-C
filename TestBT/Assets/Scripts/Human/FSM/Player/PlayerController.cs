using System;
using UnityEngine;
using XftWeapon;

namespace FSM.Player
{
    public enum EPlayerState
    {
        Idle,
        Move,
        Run,
        AttackL,
        AttackR,
        LastAttack,
        Area,
        FlyAttack,
        FullSwing,
        Exhausted,
        Die
    }
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController GetPlayerController { get; private set; }
        private StateMachine<PlayerController> m_StateMachine;
        
        [HideInInspector] public bool m_ActiveFlyAttack = true;
        [HideInInspector] public bool m_ActiveFullSwing = true;
        [HideInInspector] public bool m_ActiveArea = true;
        [HideInInspector] public bool m_IsLive = true;
        [HideInInspector] public bool m_NowExhausted;

        [SerializeField] internal EPlayerState m_CurState;
        private CharacterController m_CharacterController;
        private const float GRAVITY = 9.8f;

        [Header("----- Player Attack Trail -----")] 
        [SerializeField] internal XWeaponTrail m_AttackLeftTrail;
        [SerializeField] internal XWeaponTrail m_AttackRightTrail;

        [Header("----- Player Status -----")]
        [SerializeField] private float m_HealthPoint;
        [SerializeField] private float m_MaxHealthPoint = 100;
        [SerializeField] private float m_StaminaPoint;
        [SerializeField] private float m_MaxStaminaPoint = 200;
        [Range(5f, 20f)] public float m_SubOrPlusStamina = 10f;

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

            m_CharacterController = GetComponent<CharacterController>();
            GetPlayerController = this;
        }

        private void Start()
        {
            m_CurState = EPlayerState.Idle;
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

            Health = m_MaxHealthPoint;
            Stamina = m_MaxStaminaPoint;
        }

        private void Update()
        {
            m_CharacterController.Move(Vector3.down * (GRAVITY * Time.deltaTime));
            m_StateMachine.Update();
            StaminaChange();

            // Debug
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                TakeDamage(35f);
            }

            switch (m_CurState)
            {
                case EPlayerState.Idle:
                    m_StateMachine.ChangeState<Player_Idle>();
                    break;
                case EPlayerState.Move:
                    m_StateMachine.ChangeState<Player_Move>();
                    break;
                case EPlayerState.Run:
                    m_StateMachine.ChangeState<Player_Move>();
                    break;
                case EPlayerState.AttackL:
                    m_StateMachine.ChangeState<Player_AttackL>();
                    break;
                case EPlayerState.AttackR:
                    m_StateMachine.ChangeState<Player_AttackR>();
                    break;
                case EPlayerState.LastAttack:
                    m_StateMachine.ChangeState<Player_LastAttack>();
                    break;
                case EPlayerState.Area:
                    m_StateMachine.ChangeState<Player_Area>();
                    break;
                case EPlayerState.FlyAttack:
                    m_StateMachine.ChangeState<Player_FlyAttack>();
                    break;
                case EPlayerState.FullSwing:
                    m_StateMachine.ChangeState<Player_FullSwing>();
                    break;
                case EPlayerState.Exhausted:
                    m_StateMachine.ChangeState<Player_Exhausted>();
                    break;
                case EPlayerState.Die:
                    m_StateMachine.ChangeState<Player_DIe>();
                    break;
                default:
                    Debug.LogError($"Can't Find EPlayerState name : {m_CurState.ToString()} State");
                    break;
            }
        }

        private void FixedUpdate()
        {
            m_StateMachine.FixedUpdate(Time.deltaTime);
        }

        public void TakeDamage(float damage)
        {
            if (!m_IsLive) return;

            Health -= (int) Math.Round(damage);

            if (Health > 0)
            {
                return;
            }

            m_CurState = EPlayerState.Die;
        }

        private void StaminaChange()
        {
            Stamina = m_CurState switch
            {
                EPlayerState.Run => Stamina -= m_SubOrPlusStamina * Time.deltaTime,
                _ => Stamina += m_SubOrPlusStamina * Time.deltaTime,
            };

            if (m_StaminaPoint > 0 || m_NowExhausted)
            {
                return;
            }

            m_NowExhausted = true;
            m_CurState = EPlayerState.Exhausted;
        }
    }
}