using System;
using System.Collections;
using System.Diagnostics;
using FSM.Player;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using Debug = UnityEngine.Debug;

public class PlayerFSM : MonoBehaviour
{
    private StateMachine<PlayerFSM> m_State;
    private WaitForSeconds m_FlyAttackCoolTime = new WaitForSeconds(5.0f);
    private WaitForSeconds m_FullSwingCoolTime = new WaitForSeconds(6.0f);
    private WaitForSeconds m_SkillCoolTime = new WaitForSeconds(6.0f);
    private Vector3 m_MoveDir;

    public Istate<PlayerFSM>[] m_ArrState = new Istate<PlayerFSM>[(int) EPlayerState.Length];
    public Animator m_Anim;
    public Collider[] m_AttackCollider;
    public bool m_ActiveFlyAttack = true;
    public bool m_ActiveFullSwing = true;
    public bool m_ActiveSkill = true;
    public Rigidbody m_Rigidbody;
    public GameObject m_Skill;


    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Anim = GetComponent<Animator>();
        m_AttackCollider = GetComponentsInChildren<BoxCollider>();
        Debug.Log(m_AttackCollider.Length);
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

    public GameObject test()
    {
        GameObject obj = Instantiate(m_Skill, transform.position, Quaternion.identity);
        return obj;
    }

    private void Init()
    {
        m_State = new StateMachine<PlayerFSM>();
        m_ArrState[(int) EPlayerState.Idle] = new Player_Idle(this);
        m_ArrState[(int) EPlayerState.Move] = new Player_Move(this);
        m_ArrState[(int) EPlayerState.Attack] = new Player_Attack(this);
        m_ArrState[(int) EPlayerState.FlyAttack] = new Player_FlyAttack(this);
        m_ArrState[(int) EPlayerState.Skill] = new Player_Skill(this);
        m_ArrState[(int) EPlayerState.FullSwing] = new Player_FullSwing(this);

        m_State.SetState(m_ArrState[(int) EPlayerState.Idle], this);
    }

    void Update()
    {
        m_State.StateUpdate();
    }
    

    private IEnumerator State()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_State.StateChange(m_ArrState[(int) EPlayerState.Attack]);
            }

            if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Move") || 
                m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
                {
                    m_State.StateChange(m_ArrState[(int) EPlayerState.Move]);
                }
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (m_ActiveFlyAttack)
                {
                    m_ActiveFlyAttack = false;
                    FlyAttack();
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (m_ActiveFullSwing)
                {
                    m_ActiveFullSwing = false;
                    FullSwing();
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_State.StateChange(m_ArrState[(int)EPlayerState.Skill]);
            }
            yield return null;
        }
    }


    private void FlyAttack()
    {
        m_State.StateChange(m_ArrState[(int) EPlayerState.FlyAttack]);
        StartCoroutine(FlyAttackCoolDown());
    }
    private void FullSwing()
    {
        m_State.StateChange(m_ArrState[(int) EPlayerState.FullSwing]);
        StartCoroutine(FullSwingCoolDown());
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
}