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

    public class PlayerFsm : MonoBehaviour
    {
        private static readonly int Die = Animator.StringToHash("Die");
        private static readonly int IsRun = Animator.StringToHash("IsRun");
        private static readonly int IsMove = Animator.StringToHash("IsMove");
        private static readonly int Damage = Animator.StringToHash("TakeDamage");
        private static readonly int Exhausted1 = Animator.StringToHash("Exhausted");
        private readonly State[] m_ArrState = new State[(int) EPlayerState.LENGTH];
        private readonly WaitForSeconds m_FlyAttackCoolTime = new WaitForSeconds(5.0f);
        private readonly WaitForSeconds m_FullSwingCoolTime = new WaitForSeconds(6.0f);
        private readonly WaitForSeconds m_SkillCoolTime = new WaitForSeconds(6.0f);
        private readonly WaitForSeconds m_ExhaustedTime = new WaitForSeconds(10.0f);
        private StateMachine m_State;
        private bool m_ActiveFlyAttack = true;
        private bool m_ActiveFullSwing = true;
        private bool m_ActiveSkill = true;
        private bool m_NowReady = true;
        private bool m_NowExhausted;
        private float m_MoveX;
        private float m_MoveZ;
        private float m_MoveSpeed;
        private float m_RotateSpeed;

        [HideInInspector] public Animator m_Anim;
        [HideInInspector] public BoxCollider[] m_AttackColliders;
        [HideInInspector] public Rigidbody m_Rigidbody;

        [Header("----- Skill Spawn Prefab -----")]
        public GameObject m_Skill;

        [Header("----- Player Status -----")]
        [SerializeField]
        private int m_HealthPoint = 100;
        [Range(40f, 200f)] public float m_Stamina = 100f;
        [Range(5f, 20f)] public float m_SubStaminaSpeed = 10f;

        public int Health
        {
            get => m_HealthPoint;
            set
            {
                m_HealthPoint = value;
                if (m_HealthPoint >= 100)
                {
                    m_HealthPoint = 100;
                }
            }
        }


        #region Constructor

        public PlayerFsm()
        {
            Init();
        }

        private void Init()
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
            m_AttackColliders = GetComponentsInChildren<BoxCollider>();
        }

        private void Start()
        {
            m_State.StateEnter();
        }

        private void Update()
        {
            m_State.StateUpdate();
            ReadyCheck();
            Exhausted();
            State();
            
            if (Input.GetMouseButtonDown(1))
            {
                TakeDamage(100f);
            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                TakeDamage(35f);
            }
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Dragon"))
            {
                return;
            }

            CollSwitch(false);
            Debug.Log("Hit");
        }

        #region Now Ready Check

        private void ReadyCheck()
        {
            if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") ||
                m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Move") ||
                m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {
                m_NowReady = true;
            }
            else
            {
                m_NowReady = false;
            }
        }

        #endregion

        #region State

        private void State()
        {
            if (!m_NowReady) return;
            
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(nameof(AttackCheck));
                m_State.StateChange(m_ArrState[(int) EPlayerState.ATTACK]);
            }

            else if (Input.GetKeyDown(KeyCode.Q))
            {
                if (!m_ActiveFlyAttack) return;
                
                m_ActiveFlyAttack = false;
                m_State.StateChange(m_ArrState[(int) EPlayerState.FLY_ATTACK]);
                CoolDown(ECoolDownSystem.FLY_ATTACK);
            }

            else if (Input.GetKeyDown(KeyCode.E))
            {
                if (!m_ActiveFullSwing) return;
                
                m_ActiveFullSwing = false;
                m_State.StateChange(m_ArrState[(int) EPlayerState.FULL_SWING]);
                CoolDown(ECoolDownSystem.FULL_SWING);
            }

            else if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!m_ActiveSkill) return;
                
                m_ActiveSkill = false;
                m_State.StateChange(m_ArrState[(int) EPlayerState.SKILL]);
                CoolDown(ECoolDownSystem.SKILL);
            }
        }

        #endregion

        #region AttackCheck

        private IEnumerator AttackCheck()
        {
            yield return new WaitForSeconds(0.2f);
            while (true)
            {
                CollSwitch(true);
                while (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("AttackL")) yield return null;
                if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("AttackR"))
                {
                    CollSwitch(false);
                    yield break;
                }

                break;
            }

            while (true)
            {
                CollSwitch(true);
                while (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("AttackR")) yield return null;
                if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("LastAttack"))
                {
                    CollSwitch(false);
                    yield break;
                }

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
            for (var i = 0; i < m_AttackColliders.Length; i++)
            {
                m_AttackColliders[i].enabled = isActive;
            }
        }

        #endregion

        #region PlayerHit

        public void TakeDamage(float damage)
        {
            Health -= (int) Math.Round(damage);
            if (Health <= 0)
            {
                StartCoroutine(nameof(PlayerDead));
            }
            else if (damage >= 30)
            {
                m_Anim.SetTrigger(Damage);
            }
        }

        private IEnumerator PlayerDead()
        {
            m_Anim.Rebind();
            m_Anim.SetTrigger(Die);
            StopAllCoroutines();
            while (m_Anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.9f)
            {
                yield return null;
            }

            this.gameObject.SetActive(false);
        }

        #endregion

        #region Skill CoolDown

        private void CoolDown(ECoolDownSystem index)
        {
            switch (index)
            {
                case ECoolDownSystem.FULL_SWING:
                    StartCoroutine(nameof(FullSwingCoolDown));
                    break;
                case ECoolDownSystem.FLY_ATTACK:
                    StartCoroutine(nameof(FlyAttackCoolDown));
                    break;
                case ECoolDownSystem.SKILL:
                    StartCoroutine(nameof(SkillCoolDown));
                    break;
                default:
                    Debug.Log($"PlayerFsm - ECoolDownSystem - {index.ToString()}");
                    break;
            }
        }

        private IEnumerator FlyAttackCoolDown()
        {
            yield return m_FlyAttackCoolTime;
            m_ActiveFlyAttack = true;
        }

        private IEnumerator FullSwingCoolDown()
        {
            yield return m_FullSwingCoolTime;
            m_ActiveFullSwing = true;
        }

        private IEnumerator SkillCoolDown()
        {
            yield return m_SkillCoolTime;
            m_ActiveSkill = true;
        }

        #endregion

        #region PlayerMove

        private void Move()
        {
            if (m_NowReady)
            {
                m_MoveX = Input.GetAxis("Horizontal");
                m_MoveZ = Input.GetAxis("Vertical");
                if (m_MoveX == 0 && m_MoveZ == 0)
                {
                    m_Anim.SetBool(IsMove, false);
                    m_Anim.SetBool(IsRun, false);
                    return;
                }

                if (Input.GetKey(KeyCode.LeftShift) && !m_NowExhausted)
                {
                    m_MoveSpeed = 6f;
                    m_RotateSpeed = 8f;
                    m_Anim.SetBool(IsRun, true);
                }
                else
                {
                    m_MoveSpeed = 2f;
                    m_RotateSpeed = 8f;
                    m_Anim.SetBool(IsRun, false);
                }

                m_Anim.SetBool(IsMove, true);

                var playerTransform = transform;
                var position = playerTransform.position;
                var movePos = new Vector3(m_MoveX, position.y, m_MoveZ) * (m_MoveSpeed * Time.deltaTime);
                position += movePos;
                playerTransform.position = position;
                transform.rotation = Quaternion.Slerp(playerTransform.rotation, Quaternion.LookRotation(movePos),
                    m_RotateSpeed * Time.deltaTime);
            }
            else
            {
                m_Anim.SetBool(IsMove, false);
                m_Anim.SetBool(IsRun, false);
            }
        }

        #endregion

        #region Exhausted

        private void Exhausted()
        {
            if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {
                m_Stamina -= m_SubStaminaSpeed * Time.deltaTime;
                if (m_Stamina <= 0)
                {
                    m_NowExhausted = true;
                    m_Anim.SetTrigger(Exhausted1);
                    StartCoroutine(nameof(ExhaustedTimer));
                }
            }
            else
            {
                if (m_Stamina >= 50)
                {
                    m_Stamina = 50;
                    return;
                }

                m_Stamina += m_SubStaminaSpeed * Time.deltaTime;
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