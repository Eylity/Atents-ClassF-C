using System.Collections;
using UnityEngine;

public class Player_Attack : Istate<PlayerFSM>
{
    private readonly PlayerFSM m_Player;
    private int m_MouseClickCount = 0;

    public Player_Attack(PlayerFSM player)
    {
        m_Player = player;
    }

    public override void OnStateEnter()
    {
        m_Player.m_Anim.SetTrigger("Attack");
    }

    public override void OnStAteUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_Player.m_Anim.SetTrigger("Attack");
        }


        if (m_Player.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("AttackL"))
        {
            CollSwitch(true);
            var animInfo = m_Player.m_Anim.GetCurrentAnimatorStateInfo(0);
            if (animInfo.normalizedTime >= 0.8f)
            {
                CollSwitch(false);
            }
        }
        else if (m_Player.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("AttackR"))
        {
            CollSwitch(true);
            var animInfo = m_Player.m_Anim.GetCurrentAnimatorStateInfo(0);

            if (animInfo.normalizedTime >= 0.8f)
            {
                CollSwitch(false);
            }
        }
        else if (m_Player.m_Anim.GetCurrentAnimatorStateInfo(0).IsName("LastAttack"))
        {
            CollSwitch(true);
            var animInfo = m_Player.m_Anim.GetCurrentAnimatorStateInfo(0);

            if (animInfo.normalizedTime >= 0.8f)
            {
                CollSwitch(false);
            }
            m_Player.m_Anim.ResetTrigger("Attack");
        }
    }

    public override void OnStateExit()
    {
        CollSwitch(false);
    }

    private void CollSwitch(bool isEnabled)
    {
        foreach (var collider in m_Player.m_AttackCollider)
        {
            collider.enabled = isEnabled;
        }
    }
}