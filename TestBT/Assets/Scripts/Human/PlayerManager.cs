using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
    [FoldoutGroup("Player Trail")][SerializeField] private BoxCollider m_AttackLeftCollider;
    [FoldoutGroup("Player Trail")][SerializeField] private BoxCollider m_AttackRightCollider;
    
    #region AnimEvents
    
    private void AttackTrue(string animName)
    {
        switch (animName)
        {
            case "AttackL":
                m_AttackLeftCollider.enabled = true;
                break;
            case "AttackR":
                m_AttackRightCollider.enabled = true;
                break;
            case "LastAttack":
                m_AttackLeftCollider.enabled = true;
                m_AttackRightCollider.enabled = true;
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