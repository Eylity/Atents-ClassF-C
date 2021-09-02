using System;
using System.Collections;
using FSM;
using FSM.Player;
using UnityEngine;

internal enum ECoolDownSystem
{
    FLY_ATTACK,
    FULL_SWING,
    SKILL,
    EXHAUSTED
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
    private readonly WaitForSeconds m_AnimDelay = new WaitForSeconds(0.3f);
    private readonly StateMachine m_State;
    private bool m_ActiveFlyAttack = true;
    private bool m_ActiveFullSwing = true;
    private bool m_ActiveSkill = true;

    [HideInInspector] public Rigidbody m_Rigidbody;
    [HideInInspector] public Animator m_Anim;
    [HideInInspector] public bool m_NowReady = true;
    [HideInInspector] public bool m_IsLive = true;
    [HideInInspector] public bool m_NowExhausted;
    // public Camera m_CameraFollow;
    // public CharacterController m_CharacterController;
        
    [Header("----- Player Attack Collider -----")]
    [SerializeField] private BoxCollider m_AttackLeftCollider;
    [SerializeField] private BoxCollider m_AttackRightCollider;
        
    [Header("----- Player Status -----")]
    [SerializeField] private float m_HealthPoint = 100;

    public float m_PlayerDamage = 20f;
    [SerializeField] private float m_StaminaPoint = 200f;
    [SerializeField] private int m_StunDamage = 30;
    [Range(5f, 20f)] public float m_SubOrPlusStamina = 10f;

    #region Health And Stamina

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
            else if (m_HealthPoint <= 0 && m_IsLive)
            {
                m_HealthPoint = 0f;
                StopAllCoroutines();
                m_IsLive = false;
                m_Anim.SetTrigger(Die);
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
                m_NowReady = false;
                m_NowExhausted = true;
                m_Anim.SetTrigger(Exhausted);
                StartCoroutine(CoolDown(ECoolDownSystem.EXHAUSTED));
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

    #endregion
        
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

    #region Animation Events
        
    private void AttackTrue(string animName)
    {
        switch (animName)
        {
            case "AttackL":
                CollSwitch(true,m_AttackLeftCollider);
                break;
            case "AttackR":
                CollSwitch(true,m_AttackRightCollider);
                break;
            case "LastAttack":
                CollSwitch(true);
                break;
            case "FullSwing":
                CollSwitch(true);
                break;
            case "FlyAttack":
                CollSwitch(true);
                break;
        }
    }

    private void AttackFalse(string animName)
    {
        switch (animName)
        {
            case "AttackL":
                CollSwitch(false,m_AttackLeftCollider);
                break;
            case "AttackR":
                CollSwitch(false,m_AttackRightCollider);
                break;
            case "LastAttack":
                CollSwitch(false);
                break;
            case "FullSwing":
                CollSwitch(false);
                break;
            case "FlyAttack":
                CollSwitch(false);
                break;
                    
        }
    }
        
    // Animation Event State Name "Die"
    private void PlayerDead()
    {
        this.gameObject.SetActive(false);
    }
        
    #endregion

    #region State

    private IEnumerator State()
    {
        while (true)
        {
            switch (m_NowReady)
            {
                case true when Input.GetMouseButtonDown(0):
                    m_NowReady = false;
                    m_State.StateChange(m_ArrState[(int) EPlayerState.ATTACK]);
                        
                    break;
                case true when Input.GetKeyDown(KeyCode.Q):
                {
                    if (m_ActiveFlyAttack && Stamina > 40f)
                    {
                        m_State.StateChange(m_ArrState[(int) EPlayerState.FLY_ATTACK]);
                        m_NowReady = false;
                        Stamina -= 40f;
                        m_ActiveFlyAttack = false;
                        StartCoroutine(CoolDown(ECoolDownSystem.FLY_ATTACK));
                    }

                    break;
                }
                case true when Input.GetKeyDown(KeyCode.E):
                {
                    if (m_ActiveFullSwing && Stamina > 40f)
                    {
                        m_State.StateChange(m_ArrState[(int) EPlayerState.FULL_SWING]);
                        m_NowReady = false;
                        Stamina -= 40f;
                        m_ActiveFullSwing = false;
                        StartCoroutine(CoolDown(ECoolDownSystem.FULL_SWING));
                    }

                    break;
                }
                case true when Input.GetKeyDown(KeyCode.Space):
                {
                    if (m_ActiveSkill)
                    {
                        m_State.StateChange(m_ArrState[(int) EPlayerState.SKILL]);
                        m_NowReady = false;
                        m_ActiveSkill = false;
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

    #region CollSwitch

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
        if (Health <= 0) return;
        Health -= (int) Math.Round(damage);
        if (damage > m_StunDamage && Health <= 0) return;
        m_Anim.SetTrigger(Damage);
        m_NowReady = false;
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
            case ECoolDownSystem.EXHAUSTED:
                yield return m_ExhaustedTime;
                m_NowExhausted = false;
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
        
    #endregion
}