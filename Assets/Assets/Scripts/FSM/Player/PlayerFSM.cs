using System;
using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;
using FSM.Player;

namespace FSM.Player
{
    internal enum ECoolDownSystem
    {
        FlyAttack,
        FullSwing,
        Skill
    }

    public class PlayerFSM : MonoBehaviour
    {
        private static readonly int Die = Animator.StringToHash("Die");
        private static readonly int IsRun = Animator.StringToHash("IsRun");
        private static readonly int IsMove = Animator.StringToHash("IsMove");
        private static readonly int Exhausted1 = Animator.StringToHash("Exhausted");
        private readonly Istate<PlayerFSM>[] m_ArrState = new Istate<PlayerFSM>[(int) EPlayerState.Length];
        private readonly WaitForSeconds m_FlyAttackCoolTime = new WaitForSeconds(5.0f);
        private readonly WaitForSeconds m_FullSwingCoolTime = new WaitForSeconds(6.0f);
        private readonly WaitForSeconds m_SkillCoolTime = new WaitForSeconds(6.0f);
        private readonly WaitForSeconds m_ExhaustedTime = new WaitForSeconds(10.0f);
        private StateMachine<PlayerFSM> m_State;
        private bool m_ActiveFlyAttack = true;
        private bool m_ActiveFullSwing = true;
        private bool m_ActiveSkill = true;
        private bool m_NowReady = true;
        private bool m_NowExhausted = false;
        private bool m_NowRun;
        private float m_MoveX;
        private float m_MoveZ;
        private float m_MoveSpeed;
        private float m_RotateSpeed;

        public Animator m_Anim;
        public Collider[] m_AttackCollider;
        public Rigidbody m_Rigidbody;
        public GameObject m_Skill;
        [Range(40f,200f)]
        public float m_Stamina = 100f;
        [Range(5f,20f)]
        public float m_SubStaminaSpeed = 10f;
        public float m_Health = 100;


        private void Awake()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            m_Anim = GetComponent<Animator>();
            m_AttackCollider = GetComponentsInChildren<BoxCollider>();
        }

        private void Start()
        {
            m_State.StateEnter();
            StartCoroutine(nameof(State));
        }

        public PlayerFSM()
        {
            Init();
        }

        public GameObject Test()
        {
            var obj = Instantiate(m_Skill, transform.position, Quaternion.identity);
            return obj;
        }

        private void Init()
        {
            m_State = new StateMachine<PlayerFSM>();
            m_ArrState[(int) EPlayerState.Idle] = new Player_Idle(this);
            m_ArrState[(int) EPlayerState.Attack] = new Player_Attack(this);
            m_ArrState[(int) EPlayerState.FlyAttack] = new Player_FlyAttack(this);
            m_ArrState[(int) EPlayerState.Skill] = new Player_Skill(this);
            m_ArrState[(int) EPlayerState.FullSwing] = new Player_FullSwing(this);

            m_State.SetState(m_ArrState[(int) EPlayerState.Idle], this);
        }

        void Update()
        {
            m_State.StateUpdate();
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
            Exhausted();
            Debug.Log(m_Stamina);
        }

        private void FixedUpdate()
        {
            Move();
        }

        private IEnumerator State()
        {
            while (true)
            {
                if (m_NowReady)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        m_State.StateChange(m_ArrState[(int) EPlayerState.Attack]);
                    }

                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        if (m_ActiveFlyAttack)
                        {
                            m_ActiveFlyAttack = false;
                            m_State.StateChange(m_ArrState[(int) EPlayerState.FlyAttack]);
                            CoolDown(ECoolDownSystem.FlyAttack);
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (m_ActiveFullSwing)
                        {
                            m_ActiveFullSwing = false;
                            m_State.StateChange(m_ArrState[(int) EPlayerState.FullSwing]);
                            CoolDown(ECoolDownSystem.FullSwing);
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        if (m_ActiveSkill)
                        {
                            m_ActiveSkill = false;
                            m_State.StateChange(m_ArrState[(int) EPlayerState.Skill]);
                            CoolDown(ECoolDownSystem.Skill);
                        }
                    }

                    if (Input.GetMouseButtonDown(1))
                    {
                        TakeDamage(100f);
                    }
                }

                yield return null;
            }
        }

        public void TakeDamage(float damage)
        {
            m_Health -= (float)Math.Round(damage);
            if (m_Health <= 0)
            {
                StartCoroutine(nameof(PlayerDead));
            }
        }
        
        private IEnumerator PlayerDead()
        {
            StopCoroutine(nameof(State));
            m_Anim.Rebind();
            m_Anim.SetTrigger(Die);
                while (m_Anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.9f)
                {
                    yield return null;
                }
                this.gameObject.SetActive(false);
        }

        #region Skill CoolDown
        
        private void CoolDown(ECoolDownSystem index)
        {
            switch (index)
            {
                case ECoolDownSystem.FullSwing:
                    StartCoroutine(nameof(FullSwingCoolDown));
                    break;
                case ECoolDownSystem.FlyAttack:
                    StartCoroutine(nameof(FlyAttackCoolDown));
                    break;
                case ECoolDownSystem.Skill:
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
                var x = Input.GetAxis("Horizontal");
                var z = Input.GetAxis("Vertical");
                if (x == 0 && z == 0)
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
                    m_NowRun = true;
                }
                else
                {
                    m_MoveSpeed = 2f;
                    m_RotateSpeed = 8f;
                    m_Anim.SetBool(IsRun, false);
                    m_NowRun = false;
                }

                m_Anim.SetBool(IsMove, true);

                var movePos = new Vector3(x, transform.position.y, z) * m_MoveSpeed * Time.deltaTime;
                transform.position += movePos;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movePos),
                    m_RotateSpeed * Time.deltaTime);
            }
            else
            {
                m_Anim.SetBool(IsMove, false);
                m_Anim.SetBool(IsRun, false);
            }
        }

        #endregion

        #region CheckExhausted

        private void Exhausted()
        {
            if (!m_NowRun)
            {
                if (m_Stamina >= 50)
                {
                    m_Stamina = 50;
                    return;
                }
                m_Stamina += m_SubStaminaSpeed * Time.deltaTime;
            }
            else
            {
                if (m_Stamina < 0)
                {
                    m_NowExhausted = true;
                    m_NowRun = false;
                    m_Anim.SetTrigger(Exhausted1);
                    StartCoroutine(nameof(ExhaustedTimer));
                }
                m_Stamina -= m_SubStaminaSpeed * 1.5f * Time.deltaTime;
            }
        }

        #endregion

        #region ExhaustedTimer

        private IEnumerator ExhaustedTimer()
        {
            yield return m_ExhaustedTime;
            m_NowExhausted = false;
        }

        #endregion
    }
}