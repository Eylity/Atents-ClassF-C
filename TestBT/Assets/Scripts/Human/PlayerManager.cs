using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPlayerSound
{
    Area,
    FullSwing,
}
public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    private AudioSource m_Audio;

    [Header("----- Sound -----")]
    
    [SerializeField] private AudioClip m_Move1;
    [SerializeField] private AudioClip m_Move2;
    [SerializeField] private AudioClip m_AttackL;
    [SerializeField] private AudioClip m_AttackR;
    [SerializeField] private AudioClip m_LastAttack;
    [SerializeField] private AudioClip m_Area;
    [SerializeField] private AudioClip m_FullSwing;

    [Header("----- Player Attack Collider -----")]
    
    [SerializeField] private BoxCollider m_AttackLeftCollider;
    [SerializeField] private BoxCollider m_AttackRightCollider;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }

        Instance = this;
        m_Audio = this.GetComponent<AudioSource>();
    }

    public void PlaySound(EPlayerSound soundName)
    {
        m_Audio.clip = soundName switch
        {
            EPlayerSound.Area => m_Area,
            EPlayerSound.FullSwing => m_FullSwing,
            _ => throw new ArgumentOutOfRangeException(nameof(soundName), soundName, null)
        };
        m_Audio.Play();
    }
    
    #region AnimEvents

    private void MoveSound1()
    {
        m_Audio.clip = m_Move1;            
        m_Audio.Play();
    }
    private void MoveSound2()
    {
        m_Audio.clip = m_Move2;
        m_Audio.Play();
    }
    
    private void AttackTrue(string animName)
    {
        switch (animName)
        {
            case "AttackL":
                m_AttackLeftCollider.enabled = true;
                m_Audio.clip = m_AttackL;
                m_Audio.Play();
                break;
            case "AttackR":
                m_AttackRightCollider.enabled = true;
                m_Audio.clip = m_AttackR;
                m_Audio.Play();
                break;
            case "LastAttack":
                m_AttackLeftCollider.enabled = true;
                m_AttackRightCollider.enabled = true;
                m_Audio.clip = m_LastAttack;
                m_Audio.Play();
                break;
            case "FullSwing":
                m_AttackLeftCollider.enabled = true;
                m_AttackRightCollider.enabled = true;
                break;
            case "FlyAttack":
                m_AttackRightCollider.enabled = true;
                break;
        }
    }

    private void AttackFalse(string animName)
    {
        switch (animName)
        {
            case "AttackL":
                m_AttackLeftCollider.enabled = false;
                break;
            case "AttackR":
                m_AttackRightCollider.enabled = false;
                break;
            case "LastAttack":
                m_AttackLeftCollider.enabled = false;
                m_AttackRightCollider.enabled = false;
                break;
            case "FullSwing":
                m_AttackLeftCollider.enabled = false;
                m_AttackRightCollider.enabled = false;
                break;
            case "FlyAttack":
                m_AttackRightCollider.enabled = false;
                break;
        }
    }

    #endregion
}