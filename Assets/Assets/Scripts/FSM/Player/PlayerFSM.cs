using System;
using System.Collections;
using FSM.Player;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Debug = UnityEngine.Debug;

public class PlayerFSM : MonoBehaviour
{
    private StateMachine<PlayerFSM> m_State;
    private WaitForSeconds m_FlyAttackCoolTime = new WaitForSeconds(5.0f);


    public Istate<PlayerFSM>[] m_ArrState = new Istate<PlayerFSM>[(int) EPlayerState.Length];
    public Animator m_Anim;
    public Collider[] m_AttackCollider;
    public bool m_ActiveFlyAttack = true;
    public float moveSpeed;
    public float rotateSpeed;



    private void Awake()
    {
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

    private void Init()
    {
        m_State = new StateMachine<PlayerFSM>();
        m_ArrState[(int) EPlayerState.Idle] = new Player_Idle(this);
        m_ArrState[(int) EPlayerState.Move] = new Player_Move(this);
        m_ArrState[(int) EPlayerState.Attack] = new Player_Attack(this);
        m_ArrState[(int) EPlayerState.FlyAttack] = new Player_FlyAttack(this);

        m_State.SetState(m_ArrState[(int) EPlayerState.Idle], this);
    }

    void Update()
    {
        m_State.StateUpdate();
    }

    void FixedUpdate()
    {
        
    }

    private IEnumerator State()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_State.StateChange(m_ArrState[(int) EPlayerState.Attack]);
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.D))
            {
                if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                {
                    m_State.StateChange(m_ArrState[(int) EPlayerState.Move]);
                }
            }

            yield return null;
        }
    }

    private IEnumerator FlyAttackCoolDown()
    {
        yield return m_FlyAttackCoolTime;
        m_ActiveFlyAttack = true;
    }

    public void FlyAttack()
    {
        m_State.StateChange(m_ArrState[(int)EPlayerState.FlyAttack]);
        StartCoroutine(nameof(FlyAttackCoolDown));
    }
}