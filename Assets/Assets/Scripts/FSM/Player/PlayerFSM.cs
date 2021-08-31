using System;
using System.Collections;
using System.Diagnostics;
using FSM.Player;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Debug = UnityEngine.Debug;

public class PlayerFSM : MonoBehaviour
{
    private StateMachine<PlayerFSM> m_State;
    private WaitForSeconds m_FlyAttackCoolTime = new WaitForSeconds(5.0f);
    private Vector3 m_MoveDir;

    public Istate<PlayerFSM>[] m_ArrState = new Istate<PlayerFSM>[(int) EPlayerState.Length];
    public Animator m_Anim;
    public Collider[] m_AttackCollider;
    public bool m_ActiveFlyAttack = true;
    public bool nowIdle = true;
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
        m_ArrState[(int) EPlayerState.Attack] = new Player_Attack(this);
        m_ArrState[(int) EPlayerState.FlyAttack] = new Player_FlyAttack(this);

        m_State.SetState(m_ArrState[(int) EPlayerState.Idle], this);
    }

    public void ChangeState(EPlayerState state)
    {
        for (int i = 0; i < (int)EPlayerState.Length; i++)
        {
            if (i == (int)state)
            {
                m_State.StateChange(m_ArrState[i]);
            }
        }
    }

    void Update()
    {
        m_State.StateUpdate();
    }

    void FixedUpdate()
    {
        if (nowIdle)
        {
            if (Input.GetMouseButtonDown(1) && m_ActiveFlyAttack)
            {
                FlyAttack();
            }
        
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");
            if (x == 0 && z == 0)
            {
                m_Anim.SetBool("IsMove", false);
                m_Anim.SetBool("IsRun", false);
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    moveSpeed = 6f;
                    rotateSpeed = 8f;
                    m_Anim.SetBool("IsRun", true);
                }
                else
                {
                    moveSpeed = 2f;
                    rotateSpeed = 8f;
                    m_Anim.SetBool("IsRun", false);
                }
                m_Anim.SetBool("IsMove", true);
                var movePos = new Vector3(x, transform.position.y, z) * moveSpeed * Time.deltaTime;
                transform.position += movePos;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movePos),
                    rotateSpeed * Time.deltaTime);
            }
        }
        else
        {
            m_Anim.SetBool("IsMove", false);
            m_Anim.SetBool("IsRun", false);
        }
    }

    private IEnumerator State()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                nowIdle = false;
                m_State.StateChange(m_ArrState[(int) EPlayerState.Attack]);
            }

            yield return null;
        }
    }


    private void FlyAttack()
    {
        m_State.StateChange(m_ArrState[(int)EPlayerState.FlyAttack]);
        StartCoroutine(nameof(FlyAttackCoolDown));
    }
    private IEnumerator FlyAttackCoolDown()
    {
        yield return m_FlyAttackCoolTime;
        m_ActiveFlyAttack = true;
    }
}