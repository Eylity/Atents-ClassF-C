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
    }

    public override void OnStAteUpdate()
    {
        if (m_PLayer.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || m_PLayer.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Move") || 
            m_PLayer.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {

            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");

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

            m_PLayer.m_Anim.SetBool("IsMove", true);
            if (x == 0 && z == 0)
            {
                m_PLayer.m_Anim.SetBool("IsMove", false);
                m_PLayer.m_Anim.SetBool("IsRun", false);
            }

            var transform = m_PLayer.transform;
            var position = transform.position;
            var movePos = new Vector3(x, position.y, z) * moveSpeed * Time.deltaTime;
            position += movePos;
            transform.position = position;
            m_PLayer.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movePos),
                rotateSpeed * Time.deltaTime);
        }
        else
        {
            m_PLayer.m_Anim.SetBool("IsMove", false);
            m_PLayer.m_Anim.SetBool("IsRun", false);
        }
    }

    public override void OnStateExit()
    {
    }
}