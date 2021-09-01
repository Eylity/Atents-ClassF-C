using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T>
{
    private T m_PLayer;

    private Istate<T> m_CurState;

    public void StateEnter()
    {
        m_CurState?.OnStateEnter();
    }

    public void StateUpdate()
    {
        m_CurState?.OnStAteUpdate();
    }

    public void StateExit()
    {
        m_CurState.OnStateExit();
    }

    public void StateChange(Istate<T> state)
    {
        if (m_CurState != state)
        {
            StateExit();
        }

        m_CurState = state;
        m_CurState?.OnStateEnter();
    }

    public void SetState(Istate<T> state, T player)
    {
        m_PLayer = player;
        m_CurState = state;
    }

}
