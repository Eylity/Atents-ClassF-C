using System.Diagnostics;
using UnityEngine;

public class Player_Move : Istate<PlayerFSM>
{
    private PlayerFSM m_PLayer;
    private float x;
    private float z;
    private float moveSpeed;
    private float rotateSpeed;

    public Player_Move(PlayerFSM player)
    {
        m_PLayer = player;
    }

    public override void OnStateEnter()
    {
        m_PLayer.m_Anim.SetBool("IsMove", true);
    }

    public override void OnStAteUpdate()
    {
        if (Input.GetMouseButtonDown(1) && m_PLayer.m_ActiveFlyAttack)
        {
            m_PLayer.FlyAttack();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 6f;
            rotateSpeed = 8f;
            m_PLayer.m_Anim.SetBool("IsRun", true);
        }
        else
        {
            moveSpeed = 2f;
            rotateSpeed = 8f;
            m_PLayer.m_Anim.SetBool("IsRun", false);
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        if (x == 0 && z == 0)
        {
            m_PLayer.m_Anim.SetBool("IsMove", false);
            m_PLayer.m_Anim.SetBool("IsRun", false);
        }
        else
        {
            m_PLayer.m_Anim.SetBool("IsMove", true);
            var transform = m_PLayer.transform;
            var movePos = new Vector3(x, transform.position.y, z) * moveSpeed * Time.deltaTime;
            transform.position += movePos;
            m_PLayer.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movePos),
                rotateSpeed * Time.deltaTime);
        }
    }

    public override void OnStateExit()
    {
        m_PLayer.m_Anim.SetBool("IsMove", false);
        m_PLayer.m_Anim.SetBool("IsRun", false);
    }
}