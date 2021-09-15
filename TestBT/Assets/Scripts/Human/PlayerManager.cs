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

    public PSMeshRendererUpdater GetEffect(GameObject owner, EPrefabsName particleName, float returnTime, Transform parent = null)
    {
        var currentParticle = ObjPool.Instance.GetObject(particleName);
        currentParticle.transform.position = owner.transform.position;
        if (parent != null)
        {
            currentParticle.transform.parent = parent;
        }

        ObjPool.Instance.ReturnObject(currentParticle, particleName, (float) returnTime);

        if (currentParticle.TryGetComponent<PSMeshRendererUpdater>(out var rendererUpdater))
        {
            rendererUpdater.UpdateMeshEffect(owner);
            return rendererUpdater;
        }

        return null;
    }

    public void GetEffectObj(Vector3 currentPos, EPrefabsName particleName, out GameObject effect,
        float? returnTime = null)
    {
        var currentParticle = ObjPool.Instance.GetObject(particleName);
        currentParticle.transform.position = currentPos;

        if (returnTime != null)
        {
            ObjPool.Instance.ReturnObject(currentParticle, particleName, (float) returnTime);
        }

        effect = currentParticle;
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