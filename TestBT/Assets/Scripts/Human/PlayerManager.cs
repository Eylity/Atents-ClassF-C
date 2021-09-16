using System.Collections;
using XftWeapon;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }

        Instance = this;
    }

    #region PlayerParticleManger

    [FoldoutGroup("Player Trail")] public XWeaponTrail m_AttackLeftTrail;
    [FoldoutGroup("Player Trail")] public XWeaponTrail m_AttackRightTrail;

    public void TrailSwitch(bool isActive = true)
    {
        switch (isActive)
        {
            case true:
                m_AttackLeftTrail.Activate();
                m_AttackRightTrail.Activate();
                break;
            case false:
                m_AttackLeftTrail.Deactivate();
                m_AttackRightTrail.Deactivate();
                break;
        }
    }

    public GameObject GetEffect(Vector3 spawnPos, EPrefabsName effectName, float returnTime,
        float? activeTime = null, GameObject owner = null)
    {
        var currentParticle = ObjPool.Instance.GetObject(effectName);
        currentParticle.transform.position = spawnPos;

        ObjPool.Instance.ReturnObject(currentParticle, effectName, returnTime);

        if (currentParticle.TryGetComponent<PSMeshRendererUpdater>(out var rendererUpdater) && activeTime != null && owner != null)
        {
            StartCoroutine(ActiveTime(rendererUpdater, (float)activeTime));
            currentParticle.transform.parent = owner.transform;
            rendererUpdater.UpdateMeshEffect(owner);
        }
        return currentParticle;
    }

    private IEnumerator ActiveTime(PSMeshRendererUpdater currentEffect, float delay)
    {
        yield return new WaitForSeconds(delay);
        currentEffect.IsActive = false;
    }

    #endregion


    #region AnimEvents

    [FoldoutGroup("Player Collider")] [SerializeField]
    private BoxCollider m_AttackLeftCollider;

    [FoldoutGroup("Player Collider")] [SerializeField]
    private BoxCollider m_AttackRightCollider;

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