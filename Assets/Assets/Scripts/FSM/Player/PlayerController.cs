using System;
using System.Collections;
using FSM;
using FSM.Player;
using Skill;
using UnityEngine;
using XftWeapon;

internal enum ECoolDownSystem
{
    FLY_ATTACK,
    FULL_SWING,
    AREA,
    EXHAUSTED
}

public class PlayerController : MonoBehaviour
{
    public static PlayerController GetPlayerController { get; private set; }
    
    private static readonly int Exhausted = Animator.StringToHash("Exhausted");
    private static readonly int Damage = Animator.StringToHash("TakeDamage");
    private static readonly int Die = Animator.StringToHash("Die");
    private readonly IState[] m_ArrState = new IState[(int) EPlayerState.LENGTH];
    private readonly WaitForSeconds m_FullSwingCoolTime = new WaitForSeconds(7.0f);
    private readonly WaitForSeconds m_FlyAttackCoolTime = new WaitForSeconds(5.0f);
    private readonly WaitForSeconds m_ExhaustedTime = new WaitForSeconds(10.0f);
    private readonly WaitForSeconds m_AreaCoolTime = new WaitForSeconds(6.0f);
    private readonly WaitForSeconds m_AnimDelay = new WaitForSeconds(0.3f);
    private readonly StateMachine m_State;
    private const float MASS = 3f;
    private bool m_ActiveFlyAttack = true;
    private bool m_ActiveFullSwing = true;
    private bool m_ActiveArea = true;
    public CharacterController m_CharacterController;
    private Vector3 m_Impact = Vector3.zero;
    private float m_Gravity = 9.8f;


    [HideInInspector] public Animator m_Anim;
    [HideInInspector] public bool m_NowReady = true;
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
    [SerializeField] private int m_StunDamage = 30;

    #region Health And Stamina

    public float Health
    {
        get => m_HealthPoint;
        set
        {
            m_HealthPoint = value;
            if (m_HealthPoint >= m_MaxHealthPoint)
            {
                m_HealthPoint = m_MaxHealthPoint;
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
            if (!m_IsLive) return;
            
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
                if (m_StaminaPoint >= m_MaxStaminaPoint)
                {
                    m_StaminaPoint = m_MaxStaminaPoint;
                }
            }
        }
    }

    #endregion
        
    #region Constructor

    private PlayerController()
    {
        m_State = new StateMachine();
        m_ArrState[(int) EPlayerState.IDLE] = new Player_Idle();
        m_ArrState[(int) EPlayerState.ATTACK] = new Player_Attack();
        m_ArrState[(int) EPlayerState.FLY_ATTACK] = new Player_FlyAttack();
        m_ArrState[(int) EPlayerState.FULL_SWING] = new Player_FullSwing();
        m_ArrState[(int) EPlayerState.SKILL] = new Player_Area();

        m_State.SetState(m_ArrState[(int) EPlayerState.IDLE]);
    }

    #endregion

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
        m_HealthPoint = m_MaxHealthPoint;
        m_StaminaPoint = m_MaxStaminaPoint;
        StartCoroutine(nameof(State));
    }

    private void FixedUpdate()
    {
        m_State.StateFixedUpdate();
    }

    private void Update()
    {
        m_CharacterController.Move(Vector3.down * m_Gravity * Time.deltaTime);
        
        m_State.StateUpdate();
        StaminaChange();

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TakeDamage(35f);
        }
        
        
        if (m_Impact.magnitude > 0.2)
        {
            m_CharacterController.Move(m_Impact * Time.deltaTime);
        }
        m_Impact = Vector3.Lerp(m_Impact, Vector3.zero, 5*Time.deltaTime);
    }

    
    public void AddImpact(Vector3 dir, float force)
    {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y;
        m_Impact += dir.normalized * force / MASS;
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
                CollSwitch(true, m_AttackRightCollider);
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
                CollSwitch(false,m_AttackRightCollider);
                break;
        }
    }
    
    // Animation Event State Name "FlyAttack"
    private void IsGround()
    {
        Debug.Log("Spawn FlyAttackDust");
        var obj = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.FlyAttackDust);
        obj.transform.position = transform.position;
        ObjPool.ObjectPoolInstance.ReturnObject(obj,EPrefabsName.FlyAttackDust,1f);
      
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
                    if (m_ActiveArea)
                    {
                        m_State.StateChange(m_ArrState[(int) EPlayerState.SKILL]);
                        m_NowReady = false;
                        m_ActiveArea = false;
                        StartCoroutine(CoolDown(ECoolDownSystem.AREA));
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
            case ECoolDownSystem.AREA:
                yield return m_AreaCoolTime;
                m_ActiveArea = true;
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