using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimEvents : MonoBehaviour
{
    
    [Header("----- Player Attack Collider -----")]
    [SerializeField] private BoxCollider m_AttackLeftCollider;
    [SerializeField] private BoxCollider m_AttackRightCollider;

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

        // State Name "FlyAttack"
        private void IsGround()
        {
            var obj = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.FlyAttackDust);
            obj.transform.position = transform.position;
            ObjPool.ObjectPoolInstance.ReturnObject(obj, EPrefabsName.FlyAttackDust, 1f);
        }

        #endregion

}
