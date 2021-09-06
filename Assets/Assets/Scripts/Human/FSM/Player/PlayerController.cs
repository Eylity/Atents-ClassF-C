using System;
using System.Collections;
using Human.PlayerScript;
using UnityEditor.VersionControl;
using UnityEngine;
using XftWeapon;

namespace Human.FSM.Player
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController GetPlayerController { get; private set; }

        [HideInInspector] public CharacterController m_CharacterController;
        [HideInInspector] public Animator m_Anim;

        private readonly State[] m_ArrState = new State[(int) EPlayerState.LENGTH];
        private readonly StateMachine m_State;
        private const float MASS = 3f;
        private const float GRAVITY = 9.8f;
        private Vector3 m_Impact = Vector3.zero;

        public EPlayerState m_CurState;
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
            m_State = new StateMachine();
            m_ArrState[(int) EPlayerState.IDLE] = new Player_Idle();
            m_ArrState[(int) EPlayerState.ATTACK] = new Player_Attack();
            m_ArrState[(int) EPlayerState.FLY_ATTACK] = new Player_FlyAttack();
            m_ArrState[(int) EPlayerState.FULL_SWING] = new Player_FullSwing();
            m_ArrState[(int) EPlayerState.SKILL] = new Player_Area();
            m_ArrState[(int) EPlayerState.EXHAUSTED] = new Player_Exhausted();
            m_ArrState[(int) EPlayerState.DIE] = new Player_DIe();

            m_State.SetState(m_ArrState[(int) EPlayerState.IDLE], this);
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
            m_State.StateEnter();
            Health = m_MaxHealthPoint;
            Stamina = m_MaxStaminaPoint;
            StartCoroutine(nameof(State));
        }

        private void FixedUpdate()
        {
            m_State.StateFixedUpdate();
        }

        private void Update()
        {
            m_CharacterController.Move(Vector3.down * (GRAVITY * Time.deltaTime));

            m_State.StateUpdate();
            StaminaChange();

            // Debug
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

        // State Name "FlyAttack"
        private void IsGround()
        {
            var obj = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.FlyAttackDust);
            obj.transform.position = transform.position;
            ObjPool.ObjectPoolInstance.ReturnObject(obj, EPrefabsName.FlyAttackDust, 1f);
        }
        #endregion 

        private IEnumerator State()
        {
            while (m_IsLive)
            {
                if (m_CurState == EPlayerState.IDLE || m_CurState == EPlayerState.MOVE ||
                    m_CurState == EPlayerState.RUN)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        m_State.StateChange(m_ArrState[(int) EPlayerState.ATTACK]);
                    }

                    if (Input.GetKeyDown(KeyCode.Q) && m_ActiveFlyAttack && Stamina > 40f)
                    {
                        m_State.StateChange(m_ArrState[(int) EPlayerState.FLY_ATTACK]);
                    }

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (m_ActiveFullSwing && Stamina > 40f)
                        {
                            m_State.StateChange(m_ArrState[(int) EPlayerState.FULL_SWING]);
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        if (m_ActiveArea)
                        {
                            m_State.StateChange(m_ArrState[(int) EPlayerState.SKILL]);
                        }
                    }
                }
                yield return null;
            }
        }

        public void ChangeState(EPlayerState stateName)
        {
            for (var i = 0; i < (int) EPlayerState.LENGTH; i++)
            {
                if ((int) stateName == i)
                {
                    m_State.StateChange(m_ArrState[i]);
                }
            }
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
                ChangeState(EPlayerState.DIE);
            }
        }


        private void StaminaChange()
        {
            switch (m_CurState)
            {
                case EPlayerState.RUN:
                    Stamina -= m_SubOrPlusStamina * 1.5f * Time.deltaTime;
                    break;
                case EPlayerState.IDLE:
                    Stamina += m_SubOrPlusStamina * 1.5f * Time.deltaTime;
                    break;
                default:
                    Stamina += m_SubOrPlusStamina * Time.deltaTime;
                    break;
            }

            if (m_StaminaPoint <= 0 && !m_NowExhausted)
            {
                m_NowExhausted = true;
                m_State.StateChange(m_ArrState[(int)EPlayerState.EXHAUSTED]);
            }
        }
    }
}