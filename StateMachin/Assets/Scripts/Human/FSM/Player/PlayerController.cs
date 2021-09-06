using System;
using System.Collections;
using System.Collections.Generic;
using Human.PlayerScript;
using UnityEditor.VersionControl;
using UnityEngine;
using XftWeapon;

namespace Human.FSM.Player
{
    public enum EPlayerState
    {
        Idle,
        Move,
        Run,
        Attack,
        FlyAttack,
        FullSwing,
        Area,
        Exhausted,
        Die
    }
    
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController GetPlayerController { get; private set; }

        [HideInInspector] public CharacterController m_CharacterController;
        [HideInInspector] public Animator m_Anim;

        private readonly Dictionary<EPlayerState, State> m_DicState = new Dictionary<EPlayerState, State>();
        public EPlayerState m_CurState;
        
        private Vector3 m_Impact = Vector3.zero;
        private const float GRAVITY = 9.8f;
        private const float MASS = 3f;

        [HideInInspector] public bool m_ActiveFlyAttack = true;
        [HideInInspector] public bool m_ActiveFullSwing = true;
        [HideInInspector] public bool m_ActiveArea = true;
        [HideInInspector] public bool m_IsLive = true;
        [HideInInspector] public bool m_NowExhausted;

        [Header("----- Player Attack Collider -----")]
        [SerializeField] private BoxCollider m_AttackLeftCollider;
        public XWeaponTrail m_AttackLeftTrail;
        [SerializeField] private BoxCollider m_AttackRightCollider;
        public XWeaponTrail m_AttackRightTrail;

        [Header("----- Player Status -----")]
        [SerializeField] private float m_HealthPoint;
        [SerializeField] private float m_MaxHealthPoint = 100;
        [SerializeField] private float m_StaminaPoint;
        [SerializeField] private float m_MaxStaminaPoint = 200;
        [Range(5f, 20f)] public float m_SubOrPlusStamina = 10f;
        [SerializeField] private float m_PlayerDamage = 20f;

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

        private PlayerController()
        {
            m_DicState.Add(EPlayerState.Idle, new Player_Idle());
            m_DicState.Add(EPlayerState.Move, new Player_Idle());
            m_DicState.Add(EPlayerState.Run, new Player_Idle());
            m_DicState.Add(EPlayerState.Attack, new Player_Attack());
            m_DicState.Add(EPlayerState.FlyAttack, new Player_FlyAttack());
            m_DicState.Add(EPlayerState.FullSwing, new Player_FullSwing());
            m_DicState.Add(EPlayerState.Area, new Player_Area());
            m_DicState.Add(EPlayerState.Exhausted, new Player_Exhausted());
            m_DicState.Add(EPlayerState.Die, new Player_DIe());
        }

        private void Awake()
        {
            if (GetPlayerController != null && GetPlayerController != this)
            {
                Destroy(this);
            }

            GetPlayerController = this;
            m_CharacterController = GetComponent<CharacterController>();
            m_Anim = GetComponent<Animator>();
        }

        private void Start()
        {
            Health = m_MaxHealthPoint;
            Stamina = m_MaxStaminaPoint;
            StartCoroutine(nameof(State));
        }

        private void FixedUpdate()
        {
            m_DicState[m_CurState]?.OnStateFixedUpdate();
            m_CharacterController.Move(Vector3.down * (GRAVITY * Time.deltaTime));
        }

        private void Update()
        {
            m_DicState[m_CurState]?.OnStateUpdate();
            StaminaChange();

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                TakeDamage(35f);
            }

            if (m_Impact.magnitude > 0.2)
            {
                m_CharacterController.Move(m_Impact * Time.deltaTime);
            }

            m_Impact = Vector3.Lerp(m_Impact, Vector3.zero, 5 * Time.deltaTime);
        }


        public void AddImpact(Vector3 dir, float force)
        {
            dir.Normalize();
            if (dir.y < 0) dir.y = -dir.y;
            m_Impact += dir.normalized * force / MASS;
        }

        #region AnimEvents

        private void AttackTrue(string animName)
        {
            switch (animName)
            {
                case "AttackL":
                    CollSwitch(true, m_AttackLeftCollider);
                    break;
                case "AttackR":
                    CollSwitch(true, m_AttackRightCollider);
                    break;
                case "LastAttack":
                    CollSwitch(true);
                    break;
                case "FullSwing":
                    CollSwitch(true);
                    break;
                case "FlyAttack":
                    CollSwitch(true, m_AttackRightCollider);
                    break;
            }
        }

        private void AttackFalse(string animName)
        {
            switch (animName)
            {
                case "AttackL":
                    CollSwitch(false, m_AttackLeftCollider);
                    break;
                case "AttackR":
                    CollSwitch(false, m_AttackRightCollider);
                    break;
                case "LastAttack":
                    CollSwitch(false);
                    break;
                case "FullSwing":
                    CollSwitch(false);
                    break;
                case "FlyAttack":
                    CollSwitch(false, m_AttackRightCollider);
                    break;
            }
        }
        #endregion

        private IEnumerator State()
        {
            while (m_IsLive)
            {
                if (m_CurState == EPlayerState.Idle || m_CurState == EPlayerState.Move ||
                    m_CurState == EPlayerState.Run)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        yield return StartCoroutine(ChangeState(EPlayerState.Attack));
                    }

                    if (Input.GetKeyDown(KeyCode.Q) && m_ActiveFlyAttack && Stamina > 40f)
                    {
                        yield return StartCoroutine(ChangeState(EPlayerState.FlyAttack));
                    }

                    if (Input.GetKeyDown(KeyCode.E) && m_ActiveFullSwing && Stamina > 40f)
                    {
                        yield return StartCoroutine(ChangeState(EPlayerState.FullSwing));
                    }

                    if (Input.GetKeyDown(KeyCode.Space) && m_ActiveArea)
                    {
                        yield return StartCoroutine(ChangeState(EPlayerState.Area));
                    }
                }
                yield return null;
            }
        }

        public IEnumerator ChangeState(EPlayerState stateName)
        {
            if (m_CurState != stateName)
            {
                m_DicState[m_CurState]?.OnStateExit();
            }
            m_CurState = stateName;
            yield return StartCoroutine(m_DicState[m_CurState]?.OnStateEnter());
        }

        private void CollSwitch(bool isActive)
        {
            m_AttackLeftCollider.enabled = isActive;
            m_AttackRightCollider.enabled = isActive;
        }

        private void CollSwitch(bool isActive, Collider leftOrRight)
        {
            leftOrRight.enabled = isActive;
        }

        public void TakeDamage(float damage)
        {
            if (!m_IsLive) return;

            Health -= (int) Math.Round(damage);

            if (Health <= 0)
            {
                StartCoroutine(ChangeState(EPlayerState.Die));
            }
        }


        private void StaminaChange()
        {
            switch (m_CurState)
            {
                case EPlayerState.Run:
                    Stamina -= m_SubOrPlusStamina * 1.5f * Time.deltaTime;
                    break;
                case EPlayerState.Idle:
                    Stamina += m_SubOrPlusStamina * 1.5f * Time.deltaTime;
                    break;
                default:
                    Stamina += m_SubOrPlusStamina * Time.deltaTime;
                    break;
            }

            if (m_StaminaPoint <= 0 && !m_NowExhausted)
            {
                m_NowExhausted = true;
                ChangeState(EPlayerState.Exhausted);
            }
        }
    }
}