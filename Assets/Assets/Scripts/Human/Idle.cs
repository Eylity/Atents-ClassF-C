using UnityEngine;
using Human;


public class Idle : State<PlayerController>
{
    private readonly int m_IsMove = Animator.StringToHash("IsMove");
    private readonly int m_IsRun = Animator.StringToHash("IsRun");
    private readonly int m_IdleAnim;
    private float m_MoveX;
    private float m_MoveZ;
    private float m_MoveSpeed;
    private float m_RotateSpeed;

    public Idle() : base("Base Layer.Idle")
    {
        m_IdleAnim = Animator.StringToHash("Idle");
    }

    public override void Begin()
    {
        //PlayerController.GetPlayerController.m_AttackLeftTrail.Deactivate();
        //PlayerController.GetPlayerController.m_AttackRightTrail.Deactivate();
    }

    public override void Reason()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Machine.ChangeState<AttackL>();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Machine.ChangeState<FlyAttack>();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Machine.ChangeState<FullSwing>();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Machine.ChangeState<Area>();
        }
    }

    public override void Update(float deltaTime, AnimatorStateInfo stateInfo)
    {
        if (!PlayerController.GetPlayerController.m_IsLive) return;

        m_MoveX = Input.GetAxis("Horizontal");
        m_MoveZ = Input.GetAxis("Vertical");
        if (m_MoveX == 0 && m_MoveZ == 0)
        {
            PlayerController.GetPlayerController.m_Anim.SetBool(m_IsMove, false);
            PlayerController.GetPlayerController.m_Anim.SetBool(m_IsRun, false);
            PlayerController.GetPlayerController.m_CurState = EPlayerState.IDLE;
            return;
        }

        if (Input.GetKey(KeyCode.LeftShift) &&
            !PlayerController.GetPlayerController.m_NowExhausted)
        {
            m_MoveSpeed = 6f;
            m_RotateSpeed = 8f;
            PlayerController.GetPlayerController.m_CurState = EPlayerState.RUN;
            PlayerController.GetPlayerController.m_Anim.SetBool(m_IsRun, true);
        }
        else
        {
            m_MoveSpeed = 2f;
            m_RotateSpeed = 8f;
            PlayerController.GetPlayerController.m_CurState = EPlayerState.MOVE;
            PlayerController.GetPlayerController.m_Anim.SetBool(m_IsRun, false);
        }

        PlayerController.GetPlayerController.m_Anim.SetBool(m_IsMove, true);


        var camPos = Camera.main.transform;
        var movePos = camPos.right * m_MoveX + camPos.forward * m_MoveZ;
        movePos.y = 0f;
        movePos.Normalize();

        PlayerController.GetPlayerController.m_CharacterController.Move(movePos *
                                                                        (m_MoveSpeed * deltaTime));
        PlayerController.GetPlayerController.transform.rotation = Quaternion.Slerp(
            PlayerController.GetPlayerController.transform.rotation,
            Quaternion.LookRotation(movePos),
            m_RotateSpeed * deltaTime);
    }

    public override void End()
    {
        PlayerController.GetPlayerController.m_Anim.SetBool(m_IsMove, false);
        PlayerController.GetPlayerController.m_Anim.SetBool(m_IsRun, false);
    }
}