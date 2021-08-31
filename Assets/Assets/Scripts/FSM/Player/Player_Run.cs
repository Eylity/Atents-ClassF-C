using System;
using System.Collections;
using UnityEngine;

public class Player_Run : Istate<PlayerFSM>
{
    private PlayerFSM m_Player;
    private float x;
    private float z;
    private float moveSpeed = 6f;
    private float rotateSpeed = 8f;

    public Player_Run(PlayerFSM player)
    {
        m_Player = player;
    }
    public override void OnStateEnter()
    {
        m_Player.m_Anim.SetBool("IsRun",true);
        m_Player.m_Anim.SetBool("IsMove",true);
    }

    public override void OnStAteUpdate()
    {
        if (!m_Player.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            return;
        }
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        if (x == 0 && z == 0)
        {
            m_Player.m_Anim.SetBool("IsRun",false);
        }
        else
        {
            var transform = m_Player.transform;
            var movePos = new Vector3(x, transform.position.y, z) * moveSpeed * Time.deltaTime;
            transform.position += movePos;
            m_Player.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movePos), rotateSpeed * Time.deltaTime );
        }
    }

    public override void OnStateExit()
    {
            m_Player.m_Anim.SetBool("IsRun",false);
            m_Player.m_Anim.SetBool("IsMove",false);
            
    }
}