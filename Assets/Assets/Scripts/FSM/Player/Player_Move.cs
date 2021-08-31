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
    }

    public override void OnStateExit()
    {
    }
}