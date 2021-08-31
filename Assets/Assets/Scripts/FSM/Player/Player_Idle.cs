using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Idle : Istate<PlayerFSM>
{
    private PlayerFSM m_PLayer;
    

    public Player_Idle(PlayerFSM player)
    {
        m_PLayer = player;
    }
    public override void OnStateEnter()
    {
    }

    public override void OnStAteUpdate()
    {
        m_PLayer.nowIdle = true;
    }

    public override void OnStateExit()
    {
    }
}
