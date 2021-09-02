using System;
using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    internal enum ECoolDownSystem
    {
        FLY_ATTACK,
        FULL_SWING,
        SKILL
    }

    public class PlayerController : MonoBehaviour
    {
        private static readonly int Exhausted = Animator.StringToHash("Exhausted");
        private static readonly int Damage = Animator.StringToHash("TakeDamage");
        private static readonly int Die = Animator.StringToHash("Die");
        private readonly IState[] m_ArrState = new IState[(int) EPlayerState.LENGTH];
        private readonly WaitForSeconds m_FullSwingCoolTime = new WaitForSeconds(7.0f);
        private readonly WaitForSeconds m_FlyAttackCoolTime = new WaitForSeconds(5.0f);
        private readonly WaitForSeconds m_ExhaustedTime = new WaitForSeconds(10.0f);
        private readonly WaitForSeconds m_SkillCoolTime = new WaitForSeconds(6.0f);
        private readonly WaitForSeconds m_AnimDelay = new WaitForSeconds(0.2f);
        private readonly StateMachine m_State;
        private bool m_ActiveFlyAttack = true;
        private bool m_ActiveFullSwing = true;
        private bool m_ActiveSkill = true;

        [HideInInspector] public Rigidbody m_Rigidbody;
        [HideInInspector] public Animator m_Anim;
        [HideInInspector] public bool m_NowReady = true;
        [HideInInspector] public bool m_IsLive = true;
        [HideInInspector] public bool m_NowExhausted;
        
        [Header("----- Player Attack Collider -----")]
        [SerializeField] private BoxCollider m_AttackLeftCollider;
        [SerializeField] private BoxCollider m_AttackRightCollider;

        [Header("----- Skill Spawn Prefab -----")]
        public GameObject m_Skill;

        [Header("----- Player Status -----")] [SerializeField]
        private float m_HealthPoint = 100;

        public float m_PlayerDamage = 20f;
        [SerializeField] private float m_StaminaPoint = 200f;
        [SerializeField] private int m_StunDamage = 30;
        [Range(5f, 20f)] public float m_SubOrPlusStamina = 10f;

        public float Health
        {
            get => m_HealthPoint;
            set
            {
                m_HealthPoint = value;
                if (m_HealthPoint >= 100)
                {
                    m_HealthPoint = 100f;
                }
                else if (m_HealthPoint <= 0)
                {
                    StopAllCoroutines();
                    StartCoroutine(nameof(PlayerDead));
                }
            }
        }

        public float Stamina
        {
            get => m_StaminaPoint;
            set
            {
                m_StaminaPoint = value;
                if (m_StaminaPoint <= 0 && !m_NowExhausted)
                {
                    m_NowExhausted = true;
                    m_Anim.SetTrigger(Exhausted);
                    StartCoroutine(nameof(ExhaustedTimer));
                }
                else
                {
                    if (m_StaminaPoint >= 200f)
                    {
                        m_StaminaPoint = 200f;
                    }
                }
            }
        }


        #region Constructor

        private PlayerController()
        {
            m_State = new StateMachine();
            m_ArrState[(int) EPlayerState.IDLE] = new Player_Idle(this);
            m_ArrState[(int) EPlayerState.ATTACK] = new Player_Attack(this);
            m_ArrState[(int) EPlayerState.FLY_ATTACK] = new Player_FlyAttack(this);
            m_ArrState[(int) EPlayerState.FULL_SWING] = new Player_FullSwing(this);
            m_ArrState[(int) EPlayerState.SKILL] = new Player_Skill(this);

            m_State.SetState(m_ArrState[(int) EPlayerState.IDLE]);
        }

        #endregion

        private void Awake()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            m_Anim = GetComponent<Animator>();
        }

        private void Start()
        {
            m_State.StateEnter();
            StartCoroutine(nameof(State));
        }

        private void FixedUpdate()
        {
            m_State.StateFixedUpdate();
        }

        private void Update()
        {
            m_State.StateUpdate();
            StaminaChange();

            if (Input.GetMouseButtonDown(1))
            {
                TakeDamage(100f);
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                TakeDamage(35f);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Dragon"))
            {
                return;
            }

            Debug.Log("Hit");
            CollSwitch(false);
        }

        #region State

        private IEnumerator State()
        {
            while (true)
            {
                switch (m_NowReady)
                {
                    case true when Input.GetMouseButtonDown(0):
                        m_NowReady = false;
                        StartCoroutine(nameof(AttackCheck));
                        m_State.StateChange(m_ArrState[(int) EPlayerState.ATTACK]);
                        
                        break;
                    case true when Input.GetKeyDown(KeyCode.Q):
                    {
                        if (m_ActiveFlyAttack)
                        {
                            Stamina -= 40f;
                            m_NowReady = false;
                            m_ActiveFlyAttack = false;
                            m_State.StateChange(m_ArrState[(int) EPlayerState.FLY_ATTACK]);
                            StartCoroutine(CoolDown(ECoolDownSystem.FLY_ATTACK));
                        }

                        break;
                    }
                    case true when Input.GetKeyDown(KeyCode.E):
                    {
                        if (m_ActiveFullSwing)
                        {
                            Stamina -= 40f;
                            m_NowReady = false;
                            m_ActiveFullSwing = false;
                            m_State.StateChange(m_ArrState[(int) EPlayerState.FULL_SWING]);
                            StartCoroutine(CoolDown(ECoolDownSystem.FULL_SWING));
                        }

                        break;
                    }
                    case true when Input.GetKeyDown(KeyCode.Space):
                    {
                        if (m_ActiveSkill)
                        {
                            m_NowReady = false;
                            m_ActiveSkill = false;
                            m_State.StateChange(m_ArrState[(int) EPlayerState.SKILL]);
                            StartCoroutine(CoolDown(ECoolDownSystem.SKILL));
                        }

                        break;
                    }
                    case false:
                    {
                        yield return m_AnimDelay;
                        if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") ||
                            m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Move") ||
                            m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                        {
                            m_State.StateChange(m_ArrState[(int) EPlayerState.IDLE]);
                            m_NowReady = true;
                        }

                        break;
                    }
                }
                yield return null;
            }
        }

        #endregion

        #region AttackCheck

        private IEnumerator AttackCheck()
        {
            yield return m_AnimDelay;
            while (true)
            {
                CollSwitch(true, m_AttackLeftCollider);
                while (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("AttackL")) yield return null;
                if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("AttackR"))
                {
                    CollSwitch(false);
                    yield break;
                }

                CollSwitch(false);

                break;
            }

            while (true)
            {
                CollSwitch(true, m_AttackRightCollider);
                while (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("AttackR")) yield return null;
                if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("LastAttack"))
                {
                    CollSwitch(false);
                    yield break;
                }

                CollSwitch(false);

                break;
            }

            while (true)
            {
                CollSwitch(true);
                while (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("LastAttack")) yield return null;
                CollSwitch(false);
                yield break;
            }
        }

        public void CollSwitch(bool isActive)
        {
            m_AttackLeftCollider.enabled = isActive;
            m_AttackRightCollider.enabled = isActive;
        }

        private void CollSwitch(bool isActive, Collider leftOrRight)
        {
            leftOrRight.enabled = isActive;
        }

        #endregion

        #region PlayerHit

        public void TakeDamage(float damage)
        {
            Health -= (int) Math.Round(damage);
            if (damage < m_StunDamage || Health <= 0) return;
            m_Anim.SetTrigger(Damage);
            m_NowReady = false;
        }

        private IEnumerator PlayerDead()
        {
            m_IsLive = false;
            m_Anim.SetTrigger(Die);
            while (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Die")) yield return null;
            var player = GetComponent<PlayerController>();
            player.enabled = false;
            while (m_Anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.9f) yield return null;

            this.gameObject.SetActive(false);
        }

        #endregion

        #region Skill CoolDown

        private IEnumerator CoolDown(ECoolDownSystem index)
        {
            switch (index)
            {
                case ECoolDownSystem.FULL_SWING:
                    yield return m_FullSwingCoolTime;
                    m_ActiveFullSwing = true;
                    break;
                case ECoolDownSystem.FLY_ATTACK:
                    yield return m_FlyAttackCoolTime;
                    m_ActiveFlyAttack = true;
                    break;
                case ECoolDownSystem.SKILL:
                    yield return m_SkillCoolTime;
                    m_ActiveSkill = true;
                    break;
                default:
                    Debug.Log($"Can't Find : PlayerFsm - ECoolDownSystem - {index.ToString()}");
                    break;
            }
        }

        #endregion

        #region Exhausted

        private void StaminaChange()
        {
            if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {
                Stamina -= m_SubOrPlusStamina * 1.5f * Time.deltaTime;
            }
            else
            {
                Stamina += m_SubOrPlusStamina * Time.deltaTime;
            }
        }

        private IEnumerator ExhaustedTimer()
        {
            yield return m_ExhaustedTime;
            m_NowExhausted = false;
        }

        #endregion
    }
}