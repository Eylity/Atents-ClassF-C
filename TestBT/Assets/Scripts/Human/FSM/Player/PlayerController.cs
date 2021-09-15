using System;
using Sirenix.OdinInspector;
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
        [HideInInspector] public bool m_NowExhausted;
        [HideInInspector] public bool m_NowRun;
        [HideInInspector] public bool m_IsLive = true;

        private CharacterController m_CharacterController;
        private const float GRAVITY = 9.81f;
        private Vector3 m_GravityVec;
        [SerializeField] private bool m_Debug;

        [FoldoutGroup("Player Trail")] public XWeaponTrail m_AttackLeftTrail;
        [FoldoutGroup("Player Trail")] public XWeaponTrail m_AttackRightTrail;
        
        [FoldoutGroup("PlayerStatus")][SerializeField] private float m_HealthPoint;
        [FoldoutGroup("PlayerStatus")][SerializeField] private float m_MaxHealthPoint = 100;
        [FoldoutGroup("PlayerStatus")][SerializeField] private float m_StaminaPoint;
        [FoldoutGroup("PlayerStatus")][SerializeField] private float m_MaxStaminaPoint = 200;
        [FoldoutGroup("PlayerStatus")][SerializeField] private float m_RunStamina = 10f;
        [FoldoutGroup("PlayerStatus")][SerializeField] internal float m_PlayerDamage = 5f;

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

            m_CharacterController = GetComponent<CharacterController>();
            Stamina = m_MaxStaminaPoint;
            Health = m_MaxHealthPoint;
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
            if (!m_CharacterController.isGrounded)
            {
                m_GravityVec.y -= GRAVITY * Time.deltaTime;
                m_CharacterController.Move(m_GravityVec * Time.deltaTime);
            }
        }

        [Button]
        public void TakeDamage(float damage)
        {
            if (!m_IsLive)
            {
                return;
            }

            Health -= (int) Math.Round(damage);

            Debug.Log(Health);
            if (Health <= 0)
            {
                m_StateMachine.ChangeState<Player_DIe>();
            }
        }

        private void StaminaChange()
        {
            Stamina = m_NowRun switch
            {
                true => Stamina -= m_RunStamina * Time.deltaTime,
                _ => Stamina += m_RunStamina * Time.deltaTime,
            };

            if (m_StaminaPoint <= 0 && !m_NowExhausted)
            {
                m_NowRun = false;
                m_StateMachine.ChangeState<Player_Exhausted>();
            }
        }
    }
}